using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Projectile_Miner : Unit_Projectile
{
    protected override void SpawnProjectile(Vector3 destination)
    {
        GameObject bulletObj = Instantiate(projectileObj);
        bulletObj.transform.position = transform.position;
        bulletObj.GetComponent<Projectiles_Angled>().BarrelTransform = transform;

        bullet = bulletObj.GetComponent<Projectiles_Angled>();
        bullet.InitializeProjectile(destination, AttackPower, true);
    }
}
