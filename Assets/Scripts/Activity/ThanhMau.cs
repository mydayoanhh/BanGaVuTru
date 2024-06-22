using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThanhMau : MonoBehaviour
{
   public Image _ThanhMau;
    public void capNhatThanhMau( float luongMauHientai, float luongMauToiDa)
    {
        _ThanhMau.fillAmount = luongMauHientai / luongMauToiDa;
    }
}
