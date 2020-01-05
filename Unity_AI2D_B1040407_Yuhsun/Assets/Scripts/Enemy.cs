using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"),Range(0, 100)]
    public float speed = 10.0f;
    [Header("傷害"), Range(0, 100)]
    public float damege = 20f;

    public Transform checkPoint;

    private Rigidbody2D r2d;
     
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 射線
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 1.5f);
    }

    /// <summary>
    /// 觸發
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Hero")
        {
            Track(collision.transform.position);
        }
    }

    /// <summary>
    /// 給予玩家傷害
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Hero>().Damage(damege);
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()   
    {
        r2d.AddForce(-transform.right * speed);

        RaycastHit2D hit =  Physics2D.Raycast(checkPoint.position, -checkPoint.up, 1.5f, 1 << 8);

        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0); 
        }
    }

    /// <summary>
    /// 追蹤玩家
    /// </summary>
    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
