using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public float speed = 5f;
public float lifeTime = 1f;

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
}