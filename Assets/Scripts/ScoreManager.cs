using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance

    public TextMeshProUGUI scoreText;    // TMP Text element to display the score
    private int currentScore;
    public GameObject winPanel;  // Player's current score
    public AudioSource backgroundAudio;

    private void Awake()
    {
        // Ensure there's only one instance of the ScoreManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentScore = 0; // Initialize the score
        UpdateScoreUI();
    }

    public void AddScore(int score)
    {
        currentScore += score; // Add to the current score
        UpdateScoreUI();
        if (currentScore >= 50)
        {
            TriggerWin();
        }
    }

    private void UpdateScoreUI()
    {
        // Update the TMP text to reflect the current score
        scoreText.text = "Score: " + currentScore;
    }
    private void TriggerWin()
    {
        // Show the win panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        if (backgroundAudio != null && backgroundAudio.isPlaying)
        {
            backgroundAudio.Stop();
        }

        // Stop the game (optional)
        Time.timeScale = 0f;  // Freeze the game
    }

    public int GetFinalScore()
    {
        // Return the player's current score
        return currentScore;
    }
    public int GetCurrentScore()
    {
        return currentScore; // Replace 'currentScore' with the variable name you use for score
    }

}
