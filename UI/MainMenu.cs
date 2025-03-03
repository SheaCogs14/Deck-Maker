using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    void Settings()
    {
        // toggle option menu
        // have audio settings 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


