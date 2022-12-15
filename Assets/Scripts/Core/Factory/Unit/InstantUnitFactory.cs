using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSpace;

public class InstantUnitFactory : FactoryAbs_Unit<InstantUnitType>
{
    [SerializeField] private UnitData[] unitDatas;

    public override UnitStats Create(InstantUnitType type)
    {
        UnitData thisUnit = unitDatas[(int)type];
        GameObject obj = Instantiate(thisUnit.unitPrefab, this.transform);
        UnitStats unit = obj.GetComponent<UnitStats>();

        unit.SetStats(thisUnit);
        unit.transform.localPosition = Vector3.zero;
        return unit;
    }
}
