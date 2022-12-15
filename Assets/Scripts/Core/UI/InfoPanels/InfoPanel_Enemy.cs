using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnitSpace;

public class InfoPanel_Enemy : InfoPanelAbs
{
    private TextMeshProUGUI enemyName;
    private TextMeshProUGUI shield;
    private TextMeshProUGUI hp;
    private TextMeshProUGUI dp;
    private TextMeshProUGUI moveSpeed;

    protected override void Awake()
    {
        base.Awake();
        enemyName = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        Transform statParent = transform.GetChild(2);
        shield = statParent.GetChild(0).GetComponent<TextMeshProUGUI>();
        hp = statParent.GetChild(1).GetComponent<TextMeshProUGUI>();
        dp = statParent.GetChild(2).GetComponent<TextMeshProUGUI>();
        moveSpeed = statParent.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    public void SetDatas(ref Stats_Enemy stats, float currentShield, float currentHP)
    {
        enemyName.text = stats.enemyName;
        shield.text = string.Format("{0:00} / {1:00}", currentShield, stats.maxShield);
        hp.text = string.Format("{0:00} / {1:00}", currentHP, stats.maxHP);
        dp.text = stats.dp.ToString();
        moveSpeed.text = stats.moveSpeed.ToString();
    }
}
