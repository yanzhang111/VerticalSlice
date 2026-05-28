using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingDialogue : MonoBehaviour
{
    public GameObject ending;
    public TextMeshProUGUI endingText;

    public string[] dialogueLines;

    private int currentLine = 0;
    private bool isEndingActive = false;

    void Start()
    {
        if (ending != null)
        {
            ending.SetActive(false);
        }

        if (endingText != null)
        {
            endingText.text = "";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartEnding();
        }

        if (isEndingActive && Input.GetKeyDown(KeyCode.E))
        {
            currentLine++;

            if (currentLine < dialogueLines.Length)
            {
                endingText.text = dialogueLines[currentLine];
            }
            else
            {
                EndGame();
            }
        }
    }

    public void StartEnding()
    {
        if (ending != null)
        {
            ending.SetActive(true);
        }

        isEndingActive = true;
        currentLine = 0;

        if (endingText != null && dialogueLines.Length > 0)
        {
            endingText.text = dialogueLines[0];
        }
    }

    void EndGame()
    {
        isEndingActive = false;

        if (endingText != null)
        {
            endingText.text = "The End";
        }

        Time.timeScale = 0f;
    }
}