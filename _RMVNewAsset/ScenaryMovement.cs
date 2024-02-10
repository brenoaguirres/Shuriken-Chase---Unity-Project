using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryMovement : MonoBehaviour
{
    public float speed = 3f;
    public float resetXPosition = -30.0f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Move the sprite to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if the sprite has passed the reset threshold
        if (transform.position.x <= resetXPosition)
        {
            // Reset the sprite to its initial position
            ResetToInitialPosition();
        }
    }

    private void ResetToInitialPosition()
    {
        transform.position = initialPosition;
    }
}
