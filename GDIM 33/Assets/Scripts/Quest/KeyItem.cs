using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public enum ObjectType
    {
        Key,
        Door
    }

    [Header("Object Type")]
    public ObjectType objectType;

    [Header("Door Materials")]
    public Material normalMaterial;
    public Material glowMaterial;

    private bool playerInRange = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        if (objectType == ObjectType.Door && spriteRenderer != null && normalMaterial != null)
        {
            spriteRenderer.material = normalMaterial;
        }
    }

    private void Update()
    {
        if (objectType == ObjectType.Key)
        {
            HandleKeyPickup();
        }

        if (objectType == ObjectType.Door)
        {
            HandleDoorGlow();
        }
    }

    private void HandleKeyPickup()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (QuestManager.instance != null)
            {
                QuestManager.instance.hasKey = true;
                QuestManager.instance.UpdateUI();
            }

            Destroy(gameObject);
        }
    }

    private void HandleDoorGlow()
    {
        if (QuestManager.instance == null || spriteRenderer == null)
        {
            return;
        }

        if (playerInRange && QuestManager.instance.hasKey)
        {
            if (glowMaterial != null)
            {
                spriteRenderer.material = glowMaterial;
            }
        }
        else
        {
            if (normalMaterial != null)
            {
                spriteRenderer.material = normalMaterial;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}