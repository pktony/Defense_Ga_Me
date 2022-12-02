using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Factory : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Inst;
    }

    public GameObject MakeProjectile(ProjectileID id)
    {
        GameObject obj =
            Instantiate(gameManager.ProjectileDatas[(uint)id].projectilePrefab);
        return obj;
    }

    public GameObject MakeProjectile(ProjectileID id, Vector3 position)
    {
        GameObject obj = MakeProjectile(id);
        obj.transform.position = position;
        return obj;
    }
}
