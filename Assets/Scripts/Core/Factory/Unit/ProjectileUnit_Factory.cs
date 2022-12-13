using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSpace;

public class ProjectileUnit_Factory : FactoryAbs_Unit<ProjectileUnitType>
{
    [SerializeField] UnitData_Projectile[] unitDatas;
    public override Unit Create(ProjectileUnitType type)
    {
        UnitData_Projectile thisUnit = unitDatas[(int)type];
        GameObject obj = Instantiate(thisUnit.unitPrefab, this.transform);
        Unit_Projectile unit = obj.GetComponent<Unit_Projectile>();

        unit.SetStats(thisUnit);
        unit.InitializeProjectile((ProjectileID)thisUnit.projectileData.projectileID);
        unit.transform.localPosition = Vector3.zero;
        return unit;
    }
}
