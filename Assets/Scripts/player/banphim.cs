using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class banphim : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    public Transform ShootingPoint;

    public float minX = -9.7f;
    public float maxX = 9.7f;
    public float minY = -3.75f;
    public float maxY = 3.75f;

    public int lives = 3; // Số mạng của player
    private bool gameOver = false; // Kiểm tra trạng thái game over

    public Image heart1; // Tham chiếu đến hình ảnh trái tim 1
    public Image heart2; // Tham chiếu đến hình ảnh trái tim 2
    public Image heart3; // Tham chiếu đến hình ảnh trái tim 3

    void Start()
    {
        UpdateLivesUI(); // Cập nhật UI khi bắt đầu trò chơi
    }

    void Update()
    {
        if (gameOver) return; // Nếu game đã kết thúc, không thực hiện cập nhật

        // Di chuyển bằng bàn phím
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xDir, yDir, 0) * moveSpeed * Time.deltaTime;

        // Tính toán vị trí mới của đối tượng
        Vector3 newPos = transform.position + movement;

        // Giới hạn vị trí di chuyển của đối tượng
        float clampedX = Mathf.Clamp(newPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(newPos.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bullet && ShootingPoint)
        {
            Instantiate(bullet, ShootingPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            lives--; // Giảm số mạng khi va chạm với enemy
            UpdateLivesUI(); // Cập nhật UI khi số mạng thay đổi

            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    private void UpdateLivesUI()
    {
        // Ẩn các hình ảnh trái tim dựa trên số mạng còn lại
        if (lives <= 2) heart3.enabled = false;
        if (lives <= 1) heart2.enabled = false;
        if (lives <= 0) heart1.enabled = false;
    }

    private void GameOver()
    {
        gameOver = true; // Đặt trạng thái game over
        Debug.Log("Game Over"); // Hiển thị thông báo game over
        
    }
}
