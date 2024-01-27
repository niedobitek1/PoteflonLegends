using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float spawnXPosition = 15f;
    public float spawnHeightMin = -3f;
    public float spawnHeightMax = 3f;
    public float obstacleSpeed = 5f;
    public int maxObstaclesPerSpawnPoint = 2;
    public int maxTotalObstacles = 4;
    public float destroyXPosition = -15f;
    public float spawnInterval = 2f;

    private float nextSpawnTime;

    void Start()
    {
        // Start spawning obstacles at intervals
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Check if the maximum number of obstacles per spawn point has been reached
        if (CountObstaclesAtXPosition(spawnXPosition) < maxObstaclesPerSpawnPoint && CountTotalObstacles() < maxTotalObstacles)
        {
            // Generate a random spawn height within constraints
            float spawnHeight = Random.Range(spawnHeightMin, spawnHeightMax);

            // Instantiate the obstacle at the spawn position with a random Y within constraints
            GameObject obstacle = Instantiate(gameObject, new Vector2(spawnXPosition, spawnHeight), Quaternion.identity);

            // Set the obstacle's speed for leftward movement
            obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(-obstacleSpeed, 0f);

            // Set the script to automatically destroy the obstacle when it reaches X=destroyXPosition
            AutoDestroyOnXReached autoDestroyScript = obstacle.AddComponent<AutoDestroyOnXReached>();
            autoDestroyScript.destroyXPosition = destroyXPosition;
        }
    }

    int CountObstaclesAtXPosition(float xPosition)
    {
        // Count the number of active obstacles at a specific X position
        return GameObject.FindGameObjectsWithTag("Obstacle").Count(obstacle => obstacle.transform.position.x == xPosition);
    }

    int CountTotalObstacles()
    {
        // Count the total number of active obstacles in the scene
        return GameObject.FindGameObjectsWithTag("Obstacle").Length;
    }
}
