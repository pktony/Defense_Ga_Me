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
    private Image DPPenetrate;
    private TextMeshProUGUI sellPrice;

    //private Image unitImg;

    protected override void Awake()
    {
        base.Awake();
        Transform infoParent = transform.GetChild(1);
        Transform nameParent = infoParent.GetChild(0);
        unitName = nameParent.GetChild(0).GetComponent<TextMeshProUGUI>();
        unitClass = nameParent.GetChild(1).GetComponent<TextMeshProUGUI>();
        Transform statParent = infoParent.GetChild(1);
        attackPower = statParent.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        attackSpeed = statParent.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        DPPenetrate = statParent.GetChild(2).GetChild(0).GetComponent<Image>();
        sellPrice = infoParent.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void SetDatas(ref Stats_Unit stats)
    {
        unitName.text = stats.name;
        unitClass.text = stats.classType.ToString();
        attackPower.text = stats.attackPower.ToString();
        attackSpeed.text = string.Format("{0:0.00} / sec",
            1 / stats.attackCoolTime);
        DPPenetrate.color = stats.isDPPentratable ? Color.white : Color.clear;

        sellPrice.text = "??";
    }
}
