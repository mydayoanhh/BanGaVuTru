using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dichuyen : MonoBehaviour
{
    public float speed = 4f;
    public float leftBoundary = -5f;
    public float rightBoundary = 5f;
    private int direction = 1;

    public float floatSpeed = 0.5f;
    public float floatAmplitude = 1f;

    private float initialY;
    private bool isFalling = true;

    public float fallSpeed = 2f;
    public float targetY = 0f;


    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            if (transform.position.y <= targetY)
            {
                isFalling = false;
                initialY = transform.position.y;
            }
        }
        else
        {
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

            if (transform.position.x >= rightBoundary)
            {
                direction = -1;
            }
            else if (transform.position.x <= leftBoundary)
            {
                direction = 1;
            }

            float newY = initialY + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Enemy va cham voi Player");

            SceneManager.LoadScene(3);
        }
    }
}
