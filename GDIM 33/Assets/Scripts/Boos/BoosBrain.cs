using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossBrain : MonoBehaviour
{
    public Transform player;

    public float detectRange = 8f;
    public float phase1AttackCooldown = 2f;

    public Transform point1;
    public Transform point2;

    public float teleportOutWait = 2f;
    public float teleportInWait = 2f;
    public float attack2Wait = 2.5f;
    public float phase2Interval = 0.5f;
    public int attacksPerSpot = 3;

    public bool phaseTwo = false;
    public bool isDead = false;

    private Animator animator;
    private Coroutine phaseOneRoutine;
    private Coroutine phaseTwoRoutine;
    private bool usePoint1Next = true;
    private float lastPhase1AttackTime = -999f;

    public GameObject keyPrefab;
    public float deathDelay = 1.5f;
    public Transform keyDropPoint;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (animator != null)
        {
            animator.Play("Base Layer.idle");
        }

        phaseOneRoutine = StartCoroutine(PhaseOneLoop());
    }

    private IEnumerator PhaseOneLoop()
    {
        while (!isDead && !phaseTwo)
        {
            if (player != null)
            {
                float distance = Vector2.Distance(transform.position, player.position);

                if (distance <= detectRange)
                {
                    if (Time.time >= lastPhase1AttackTime + phase1AttackCooldown)
                    {
                        lastPhase1AttackTime = Time.time;

                        if (animator != null)
                        {
                            animator.Play("Base Layer.attack5");
                        }
                    }
                }
                else
                {
                    if (animator != null)
                    {
                        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
                        if (!state.IsName("idle"))
                        {
                            animator.Play("Base Layer.idle");
                        }
                    }
                }
            }

            yield return null;
        }
    }

    public void EnterPhaseTwo()
    {
        if (phaseTwo || isDead) return;

        phaseTwo = true;

        if (phaseOneRoutine != null)
        {
            StopCoroutine(phaseOneRoutine);
            phaseOneRoutine = null;
        }

        phaseTwoRoutine = StartCoroutine(PhaseTwoLoop());
    }

    private IEnumerator PhaseTwoLoop()
    {
        while (!isDead)
        {
            Transform targetPoint = usePoint1Next ? point1 : point2;
            usePoint1Next = !usePoint1Next;

            if (animator != null)
            {
                animator.Play("Base Layer.teleport out");
            }

            yield return new WaitForSeconds(teleportOutWait);

            if (targetPoint != null)
            {
                transform.position = targetPoint.position;
            }

            if (animator != null)
            {
                animator.Play("Base Layer.teleport in");
            }

            yield return new WaitForSeconds(teleportInWait);

            for (int i = 0; i < attacksPerSpot; i++)
            {
                if (isDead) yield break;

                if (animator != null)
                {
                    animator.Play("Base Layer.attack2");
                }

                yield return new WaitForSeconds(attack2Wait);
                yield return new WaitForSeconds(phase2Interval);
            }
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        if (phaseOneRoutine != null)
        {
            StopCoroutine(phaseOneRoutine);
            phaseOneRoutine = null;
        }

        if (phaseTwoRoutine != null)
        {
            StopCoroutine(phaseTwoRoutine);
            phaseTwoRoutine = null;
        }

        if (QuestManager.instance != null)
        {
            QuestManager.instance.BossDefeated();
        }

        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        if (animator != null)
        {
            animator.Play("Base Layer.death");
        }

        yield return new WaitForSeconds(deathDelay);

        if (keyPrefab != null)
        {
            Vector3 spawnPos = transform.position;

            if (keyDropPoint != null)
            {
                spawnPos = keyDropPoint.position;
            }

            Instantiate(keyPrefab, spawnPos, Quaternion.identity);
        }

        Destroy(gameObject);
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

    public bool GetPhaseTwo()
    {
        return phaseTwo;
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}