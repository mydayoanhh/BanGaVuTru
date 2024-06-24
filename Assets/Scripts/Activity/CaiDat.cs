using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaiDat : MonoBehaviour
{
    public MovementSelecter movementSelector;
    public Dropdown movementDropdown; // Tham chiếu đến Dropdown trong UI
    public GameObject uiPanel;
    

    void Start()
    {
        
        // Đảm bảo Dropdown có một listener để gọi phương thức khi giá trị thay đổi
        movementDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }
    
    public void OnDropdownValueChanged(int newValue)
    {
        movementSelector.SetMovement(newValue+1); // Gọi phương thức SetMovement với giá trị từ Dropdown
    }
   
}
