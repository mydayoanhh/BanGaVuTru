using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    public float damageAmount = 10f; // Lượng sát thương của viên đạn
    Rigidbody2D m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển viên đạn
        m_rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("Viên đã va chạm với enemy");

            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
            else
            {
                Destroy(col.gameObject); // Phá hủy kẻ địch nếu không có EnemyHealth
            }
            Destroy(gameObject); // Phá hủy viên đạn sau khi va chạm
        }
    }
}
