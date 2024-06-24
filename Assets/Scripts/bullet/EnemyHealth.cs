using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 400f;
    private float currentHealth;
    public ThanhMau healthBar; // Tham chiếu đến thanh máu
    public int scoreValue = 10; // Giá trị điểm số khi tiêu diệt kẻ thù
    public GameObject smallerEnemyPrefab; // Prefab của kẻ thù nhỏ hơn
    public int numberOfSmallerEnemies = 20; // Số lượng kẻ thù nhỏ sẽ được sinh ra

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
            SpawnSmallerEnemies(); // Sinh ra kẻ thù nhỏ hơn
            Destroy(gameObject); // Hủy đối tượng kẻ thù
            // SceneManager.LoadScene(3); // Tùy chọn: chuyển scene sau khi tiêu diệt kẻ thù
        }
        healthBar.capNhatThanhMau(currentHealth, maxHealth);
    }

    void SpawnSmallerEnemies()
    {
        for (int i = 0; i < numberOfSmallerEnemies; i++)
        {
            // Tạo ra kẻ thù nhỏ hơn tại vị trí hiện tại với một chút ngẫu nhiên
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            Instantiate(smallerEnemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
