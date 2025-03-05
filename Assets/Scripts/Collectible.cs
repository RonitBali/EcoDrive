using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType { Trash, Obstacle } // Type of the object
    public CollectibleType collectibleType;        // Assign type in the Inspector
    public int scoreValue = 10;                    // Default score value for trash
    public int obstaclePenalty = 5;               // Default penalty for obstacle

    private GameObject gameOverPanel;              // Reference to the Game Over panel

    private void Start()
    {
        // Dynamically find the Game Over panel in the scene by tag
        gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");

        if (gameOverPanel == null)
        {
            Debug.LogError("Game Over Panel not found! Please ensure it has the 'GameOverPanel' tag.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure your car is tagged "Player"
        {
            if (collectibleType == CollectibleType.Trash)
            {
                // Add score to the ScoreManager for trash
                ScoreManager.Instance.AddScore(scoreValue);

                // Destroy the trash object
                Destroy(gameObject);
            }
            else if (collectibleType == CollectibleType.Obstacle)
            {
                // Check if the current score is 0
                if (ScoreManager.Instance.GetCurrentScore() <= 0)
                {
                    // Trigger game over
                    GameOver();
                }
                else
                {
                    // Deduct score for obstacle collision
                    ScoreManager.Instance.AddScore(-obstaclePenalty);

                    // Destroy the obstacle
                    Destroy(gameObject);
                }
            }
        }
    }

    private void GameOver()
    {
        // Show the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            Debug.LogError("Game Over Panel is missing in the scene!");
        }
    }
}
