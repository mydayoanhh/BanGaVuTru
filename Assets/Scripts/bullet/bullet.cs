using UnityEngine;

public class Bullet : MonoBehaviour
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
                // Nếu không có EnemyHealth, phá hủy game object của col
                Destroy(col.gameObject);
            }

            // Tăng điểm số khi tiêu diệt enemy
            ScoreManager.instance.AddScore(1);
        }
    }
}