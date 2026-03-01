using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuCanvas : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
