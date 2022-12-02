using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Proejctile Unit", menuName = "ScriptableObject/Unit/Projectile", order = 1)]
public class UnitData_Projectile : UnitData
{
    public ProjectileData projectileData;
}
