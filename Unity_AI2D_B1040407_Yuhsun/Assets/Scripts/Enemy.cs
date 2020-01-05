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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 3);
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()  
    {
        r2d.AddForce(new Vector2(-speed, 0));
    }

    /// <summary>
    /// 追蹤玩家
    /// </summary>
    private void Track()
    {

    }
}
