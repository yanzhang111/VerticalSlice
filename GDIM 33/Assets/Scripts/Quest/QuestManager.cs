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
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        if (itemText != null)
        {
            if (!questStarted)
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
            else
            {
                questText.text = "Quest Complete";
            }
        }
    }
}