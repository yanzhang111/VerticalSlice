using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 1f;
    public int damage = 1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    public void Launch(float direction)
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(direction * speed, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile hit: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player tag detected");

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                Debug.Log("PlayerHealth found");
                playerHealth.TakeDamage(damage);
            }
            else
            {
                Debug.Log("PlayerHealth NOT found");
            }

            Destroy(gameObject);
        }
    }
}