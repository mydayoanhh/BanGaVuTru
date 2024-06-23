using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
      int enemyCount = 0;

    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            enemyCount--;
        }
    }

    void Update()
    {
        if (enemyCount == 0)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
