using UnityEngine;

public class Hero : MonoBehaviour
{
    public int speed = 10;          //移動數值
    public float jump = 2.0f;       //跳躍數值
    public string heroName = "Hero";
    public bool pass = false;

    private Rigidbody2D r2d;        //角色移動宣告
    //private Transform tra;          //角色旋轉宣告

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        //tra = GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.A)) transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void FixedUpdate()
    {
        ///
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
}
