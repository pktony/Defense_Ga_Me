using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Angled_Mine : Projectiles_Angled
{
    [SerializeField] private float rotationSpeed = 300f;
    protected override void Update()
    {
        if (!isExploded)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * transform.right);
            if (transform.position.y < 0f)
            {
                transform.rotation = Quaternion.identity;
                Explode();
            }
        }
    }
}
