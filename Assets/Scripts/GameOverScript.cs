using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public string gameOverScene; // Name of the game over scene or current scene for restart
    private bool isGameOver = false; // Flag to check if the game is over
    public float restartDelay = 3f; // Delay in seconds before the game restarts

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RestartGameAfterDelay(restartDelay));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Enemy" or "Obstacle"
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Add any game over logic here (e.g., display game over UI)
        isGameOver = true;
        Time.timeScale = 0; // Freeze the game
    }

    IEnumerator RestartGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Wait for the specified delay
        Time.timeScale = 1; // Unfreeze the game
        SceneManager.LoadScene(gameOverScene);
        isGameOver = false;
    }
}
