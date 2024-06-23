using UnityEngine;
using UnityEngine.UI;


using UnityEngine;

public class chuot : MonoBehaviour
{
    public float moveSpeed;
    public bool useMouseMovement = true;

    public float minX = -9.7f;
    public float maxX = 9.7f;
    public float minY = -3.75f;
    public float maxY = 3.75f;

    // Start is called before the first frame update
    void Start()
    {
        // Ẩn con trỏ chuột
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển bằng chuột
        if (useMouseMovement)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane; // Đặt khoảng cách từ camera đến điểm chuột trong thế giới
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            // Giới hạn vị trí di chuyển của đối tượng
            float clampedX = Mathf.Clamp(worldPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(worldPosition.y, minY, maxY);
            transform.position = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, transform.position.z), moveSpeed * Time.deltaTime);
        }
    }
}