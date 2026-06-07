using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicTrigger : MonoBehaviour
{
    public static bool bossDefeated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bossDefeated)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayBossMusic();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (bossDefeated)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayBackgroundMusic();
            }
        }
    }

    public static void StopBossMusicForever()
    {
        bossDefeated = true;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayBackgroundMusic();
        }
    }
}