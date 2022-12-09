using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : FactoryAbs_Monster<Monsters>
{
    [SerializeField] protected MonsterScriptables[] monsterScriptables;

    public override Enemy Create(Monsters type)
    {
        MonsterScriptables monsterInfo = monsterScriptables[(int)type - 1];

        Enemy enemy = null;

        if(monsterInfo.shield > 0f)
        {
            enemy = Instantiate(monsterInfo.prefab).GetComponent<ShieldEnemy>();
            enemy = enemy as ShieldEnemy;
        }
        else
        {
            enemy = Instantiate(monsterInfo.prefab).GetComponent<NormalEnemy>();
            enemy = enemy as NormalEnemy;
        }
        enemy.SetStats(monsterInfo.maxHP, monsterInfo.dp, monsterInfo.moveSpeed, monsterInfo.shield);
        enemy.InitializeWaypoints(waypoints);
        
        return enemy;
    }
}
