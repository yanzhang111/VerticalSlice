using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackZone : MonoBehaviour
{
    public int damage = 1;
    public float duration = 1.5f;
    public float damageInterval = 0.5f;

    private bool playerInZone = false;
    private PlayerHealth playerHealth;
    private Coroutine damageRoutine;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    public void SetDuration(float newDuration)
    {
        duration = newDuration;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            playerHealth = other.GetComponentInParent<PlayerHealth>();

            if (damageRoutine == null)
            {
                damageRoutine = StartCoroutine(DamagePlayerRoutine());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            playerHealth = null;

            if (damageRoutine != null)
            {
                StopCoroutine(damageRoutine);
                damageRoutine = null;
            }
        }
    }

    private IEnumerator DamagePlayerRoutine()
    {
        while (playerInZone)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            yield return new WaitForSeconds(damageInterval);
        }

        damageRoutine = null;
    }
}