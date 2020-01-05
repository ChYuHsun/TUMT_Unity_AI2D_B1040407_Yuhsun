using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
