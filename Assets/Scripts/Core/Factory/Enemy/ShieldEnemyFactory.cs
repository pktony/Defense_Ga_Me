using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyFactory : FactoryAbs_Monster<ShieldEnemyType>
{
    [SerializeField] protected ShieldMonsterScriptables[] shieldMonsters;

    public override Enemy Create(ShieldEnemyType type)
    {
        ShieldMonsterScriptables monsterInfo = shieldMonsters[(int)type];

        ShieldEnemy enemy = Instantiate(monsterInfo.prefab).GetComponent<ShieldEnemy>();
        enemy.SetStats(monsterInfo.maxHP, monsterInfo.dp, monsterInfo.moveSpeed, monsterInfo.shield);
        enemy.InitializeWaypoints(waypoints);
        return enemy;
    }
}
