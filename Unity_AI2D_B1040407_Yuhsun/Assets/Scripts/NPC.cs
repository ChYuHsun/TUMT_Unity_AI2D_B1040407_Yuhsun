using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    public float Speed = 0.1f;

    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;

    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion

    public AudioClip soundSay;

    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

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
    /// 開啟對話：打字效果
    /// </summary>
    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if(countPlayer >= countFinish) _state = state.complete;
         
        //判斷任務狀態
        switch (_state)
        {
            case state.normal:
                StartCoroutine(ShowDialog(sayStart));        //開始對話
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(sayNotComplete));    //未完成對話
                break;
            case state.complete:
                StartCoroutine(ShowDialog(sayComplete));       //完成對話
                break;
        }
    }

    /// <summary>
    /// 打字效果
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";

        for (int i = 0; i < say.Length; i++)       //迴圈跑對話
        {
            textSay.text += say[i].ToString();      //累加文字
            aud.PlayOneShot(soundSay, 1.5f);        //播放聲音
            yield return new WaitForSeconds(Speed);     //等待
        }
    }

    /// <summary>
    /// 離開對話
    /// </summary>
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public void PlayerGet()
    {
        countPlayer++;
    }

}
