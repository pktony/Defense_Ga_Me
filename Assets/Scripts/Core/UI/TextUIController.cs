using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UIs;

public class TextUIController : MonoBehaviour
{
    private GameManager gameManager;

    TextMeshProUGUI roundText;
    TextMeshProUGUI timeText;
    TextMeshProUGUI goldText;
    TextMeshProUGUI enemyText;
    TextMeshProUGUI killText;

    private UI_PopupText popupText;

    private float currentGold = 0;
    private int finalGold = 999;

    [SerializeField] private float TextSmoothness = 10f;

    public UI_PopupText PopupText => popupText;

    #region UNITY EVENT 함수 ####################################################
    private void Awake()
    {
        roundText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        timeText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        goldText = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        enemyText = transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        killText = transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>();

        GetComponent<Canvas>().worldCamera = Camera.main;
        popupText = transform.GetChild(5).GetComponent<UI_PopupText>();
    }

    private void Update()
    {
         currentGold = Mathf.Lerp(currentGold, finalGold, TextSmoothness * Time.deltaTime);
         goldText.text = currentGold.ToString("0");
    }
    #endregion

    /// <summary>
    /// UI 관련 델리게이트 등록 
    /// </summary>
    public void InitializeUIs()
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
        finalGold = gold;
        //goldText.text = tempGold.ToString();
    }
}
