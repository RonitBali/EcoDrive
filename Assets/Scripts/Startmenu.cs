using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start the game by loading the first level
    public void StartGame()
    {
        SceneManager.LoadScene("LevelMenu"); // Replace "Level1" with the name of your first game scene
    }

    // Quit the application
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // This will show in the console during testing
        Application.Quit();     // Exits the application
    }
}
