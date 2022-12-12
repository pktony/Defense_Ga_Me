using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameManager gameManager;

    TextMeshProUGUI roundText;
    TextMeshProUGUI timeText;
    TextMeshProUGUI goldText;
    TextMeshProUGUI enemyText;
    TextMeshProUGUI killText;

    private void Awake()
    {
        roundText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        timeText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        goldText = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        enemyText = transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        killText = transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        gameManager = GameManager.Inst;
        gameManager.onRoundChange += RefreshRound;
        gameManager.enemyCount.onEnemyCountChange += RefreshEnemyCount;
        gameManager.killCount.onEnemykill += RefreshKillCount;
        gameManager.golds.onGoldChange += RefreshGoldCount;
        gameManager.onTimeChange += RefreshTime;
    }

    private void RefreshEnemyCount(int count, int maxRound)
    {
        enemyText.text = $"{count} / {maxRound}";
    }

    private void RefreshKillCount(int count, int rewardedKill)
    {
        killText.text = $"{count} / {rewardedKill}";
    }

    private void RefreshTime(float time)
    {
        float minute = (int)(time / 60f);
        float second = (int)(time % 60f);
        //timeText.text = minute.ToString("D2") + second.ToString("D2");
        timeText.text = $"{minute} : {second}";
    }

    private void RefreshRound(int round)
    {
        roundText.text = $"Round {round}";
    }

    private void RefreshGoldCount(int gold)
    {
        goldText.text = gold.ToString();
    }
}
