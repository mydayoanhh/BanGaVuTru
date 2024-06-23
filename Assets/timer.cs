using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class timer : MonoBehaviour

{
    public TextMeshProUGUI timeText;
    private float currentTime;
    public float countDownTime = 60f;
    public GameObject player;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = countDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            currentTime = 0;
            UpdateTimeText();
            Tinhnang();
        }
    }
    void UpdateTimeText()
    {
        int minutes = ((int)currentTime / 60);
        int seconds = ((int)currentTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void Tinhnang()
    {
        try
        {
            // Phá hủy máy bay
            if (player != null)
            {
                Destroy(player);
            }
            gameOverCanvas.SetActive(true); // Hiện canvas "Game Over"
        }
        catch (NullReferenceException ex)
        {
            Debug.LogError("NullReferenceException in Tinhnang() method: " + ex.Message);
        }
    }
}
