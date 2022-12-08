using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Projectile_Initium : Unit_Projectile_Tank
{
    private int tileNumbers;
    private Vector3[] attackingTiles;

    private void Start()
    {
        attackingTiles = BoardManager.Inst.BoardTiles;
        tileNumbers = attackingTiles.Length;
    }

    protected override void SpawnProjectile(Vector3 _)
    {
        for (int i = 0; i < tileNumbers; i++)
        {
            //if (i % 2 == 0) continue;
            GameObject bulletObj = Instantiate(projectileObj);
            bulletObj.GetComponent<Projectiles_Angled>().BarrelTransform = transform;
            bulletObj.transform.position = transform.position;

            bullet = bulletObj.GetComponent<Projectiles>();
            bullet.InitializeProjectile(
                attackingTiles[i], AttackPower, true);
            Debug.Log(BoardManager.Inst.TileNames[i]);
        }
    }
}
