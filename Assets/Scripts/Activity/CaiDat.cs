using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaiDat : MonoBehaviour
{
    public MovementSelecter movementSelector;
    public Dropdown movementDropdown; // Tham chiếu đến Dropdown trong UI
    public GameObject uiPanel;
    private bool isUIVisible = false;

    void Start()
    {
        
        // Đảm bảo Dropdown có một listener để gọi phương thức khi giá trị thay đổi
        movementDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isUIVisible == false )
        {
            Time.timeScale = 0;
            ToggleUI();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isUIVisible == true)
        { 
            Time.timeScale = 1; 
            ToggleUI();
        }
    }
    public void OnDropdownValueChanged(int newValue)
    {
        movementSelector.SetMovement(newValue+1); // Gọi phương thức SetMovement với giá trị từ Dropdown
    }
    public void ToggleUI()
    {
        isUIVisible = !isUIVisible;
        Cursor.visible = isUIVisible;
        uiPanel.SetActive(isUIVisible); // Bật/tắt UI panel
    }
}
