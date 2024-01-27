using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;          // Reference to the UI Text element for displaying the score
    private float score;            // Variable to store the score
    private float timer;            // Timer to track time for score increment

    void Start()
    {
        score = 0;
        timer = 0;
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if 0.5 seconds have passed
        if (timer >= 0.5f)
        {
            // Increment the score and reset the timer
            score++;
            timer = 0;
        }

        // Update the score text
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText == null)
        {
            Debug.LogError("ScoreText reference not set in ScoreManager.");
            return;
        }

        scoreText.text = "Score: " + score.ToString("0");
    }
}
