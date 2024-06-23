using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 400f;
    private float currentHealth;
    public ThanhMau healthBar; // Tham chiếu đến thanh máu

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.capNhatThanhMau(currentHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Xử lý kẻ thù chết (nếu cần)
            Destroy(gameObject); // hủy đối tượng kẻ thù
        }
        healthBar.capNhatThanhMau(currentHealth, maxHealth);
    }
}
