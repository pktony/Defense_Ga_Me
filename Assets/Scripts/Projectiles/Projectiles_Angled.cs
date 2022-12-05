using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles_Angled : Projectiles
{
    private Transform barrel;

    public Transform BarrelTransform
    {
        get => barrel;
        set => barrel = value;
    }
    
    protected virtual void Start()
    {
        Vector3 shootVector = ProjectileHelper.ShootTowards(
            barrel, destination, projectileData.flySpeed);

        rigid.AddForce(shootVector, ForceMode.VelocityChange);
    }

    protected override void Update()
    {
        transform.rotation = Quaternion.LookRotation(rigid.velocity);
        if (!isExploded)
        {
            if(transform.position.y < 0f)
            {
                Explode();
            }
        }
    }
}
