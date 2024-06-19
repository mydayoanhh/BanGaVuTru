using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tạo enemy ngẫu nhiên
// Tăng điểm số của người chơi
// Kiểm tra xem trò chơi đã kết thúc hay chưa --> kết thúc dừng game

public class GameController : MonoBehaviour

{
    public  GameObject enemy ;
    public float spwantTime;
    float m_spawnTime;
    int m_score;
    bool m_isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime > 15)
        {
            SpawnEnemy();
            m_spawnTime = spwantTime;
        }
        
    }
    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-11f, 11f);
        

        Vector2 spawnPos = new Vector2(randXpos, 4);
        
        if(enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }

    }

    public void SetScore(int value)
    {
        m_score = value;
    }
    public int Getcore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        m_score++; 
    }
    public void SetGameoverState(bool state)
    {
        m_isGameOver = state;
    }
    public bool IsGameover() 
    { 
        return m_isGameOver;
    }
}
