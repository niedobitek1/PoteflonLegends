using UnityEngine;
using System.Collections; // Add this namespace to use IEnumerator

public class DelayStartScript : MonoBehaviour
{
    public float delayTime = 3f;  // Time in seconds to delay
    public GameObject player;     // Reference to the player object

    void Start()
    {
        // Start the coroutine for the delay
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        // Disable player controls initially
        if (player != null)
        {
            player.SetActive(false);
        }

        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Enable player controls after the delay
        if (player != null)
        {
            player.SetActive(true);
        }

        // Additional code to start the game can be added here
    }
}
