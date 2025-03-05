using UnityEngine;

public class CarStateManager : MonoBehaviour
{
    public float upsideDownThreshold = -0.7f; // Threshold for detecting upside down (-1 is fully upside down)
    public GameObject gameOverPanel;          // Reference to the Game Over UI Panel

    private bool isGameOver = false;          // To prevent multiple triggers

    private void Update()
    {
        if (isGameOver) return; // Don't check if the game is already over

        // Check if the car is upside down
        if (transform.up.y <= upsideDownThreshold)
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        isGameOver = true; // Mark the game as over
        Debug.Log("Game Over: Car is upside down!");

        // Show the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Optionally, stop the game
        Time.timeScale = 0; // Pauses the game
    }
}
