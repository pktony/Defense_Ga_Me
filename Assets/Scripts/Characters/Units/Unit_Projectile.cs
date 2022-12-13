using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Projectile : Unit
{
    protected GameObject projectileObj;
    protected Projectiles bullet;

    public void InitializeProjectile(ProjectileID projectileID)
    {
        this.projectileObj =
        GameManager.Inst.ProjectileDatas[(uint)projectileID].projectilePrefab;
    }

    public override void Attack(IAttackable target)
    {
        if (target != null && !target.IsDead)
        {
            base.Attack(target);
            SpawnProjectile(target.CurrentPos);
        }
    }

    protected virtual void SpawnProjectile(Vector3 destination)
    {
        GameObject bulletObj = Instantiate(projectileObj);
        bulletObj.transform.position = transform.position;
        
        bullet = bulletObj.GetComponent<Projectiles>();
        bullet.InitializeProjectile(destination, AttackPower);
    }


    protected override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
