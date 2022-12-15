using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : FactoryAbs_Monster<Monsters>
{
    [SerializeField] protected MonsterScriptables[] monsterScriptables;

    public override Enemy Create(Monsters type)
    {
        MonsterScriptables monsterInfo = monsterScriptables[(int)type - 1];

        EnemyStats enemyStats;

        enemyStats = Instantiate(monsterInfo.prefab).GetComponent<EnemyStats>();
        enemyStats.SetStats(monsterInfo);

        Enemy enemy = enemyStats.GetComponent<Enemy>();
        enemy.InitializeWaypoints(waypoints);
        
        return enemy;
    }
}
