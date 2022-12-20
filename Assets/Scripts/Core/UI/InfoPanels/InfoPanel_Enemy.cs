using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnitSpace;

public class InfoPanel_Enemy : InfoPanelAbs
{
    private TextMeshProUGUI enemyName;
    private TextMeshProUGUI hp;
    private TextMeshProUGUI shield;
    private TextMeshProUGUI dp;
    private TextMeshProUGUI moveSpeed;

    private GameObject shieldParent;

    protected override void Awake()
    {
        base.Awake();
        Transform infoParent = transform.GetChild(1);
        enemyName = infoParent.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        Transform statParent = infoParent.GetChild(1);
        hp = statParent.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        shieldParent = statParent.GetChild(1).gameObject;
        shield = statParent.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        dp = statParent.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        moveSpeed = statParent.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void SetDatas(ref Stats_Enemy stats, float currentShield, float currentHP)
    {
        enemyName.text = stats.enemyName;
        if (stats.maxShield > 0f)
        {
            shield.text = string.Format("{0:00} / {1:00}", currentShield, stats.maxShield);
            shieldParent.SetActive(true);
        }
        else
            shieldParent.SetActive(false);
        hp.text = string.Format("{0:00} / {1:00}", currentHP, stats.maxHP);
        dp.text = stats.dp.ToString();
        moveSpeed.text = stats.moveSpeed.ToString();
    }
}
