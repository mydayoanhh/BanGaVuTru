using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChucNangMenu : MonoBehaviour
{
    public void ChoiMoi()
    {
        SceneManager.LoadScene(1);
    }
    public void Pause()
    {
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(2);
    }
    public void TiepTuc()
    {
        int currentScene = PlayerPrefs.GetInt("CurrentScene", 1);
        SceneManager.LoadScene(currentScene);
    }
    public void Setting()
    {
        SceneManager.LoadScene(0);
    }
    public void Thoat()
    {
        Application.Quit();
    }
    public void QuaylaiPause()
    {
        SceneManager.LoadScene(3);
    }

}
