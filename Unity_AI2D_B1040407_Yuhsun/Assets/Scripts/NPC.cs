using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    #region 欄位
    /// <summary>
    /// 任務列舉
    /// </summary>
    public enum state
    {
        normal, notComplete, complete
    }
    public state _state;


    [Header("對話")]
    public string sayStart = "Give me the fucking 10 carrot (／‵Д′)／";
    public string sayNotComplete = "Quick!!!!!!!!!!!!!!!!!!!!!!!!!(╬☉д⊙)";
    public string sayComplete = "You are pretty good, Man ε٩(๑> ₃ <)۶з";

    [Header("對話速度")]
    public float Speed = 1.5f;

    [Header("任務相關")]
    public bool complete;
    public int comtPlayer;
    public int countFinish = 10;

    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion

    /// <summary>
    /// 呼叫；處發對話框
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Hero")
        {
            Say();
        }
    }
    /// <summary>
    ///呼叫； 離開對話框
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Hero")
        {
            SayClose();
        }
    }

    /// <summary>
    /// 對話：打字效果
    /// </summary>
    private void Say()
    {
        objCanvas.SetActive(true);
        textSay.text = sayStart;
    }
    /// <summary>
    /// 離開對話
    /// </summary>
    private void SayClose()
    {
        objCanvas.SetActive(false);
    }

}
