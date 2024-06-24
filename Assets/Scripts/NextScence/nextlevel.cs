using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour 
{
    public string nextLevelName; 

    public void LoadNextLevel() 
    {
        if (string.IsNullOrEmpty(nextLevelName))
        {
            Debug.LogError("Please set the 'nextLevelName' variable in the Inspector!");
            return; 
        }

        SceneManager.LoadScene(4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }
}
