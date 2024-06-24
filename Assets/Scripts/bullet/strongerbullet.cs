using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strongerbullet : MonoBehaviour
{

    public float timeToDestroy;
    public float damageAmount = 30f;
    public float speed ; // Tùy chỉnh tốc độ của superbullet
    private Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
    }


    private void Update()
    {
        // Di chuyển superbullet lên
        m_rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("Viên đạn siu bự đã va chạm với enemy");

            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
            else
            {
                // Nếu không có EnemyHealth, phá hủy game object của col
                Destroy(col.gameObject);
            }

            // Tăng điểm số khi tiêu diệt enemy
            ScoreManager.instance.AddScore(1);
        }
    }
}

