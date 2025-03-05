using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float totalTime = 60f;             // Total time for the challenge
    public TMP_Text timerText;               // Text element to display the timer
    public GameObject gameOverPanel;         // Reference to the Game Over panel
    public TMP_Text finalScoreText;          // Reference to the Final Score Text
    public AudioSource backgroundAudio;      // Reference to the background audio source
    public AudioSource gameOverAudio;        // Optional Game Over sound effect

    private float timeRemaining;             // Time left in the challenge
    private bool isTimerRunning = false;     // To track if the timer is running

    private ScoreManager scoreManager;       // Reference to ScoreManager

    private void Start()
    {
        // Initialize timer and find dependencies
        timeRemaining = totalTime;
        isTimerRunning = true;
        gameOverPanel.SetActive(false);

        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }

        // Ensure background audio is playing at the start
        if (backgroundAudio != null)
        {
            backgroundAudio.Play();
        }
    }

    private void Update()
    {
        // Countdown logic
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                EndChallenge();
            }
        }
    }

    private void UpdateTimerUI()
    {
        // Format and display the remaining time
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void EndChallenge()
    {
        // Stop gameplay and show the Game Over panel
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;

        // Stop the background audio
        if (backgroundAudio != null && backgroundAudio.isPlaying)
        {
            backgroundAudio.Stop();
        }

        // Play the Game Over sound
        if (gameOverAudio != null)
        {
            gameOverAudio.Play();
        }

        // Display the final score
        if (finalScoreText != null && scoreManager != null)
        {
            finalScoreText.text = $"Final Score: {scoreManager.GetFinalScore()}";
        }
        else
        {
            Debug.LogWarning("FinalScoreText or ScoreManager is not set!");
        }
    }

    public void RestartChallenge()
    {
        // Restart the level and reset the game state
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
