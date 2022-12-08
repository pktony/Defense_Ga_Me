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
        //Vector3 shootVector = ProjectileHelper.ShootTowards(
        //    barrel, destination, projectileData.flySpeed);
        transform.rotation = Quaternion.LookRotation(direction);
        float distance = (destination - transform.position).magnitude;
        float v0 = projectileData.flySpeed;
        float shootAngle = ProjectileHelper.CalculateElevationAngle(distance, ref v0);
        Vector3 elevation = Quaternion.AngleAxis(shootAngle, transform.right) * Vector3.up;
        float yaw = ProjectileHelper.CalculateYawAngle(transform.forward, direction);
        Vector3 velocity = Quaternion.AngleAxis(yaw, Vector3.up) * elevation * v0;
        rigid.AddForce(velocity, ForceMode.VelocityChange);
    }

    protected override void Update()
    {
        if (!isExploded)
        {
            transform.rotation = Quaternion.LookRotation(rigid.velocity);
            if(transform.position.y < 0f)
            {
                Explode();
            }
        }
    }
}
