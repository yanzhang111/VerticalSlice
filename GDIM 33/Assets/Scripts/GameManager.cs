using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int herbCount = 0;
    public TextMeshProUGUI itemText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddHerb()
    {
        herbCount++;
        UpdateUI();
    }

    public void UpdateUI()
    {
        itemText.text = "Herb x" + herbCount;
    }
}