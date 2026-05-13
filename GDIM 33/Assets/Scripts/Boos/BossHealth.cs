using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public BossBrain bossBrain;
    public float phaseTwoThreshold = 0.5f;

    void Start()
    {
        currentHealth = maxHealth;
        bossBrain = GetComponent<BossBrain>();
    }

    public void TakeDamage(int damage)
    {
        if (bossBrain != null && bossBrain.isDead) return;

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (bossBrain != null && !bossBrain.phaseTwo && currentHealth <= maxHealth * phaseTwoThreshold)
        {
            bossBrain.EnterPhaseTwo();
            return;
        }

        if (bossBrain != null && bossBrain.phaseTwo && currentHealth <= 0)
        {
            bossBrain.Die();
        }
    }
}