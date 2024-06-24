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
        SceneManager.LoadScene(2);
    }
    public void TiepTuc()
    {
        SceneManager.LoadScene(1);
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
