using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public Image fillImage;

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}