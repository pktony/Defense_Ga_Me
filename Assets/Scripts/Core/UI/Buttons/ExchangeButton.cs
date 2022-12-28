using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeButton : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ExchangeUnit);
    }

    private void ExchangeUnit()
    {
        UnitManager.Inst.ExchangeUnit();
    }
}
