using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dichuyen : MonoBehaviour
{
    public float speed = 10f;
    public float leftBoundary = -9f;
    public float rightBoundary = 9f;
    private int direction = 1;

    public float floatSpeed = 0.5f;
    public float floatAmplitude = 3f;

    private float initialY;
    private bool isFalling = true;

    public float fallSpeed = 4f;
    public float targetY = 0f;

    private float difficultyIncreaseInterval = 10f; // Thời gian giữa mỗi lần tăng độ khó
    private float nextDifficultyIncreaseTime;

    void Start()
    {
        initialY = transform.position.y;
        nextDifficultyIncreaseTime = Time.time + difficultyIncreaseInterval;
    }

    void Update()
    {
        // Tăng độ khó sau mỗi khoảng thời gian
        if (Time.time >= nextDifficultyIncreaseTime)
        {
            IncreaseDifficulty();
            nextDifficultyIncreaseTime = Time.time + difficultyIncreaseInterval;
        }

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

    void IncreaseDifficulty()
    {
        speed += 0.5f; // Tăng tốc độ di chuyển
        fallSpeed += 0.2f; // Tăng tốc độ rơi
        leftBoundary += 0.5f; // Giảm giới hạn trái (di chuyển về phía phải)
        rightBoundary -= 0.5f; // Giảm giới hạn phải (di chuyển về phía trái)
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Enemy va cham voi Player");
        }
    }
}
