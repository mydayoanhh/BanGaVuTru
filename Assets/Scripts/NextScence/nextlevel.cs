using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject image;
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int numEnemies = enemies.Length;
        Debug.Log("Number of enemies in the scene: " + numEnemies);
        // image.SetActive(false);
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int numEnemies = enemies.Length;
        if (numEnemies == 0)
        {
            Debug.Log("Đã hết kẻ thù!");
            image.SetActive(true);
        }
        else
        {
            Debug.Log("Enemies found in the scene.");
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Lấy chỉ số của scene hiện tại
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Tải scene tiếp theo dựa trên chỉ số
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}