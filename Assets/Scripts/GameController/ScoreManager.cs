using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Đối tượng duy nhất

    public Text scoreText; // Đối tượng text để hiển thị điểm
    private int score; // Điểm số hiện tại

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        score = 0; // Khởi tạo điểm số ban đầu
        UpdateScoreText(); // Cập nhật hiển thị điểm số lên giao diện
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd; // Tăng điểm số
        UpdateScoreText(); // Cập nhật hiển thị điểm số lên giao diện
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Cập nhật text hiển thị điểm số
    }
}
