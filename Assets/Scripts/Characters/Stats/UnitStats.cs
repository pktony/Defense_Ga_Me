using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : CharacterStats
{
    public Stats_Unit stats;

    [SerializeField] protected bool isDPPentratable = false;

    public bool IsDPPenetratable => isDPPentratable;

    public override bool IsSelected
    {
        get => isSelected;
        set
        {
            if (!isSelected)
            {// 선택되지 않았으면
                selectionCircle.SetActive(true);
                UIManager.Inst.InfoPanels.UnitPanel.SetDatas(ref stats);
                UIManager.Inst.InfoPanels.ShowUnitPanel();
                //Debug.Log("selected");
            }
            else
            {// 이미 선택 됐으면
                selectionCircle.SetActive(false);
                UIManager.Inst.InfoPanels.HideAllPanels();
            }
            isSelected = value;
        }
    }

    public void SetStats(UnitData data)
    {
        stats = new Stats_Unit(data.unitName, data.classType, data.type,
            data.attackPower, data.attackNumber, data.attackCoolTime,
            data.attackRange, isDPPentratable) ;
    }
}
