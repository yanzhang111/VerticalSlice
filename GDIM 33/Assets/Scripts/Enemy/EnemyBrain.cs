using System.Collections;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Movement")]
    public float walkSpeed = 2f;
    public float detectRange = 5f;
    public float attackRange = 1.5f;

    [Header("Projectile Attack")]
    public GameObject projectilePrefab;
    public Transform attackPoint;
    public AudioSource audioSource;
    public AudioClip attackSFX;

    private Rigidbody2D rb;
    private Animator animator;

    public bool isDead = false;

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

    public float GetDetectRange()
    {
        return detectRange;
    }

    public float GetAttackRange()
    {
        return attackRange;
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    public void StopMoving()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void WalkToPlayer()
    {
        if (player == null || rb == null || isDead) return;

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
            animator.Play("Base Layer.idle");
        }
    }

    public void PlayWalk()
    {
        if (animator != null)
        {
            animator.Play("Base Layer.walk");
        }
    }

    public void PlayAttack()
    {
        if (animator != null)
        {
            animator.Play("Base Layer.attack");
        }
    }

    public void PlayDie()
    {
        if (animator != null)
        {
            animator.Play("Base Layer.die");
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

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void DestroyEnemyAfterDelay(float delay)
    {
        StartCoroutine(DestroyRoutine(delay));
    }

    private IEnumerator DestroyRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}