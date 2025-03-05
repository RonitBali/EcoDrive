using UnityEngine;

public class LevelPopUp : MonoBehaviour
{
    public GameObject popUpPanel; // Assign the pop-up panel in the Inspector

    private void Start()
    {
        Time.timeScale = 0; // Pause the game
        popUpPanel.SetActive(true); // Show the pop-up
    }

    public void StartLevel()
    {
        popUpPanel.SetActive(false); // Hide the pop-up
        Time.timeScale = 1; // Resume the game
    }
}
