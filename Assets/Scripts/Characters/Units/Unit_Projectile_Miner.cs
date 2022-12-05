using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Projectile_Miner : Unit_Projectile
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void LookTowardsTarget()
    {
        Vector3 lookDir = attackTarget.CurrentPos - transform.position;
        lookDir = lookDir.normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(lookDir),
            turnSpeed * Time.deltaTime);
    }

    protected override void SpawnProjectile(Vector3 destination)
    {
        GameObject bulletObj = Instantiate(projectileObj);
        bulletObj.transform.position = transform.position;

        bullet = bulletObj.GetComponent<Projectiles_Angled>();

        // -------------- ???? 왜 안뜨지 ?
        bulletObj.GetComponent<Projectiles_Angled>().BarrelTransform = transform;
        // --------------

        bullet.InitializeProjectile(destination, AttackPower, true);
    }
}
