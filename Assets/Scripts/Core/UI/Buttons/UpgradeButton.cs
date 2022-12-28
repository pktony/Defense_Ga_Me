using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(UpgradeUnit);
    }

    private void UpgradeUnit()
    {
        UnitManager.Inst.UpgradeUnit();
    }
}
