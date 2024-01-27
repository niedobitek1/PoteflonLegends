using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;  // Reference to the UI Text for displaying the countdown
    public GameObject player;   // Reference to the player object
    public ScoreManager scoreManager; // Reference to the ScoreManager script

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        int count = 3;
        player.SetActive(false); // Disable player at the start
        if (scoreManager != null)
        {
            scoreManager.enabled = false; // Disable score counting at the start
        }

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        countdownText.text = "GO!";
        player.SetActive(true); // Enable player after countdown
        if (scoreManager != null)
        {
            scoreManager.enabled = true; // Enable score counting after countdown
        }

        // Hide the countdown text after a short delay
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);
    }
}
