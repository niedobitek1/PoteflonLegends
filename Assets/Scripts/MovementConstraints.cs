using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementConstraints : MonoBehaviour
{
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void Update()
    {
        // Ensure the object stays within the specified boundaries
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );
    }
}
