using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasActions : MonoBehaviour
{
    public void RestartGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
