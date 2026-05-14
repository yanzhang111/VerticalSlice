using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public bool playerInRange = false;

    private bool isTalking = false;
    private int dialogueIndex = 0;

    private string[] introDialogue =
    {
        "Oh, lost traveler, why are you here? This place is dangerous.",
        "What? You got lost here and you do not even have the power to protect yourself?",
        "If you want to leave this place, you must defeat the Dark Lord. I am too weak to defeat it, but maybe you can.",
        "I can heal you, but I was cursed by this forest too. I may only be able to restore part of your power for now. If you want to defeat the Dark Lord, you will need all of your strength.",
        "How about this? Go deep into the forest and find 2 herbs ( Purple color) for me. If you break my curse, I can restore all of your power. Then you can defeat the Dark Lord, and we can escape together."
    };

    void Start()
    {
        if (dialogueText != null)
        {
            dialogueText.text = "";
        }
    }

    public void AdvanceDialogue()
    {
        Debug.Log("AdvanceDialogue called");

        if (!playerInRange || QuestManager.instance == null)
            return;

        if (!QuestManager.instance.questStarted)
        {
            if (!isTalking)
            {
                isTalking = true;
                dialogueIndex = 0;
                ShowDialogue(introDialogue[dialogueIndex]);
            }
            else
            {
                dialogueIndex++;

                if (dialogueIndex < introDialogue.Length)
                {
                    ShowDialogue(introDialogue[dialogueIndex]);
                }
                else
                {
                    isTalking = false;
                    dialogueIndex = 0;
                    QuestManager.instance.StartQuest();

                    if (dialogueText != null)
                    {
                        dialogueText.text = "";
                    }
                }
            }

            return;
        }

        if (!QuestManager.instance.questCompleted && QuestManager.instance.herbCount >= 2)
        {
            QuestManager.instance.CompleteQuest();
            ShowDialogue("Thank you. The curse is gone. Your full power has returned. Now, go defeat the evil Dark Lord!(Now can press the K to use Fire Tornado)");
        }
        else if (!QuestManager.instance.questCompleted)
        {
            ShowDialogue("Please find 2 herbs for me. They should be deeper in the forest.");
        }
        else if (QuestManager.instance.questCompleted && !QuestManager.instance.bossDefeated)
        {
            ShowDialogue("Go defeat the Dark Lord. Only then can we truly escape. (Legend has it that it lives in the farthest left corner of the deepest part of the forest.)");
        }
        else if (QuestManager.instance.bossDefeated && !QuestManager.instance.talkedToNpcAfterBoss)
        {
            QuestManager.instance.TalkToNpcAfterBoss();
            ShowDialogue("You really did it! Oh my gosh, I never thought this would happen! Hurry, go open the door! We can finally go home!");
        }
        else
        {
            ShowDialogue("Please use the key to open the door. We are so close to going home.");
        }
    }

    void ShowDialogue(string message)
    {
        if (dialogueText != null)
        {
            dialogueText.text = message;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered NPC range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            isTalking = false;
            dialogueIndex = 0;
            Debug.Log("Player left NPC range");

            if (dialogueText != null)
            {
                dialogueText.text = "";
            }
        }
    }
}