using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public BossBrain bossBrain;
    public float phaseTwoThreshold = 0.5f;
    public Healthbar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        bossBrain = GetComponent<BossBrain>();

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (bossBrain != null && bossBrain.isDead) return;

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        if (bossBrain != null && !bossBrain.phaseTwo && currentHealth <= maxHealth * phaseTwoThreshold)
        {
            bossBrain.EnterPhaseTwo();
        }

        if (bossBrain != null && bossBrain.phaseTwo && currentHealth <= 0)
        {
            bossBrain.Die();
        }
    }
}