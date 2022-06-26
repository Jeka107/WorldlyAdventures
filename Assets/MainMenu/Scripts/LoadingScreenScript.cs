using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScreenScript : MonoBehaviour
{
    //loading the main menu through the splash art at game start
    public void MainMenuOpen()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
