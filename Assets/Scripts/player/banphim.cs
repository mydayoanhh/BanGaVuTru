using UnityEngine;
using UnityEngine.UI;

public class banphim : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    public Transform ShootingPoint;
    public GameObject gameOverCanvas;
    public GameObject Strongerbullet;
    private int bulletsFired = 0;

    public float minX = -9.7f;
    public float maxX = 9.7f;
    public float minY = -3.75f;
    public float maxY = 3.75f;

    public int lives = 3; // Number of player lives
    private bool gameOver = false;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    void Start()
    {
        UpdateLivesUI(); // Update UI at the start of the game
    }

    void Update()
    {
        if (gameOver) return; // If the game is over, do not update

        // Move using keyboard
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xDir, yDir, 0) * moveSpeed * Time.deltaTime;

        // Calculate new position of the object
        Vector3 newPos = transform.position + movement;

        // Limit the movement position of the object
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
            bulletsFired++;
        }
        if (bulletsFired >= 10)
        {
            ShootStrongerBullet();
            bulletsFired = 0; // Reset the count
        }
    }
    public void ShootStrongerBullet()
    {
        if (Strongerbullet && ShootingPoint)
        {
            Instantiate(Strongerbullet, ShootingPoint.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            lives--; // Decrease lives when colliding with enemy
            UpdateLivesUI(); // Update UI when lives change

            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    private void UpdateLivesUI()
    {
        // Hide heart images based on remaining lives
        if (lives <= 2) heart3.enabled = false;
        if (lives <= 1) heart2.enabled = false;
        if (lives <= 0) heart1.enabled = false;
    }

    private void GameOver()
    {
        gameOver = true; // Set game over status
        Debug.Log("Game Over"); // Display game over message
        gameOverCanvas.SetActive(true); // Activate game over canvas
    }
}
