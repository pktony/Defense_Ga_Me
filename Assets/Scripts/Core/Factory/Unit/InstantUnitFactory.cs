using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSpace;

public class InstantUnitFactory : FactoryAbs_Unit<InstantUnitType>
{
    [SerializeField] private UnitData[] unitDatas;

    public override Unit Create(InstantUnitType type)
    {
        UnitData thisUnit = unitDatas[(int)type];
        GameObject obj = Instantiate(thisUnit.unitPrefab, this.transform);
        Unit unit = obj.GetComponent<Unit>();

        unit.SetStats(thisUnit.attackPower, thisUnit.attackRange, thisUnit.attackCoolTime);
        unit.transform.localPosition = Vector3.zero;
        return unit;
    }
}
