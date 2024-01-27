using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothFactor = 0.5f;

    private Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector and normalize
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply smoothing to the movement
        Vector2 smoothedMovement = Vector2.Lerp(rigidbody2d.velocity, new Vector2(movement.x * moveSpeed, movement.y * moveSpeed), smoothFactor * Time.deltaTime);

        // Move the player using Rigidbody2D
        rigidbody2d.velocity = smoothedMovement;
    }
}
