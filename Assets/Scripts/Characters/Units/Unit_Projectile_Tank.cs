using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Projectile_Tank : Unit_Projectile
{
    private Transform barrelPivot;

    protected override void Awake()
    {
        base.Awake();
        barrelPivot = transform.GetChild(0).GetChild(0);
    }

    protected override void LookTowardsTarget()
    {
        if (!attackTarget.IsDead && attackTarget != null)
        {
            Vector3 lookDir = attackTarget.CurrentPos - barrelPivot.position;
            lookDir = lookDir.normalized;
            barrelPivot.rotation = Quaternion.Slerp(barrelPivot.rotation,
                Quaternion.LookRotation(lookDir),
                turnSpeed * Time.deltaTime);
        }
    }
}
