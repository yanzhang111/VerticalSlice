using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;

    void Start()
    {
        if (playerHealth != null)
        {
            UpdateHealthBar(playerHealth.currentHealth, playerHealth.maxHealth);
        }
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}