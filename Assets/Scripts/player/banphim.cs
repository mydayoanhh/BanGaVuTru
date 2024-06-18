using UnityEditor.SearchService;
using UnityEngine;

public class banphim : MonoBehaviour
{
    public float moveSpeed;
    public GameObject PlayerBullet; // Renamed for clarity
    public Transform shootingPoint;
    public float shootingCooldown; // Declare shootingCooldown here
    private float tempCooldown;


    public float minX = -9.7f;
    public float maxX = 9.7f;
    public float minY = -3.75f;
    public float maxY = 3.75f;

    void Update()
    {
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

        if (Input.GetKey(KeyCode.Space))
        {
            if (tempCooldown <= 0)
            {
                Shoot();
                tempCooldown = shootingCooldown;
            }
        }
        tempCooldown -= Time.deltaTime;
    }

    public void Shoot()
    {
        // Ensure bulletPrefab is assigned a valid prefab reference
        if (PlayerBullet != null)
        {
            Instantiate(PlayerBullet, shootingPoint.position, Quaternion.identity, null);

    }
}
}