using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    void HandleCollision(GameObject other)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (other.CompareTag("Obstacle"))
            {
                // Player collides with Obstacle
                Debug.Log("Player collided with Obstacle!");
                Destroy(gameObject);  // Destroy the Player
            }
            else if (other.CompareTag("Enemy"))
            {
                // Player collides with Enemy
                Debug.Log("Player collided with Enemy!");
                Destroy(gameObject);  // Destroy the Player
            }
            // Add more else if statements for other collision relations as needed
        }
        else if (gameObject.CompareTag("Obstacle") && other.CompareTag("Enemy"))
        {
            // Obstacle collides with Enemy
            Debug.Log("Obstacle collided with Enemy!");
            Destroy(gameObject);  // Destroy the Obstacle
        }
        // Add more else if statements for other collision relations as needed
    }
}
