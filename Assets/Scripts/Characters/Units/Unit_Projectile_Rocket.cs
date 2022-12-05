using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Unit_Projectile_Rocket : Unit_Projectile
{
    private Transform barrelPivot;

    protected override void Awake()
    {
        base.Awake();
        Transform tower = transform.GetChild(0).GetChild(0).GetChild(0);
        barrelPivot = tower.GetChild(0);
    }

    protected override void LookTowardsTarget()
    {
        Vector3 lookDir = attackTarget.CurrentPos - barrelPivot.position;
        lookDir = lookDir.normalized;
        barrelPivot.rotation = Quaternion.Slerp(barrelPivot.rotation,
            Quaternion.LookRotation(lookDir),
            turnSpeed * Time.deltaTime);
    }

    protected override void SpawnProjectile(Vector3 destination)
    {
        GameObject bulletObj = Instantiate(projectileObj);
        bulletObj.transform.position = barrelPivot.position;

        bullet = bulletObj.GetComponent<Projectiles_Angled>();

        // -------------- ???? 왜 안뜨지 ?
        bulletObj.GetComponent<Projectiles_Angled>().BarrelTransform = barrelPivot;
        // --------------

        bullet.InitializeProjectile(destination, AttackPower, true);
    }
}
