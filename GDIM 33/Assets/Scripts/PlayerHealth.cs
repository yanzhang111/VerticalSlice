using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Transform respawnPoint;
    public float respawnDelay = 1.5f;

    private Animator animator;
    private Rigidbody2D rb;
    private Collider2D col;

    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth > 0)
        {
            if (animator != null)
            {
                animator.SetTrigger("hurt");
            }
        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        if (animator != null)
        {
            animator.ResetTrigger("hurt");
            animator.SetTrigger("die");
        }

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }

        if (col != null)
        {
            col.enabled = false;
        }

        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(respawnDelay);

        currentHealth = maxHealth;

        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }

        if (rb != null)
        {
            rb.simulated = true;
            rb.velocity = Vector2.zero;
        }

        if (col != null)
        {
            col.enabled = true;
        }

        if (animator != null)
        {
            animator.ResetTrigger("die");
            animator.Play("Base Layer.Idle");
        }

        isDead = false;
    }
}