using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanel_Unit : InfoPanelAbs
{
    private TextMeshProUGUI unitName;
    private TextMeshProUGUI unitClass;
    private TextMeshProUGUI attackPower;
    private TextMeshProUGUI attackSpeed;
    private TextMeshProUGUI isDPPentratable;
    private TextMeshProUGUI sellPrice;

    //private Image unitImg;

    protected override void Awake()
    {
        base.Awake();
        Transform nameParent = transform.GetChild(1);
        unitName = nameParent.GetChild(0).GetComponent<TextMeshProUGUI>();
        unitClass = nameParent.GetChild(1).GetComponent<TextMeshProUGUI>();
        Transform statParent = transform.GetChild(2);
        attackPower = statParent.GetChild(0).GetComponent<TextMeshProUGUI>();
        attackSpeed = statParent.GetChild(1).GetComponent<TextMeshProUGUI>();
        isDPPentratable = statParent.GetChild(2).GetComponent<TextMeshProUGUI>();
        sellPrice = transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void SetDatas(ref Stats_Unit stats)
    {
        unitName.text = stats.name;
        unitClass.text = stats.classType.ToString();
        attackPower.text = $"Attack Power : {stats.attackPower}";
        attackSpeed.text = string.Format("Attack Speed : {0:0.00} / sec",
            1 / stats.attackCoolTime);
        isDPPentratable.text = stats.isDPPentratable ?
            "Penetrates Defence Ability" : "Normal Attack";

        sellPrice.text = "??";
    }
}
