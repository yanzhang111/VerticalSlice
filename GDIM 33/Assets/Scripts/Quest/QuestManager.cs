using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public int herbCount = 0;
    public bool questStarted = false;
    public bool attackUnlocked = false;
    public bool questCompleted = false;
    public bool secondAbilityUnlocked = false;

    public bool bossDefeated = false;
    public bool talkedToNpcAfterBoss = false;
    public bool hasKey = false;

    public TextMeshProUGUI itemText;
    public TextMeshProUGUI questText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void StartQuest()
    {
        questStarted = true;
        attackUnlocked = true;
        UpdateUI();
    }

    public void AddHerb()
    {
        if (!questStarted || questCompleted) return;

        herbCount++;
        UpdateUI();
    }

    public void CompleteQuest()
    {
        if (herbCount >= 2)
        {
            questCompleted = true;
            secondAbilityUnlocked = true;
            UpdateUI();
        }
    }

    public void BossDefeated()
    {
        bossDefeated = true;
        UpdateUI();
    }

    public void TalkToNpcAfterBoss()
    {
        talkedToNpcAfterBoss = true;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (itemText != null)
        {
            if (!questStarted || questCompleted)
            {
                itemText.text = "";
            }
            else
            {
                itemText.text = "Herb x" + herbCount;
            }
        }

        if (questText != null)
        {
            if (!questStarted)
            {
                questText.text = "Talk to the NPC";
            }
            else if (!questCompleted && herbCount < 2)
            {
                questText.text = "Collect 2 Herbs";
            }
            else if (!questCompleted && herbCount >= 2)
            {
                questText.text = "Return to NPC";
            }
            else if (questCompleted && !bossDefeated)
            {
                questText.text = "Now! Go defeat the evil Dark Lord!";
            }
            else if (bossDefeated && !hasKey)
            {
                questText.text = "Pick up the key.";
            }
            else if (bossDefeated && hasKey && !talkedToNpcAfterBoss)
            {
                questText.text = "Bring the key back to the NPC.";
            }
            else if (bossDefeated && talkedToNpcAfterBoss)
            {
                questText.text = "Use the key to open the door and escape with her!";
            }
        }
    }
}