using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 400f;
    private float currentHealth;
    public ThanhMau healthBar; // Tham chiếu đến thanh máu
    public int scoreValue = 10; // Giá trị điểm số khi tiêu diệt kẻ thù

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.capNhatThanhMau(currentHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Xử lý kẻ thù chết
            ScoreManager.instance.AddScore(scoreValue); // Thêm điểm
            Destroy(gameObject); // Hủy đối tượng kẻ thù
            SceneManager.LoadScene(3); // Chuyển scene sau khi tiêu diệt kẻ thù
        }
        healthBar.capNhatThanhMau(currentHealth, maxHealth);
    }
}
