using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBrain : MonoBehaviour
{
    public Transform player;
    public float walkSpeed = 2f;
    public float detectRange = 8f;
    public float attackRange = 8f;
    public GameObject projectilePrefab;
    public Transform attackPoint;
    public AudioSource audioSource;
    public AudioClip attackSFX;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public float GetDistanceToPlayer()
    {
        if (player == null) return 999f;
        return Vector2.Distance(transform.position, player.position);
    }

    public void StopMoving()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    public void WalkToPlayer()
    {
        if (player == null || rb == null) return;

        float direction = player.position.x > transform.position.x ? 1f : -1f;
        rb.velocity = new Vector2(direction * walkSpeed, rb.velocity.y);

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }

    public void PlayIdle()
    {
        if (animator != null)
        {
            animator.Play("idle");
        }
    }

    public void PlayWalk()
    {
        if (animator != null)
        {
            animator.Play("walk");
        }
    }

    public void PlayAttack()
    {
        if (animator != null)
        {
            animator.Play("attack");
        }
    }
    public void FireProjectile()
    {
        if (projectilePrefab == null || attackPoint == null) return;

        GameObject obj = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

        float direction = transform.localScale.x > 0 ? 1f : -1f;

        SlimeProjectile projectile = obj.GetComponent<SlimeProjectile>();
        if (projectile != null)
        {
            projectile.Launch(direction);
        }

        if (audioSource != null && attackSFX != null)
        {
            audioSource.PlayOneShot(attackSFX);
        }
    }
}