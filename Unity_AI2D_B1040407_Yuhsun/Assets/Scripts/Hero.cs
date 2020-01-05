using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{
    public int speed = 10;          //移動數值
    public float jump = 50.0f;       //跳躍數值
    public string heroName = "Hero";
    public bool pass = false;
    public bool isGround;   //是否碰到牆壁

    public UnityEvent onEat; 

    private Rigidbody2D r2d;        //角色移動宣告

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn();
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }
    /// <summary>
    /// 呼叫副程式
    /// </summary>
    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    /// <summary>
    /// 碰到地板開關
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到地板" + collision.gameObject);
    }

    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "carrot")
        {
            Destroy(collision.gameObject);      //刪除道具
            onEat.Invoke();                     //呼叫事件
        }
    }

    /// <summary>
    /// 角色走路
    /// </summary>
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    } 

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }

    /// <summary>
    /// 轉彎
    /// </summary>
    private void Turn(int direction = 0)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }

}
