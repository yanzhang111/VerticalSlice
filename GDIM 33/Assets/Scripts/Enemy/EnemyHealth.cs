using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public EnemyBrain enemyBrain;
    private Collider2D enemyCollider;
    private Rigidbody2D rb;
    public EnemyHealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        enemyBrain = GetComponent<EnemyBrain>();
        enemyCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (enemyBrain != null && enemyBrain.isDead) return;

        currentHealth -= damage;

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (enemyBrain != null)
        {
            enemyBrain.isDead = true;
        }

        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }
    }
}