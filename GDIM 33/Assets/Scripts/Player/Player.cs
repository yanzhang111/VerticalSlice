using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Basic Attack")]
    public Transform attackPoint;
    public float attackRadius = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 1;

    [Header("Fire Storm")]
    public float fireStormRadius = 1.5f;
    public int fireStormDamage = 2;
    public LayerMask fireStormTargetLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerHealth playerHealth;

    private bool isGrounded;
    private float moveInput;
    private Vector3 originalScale;

    private float jumpStartTime;
    public float jumpGroundCheckDelay = 0.15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (playerHealth != null && playerHealth.isDead)
        {
            return;
        }

        moveInput = Input.GetAxisRaw("Horizontal");

        bool canCheckGround = Time.time > jumpStartTime + jumpGroundCheckDelay;

        if (canCheckGround)
        {
            isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpStartTime = Time.time;
            isGrounded = false;

            if (animator != null)
            {
                animator.SetTrigger("jump");
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (animator != null && QuestManager.instance != null && QuestManager.instance.attackUnlocked)
            {
                animator.SetTrigger("attack");
                Attack();
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (animator != null && QuestManager.instance != null && QuestManager.instance.secondAbilityUnlocked)
            {
                animator.SetTrigger("skill");
                UseFireStorm();
            }
        }

        if (animator != null)
        {
            animator.SetBool("isRun", moveInput != 0);
            animator.SetBool("isGrounded", isGrounded);
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(originalScale.x),
                originalScale.y,
                originalScale.z
            );
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(originalScale.x),
                originalScale.y,
                originalScale.z
            );
        }
    }

    void FixedUpdate()
    {
        if (playerHealth != null && playerHealth.isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRadius,
            enemyLayer
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    void UseFireStorm()
    {
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(
            attackPoint.position,
            fireStormRadius,
            fireStormTargetLayer
        );

        foreach (Collider2D target in hitTargets)
        {
            EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(fireStormDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(attackPoint.position, fireStormRadius);
        }
    }
}