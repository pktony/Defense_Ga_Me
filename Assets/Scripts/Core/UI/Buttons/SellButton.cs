using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SellUnit);
    }

    private void SellUnit()
    {
        UnitManager.Inst.SellSelectedUnit();
    }
}
