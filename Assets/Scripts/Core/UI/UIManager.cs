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

    private void Awake()
    {
        roundText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        timeText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        goldText = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        enemyText = transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        gameManager = GameManager.Inst;
        gameManager.onRoundChange += RefreshRound;
        gameManager.onEnemyCountChange += RefreshEnemyCount;
        gameManager.onTimeChange += RefreshTime;
    }

    private void RefreshEnemyCount(int count)
    {
        enemyText.text = $"{count} / {GameManager.MAX_ENEMYCOUNT}";
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
}
