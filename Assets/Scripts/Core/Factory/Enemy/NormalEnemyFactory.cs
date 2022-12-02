using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyFactory : FactoryAbs_Monster<NormalEnemyType>
{
    [SerializeField] protected MonsterScriptables[] normalMonsters;

    public override Enemy Create(NormalEnemyType type)
    {
        MonsterScriptables monsterInfo = normalMonsters[(int)type];

        NormalEnemy enemy = Instantiate(monsterInfo.prefab).GetComponent<NormalEnemy>();
        enemy.SetStats(monsterInfo.maxHP, monsterInfo.dp, monsterInfo.moveSpeed);
        enemy.InitializeWaypoints(waypoints);
        return enemy;
    }
}
