using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject winPanel;
    public Player player;
    public EndingDialogue endingDialogue;

    private bool playerInRange = false;
    private bool isOpened = false;
    private Coroutine messageRoutine;

    private void Start()
    {
        if (dialogueText != null)
        {
            dialogueText.text = "";
        }

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isOpened)
        {
            if (QuestManager.instance != null && QuestManager.instance.hasKey && QuestManager.instance.talkedToNpcAfterBoss)
            {
                OpenDoor();
            }
            else
            {
                ShowTemporaryMessage("The door is locked. I need the key first.", 2f);
            }
        }
    }

    void OpenDoor()
    {
        isOpened = true;

        if (player != null)
        {
            player.enabled = false;
        }

        if (dialogueText != null)
        {
            dialogueText.text = "";
        }

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        gameObject.SetActive(false);

        if (endingDialogue != null)
        {
            endingDialogue.StartEnding();
        }
    }

    void ShowTemporaryMessage(string message, float duration)
    {
        if (messageRoutine != null)
        {
            StopCoroutine(messageRoutine);
        }

        messageRoutine = StartCoroutine(TemporaryMessageRoutine(message, duration));
    }

    IEnumerator TemporaryMessageRoutine(string message, float duration)
    {
        if (dialogueText != null)
        {
            dialogueText.text = message;
        }

        yield return new WaitForSeconds(duration);

        if (!isOpened && dialogueText != null)
        {
            dialogueText.text = "";
        }

        messageRoutine = null;
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

            if (!isOpened && dialogueText != null)
            {
                dialogueText.text = "";
            }
        }
    }
}