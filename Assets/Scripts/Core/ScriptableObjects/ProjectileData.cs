using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "ScriptableObject/Projectile Data", order = 2)]
public class ProjectileData : ScriptableObject
{
    public uint projectileID;
    public GameObject projectilePrefab;

    public float flySpeed = 10f;
}
