using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSpace;

public class ProjectileUnit_Factory : FactoryAbs_Unit<ProjectileUnitType>
{
    [SerializeField] UnitData_Projectile[] unitDatas;
    public override UnitStats Create(ProjectileUnitType type)
    {
        UnitData_Projectile thisUnit = unitDatas[(int)type];
        GameObject obj = Instantiate(thisUnit.unitPrefab, this.transform);
        UnitStats unitStats = obj.GetComponent<UnitStats>();
        unitStats.SetStats(thisUnit);
        unitStats.transform.localPosition = Vector3.zero;

        Unit_Projectile unit = obj.GetComponent<Unit_Projectile>();
        unit.InitializeProjectile((ProjectileID)thisUnit.projectileData.projectileID);

        return unitStats;
    }
}
