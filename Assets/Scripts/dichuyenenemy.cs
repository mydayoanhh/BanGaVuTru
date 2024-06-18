using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyenenemy : MonoBehaviour
{
    public float speed = 4f;
    public float leftBoundary = -5f;
    public float rightBoundary = 5f;
    private int direction = 1; // 1 means moving right, -1 means moving left

    public float floatSpeed = 0.5f; // Speed of floating up and down
    public float floatAmplitude = 1f; // Amplitude of the floating motion

    private float initialY; // Initial Y position

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y; // Store the initial Y position
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Check for boundaries and change direction if necessary
        if (transform.position.x >= rightBoundary)
        {
            direction = -1; // Move left
        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1; // Move right
        }

        // Floating effect
        float newY = initialY + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
