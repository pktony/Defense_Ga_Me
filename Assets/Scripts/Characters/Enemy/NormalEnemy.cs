using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    public override void SetStats(MonsterScriptables data)
    {
        enemyStats.stats = new Stats_Enemy(data.name, data.maxHP, data.shield,
            data.moveSpeed, data.dp);
        HP = enemyStats.stats.maxHP;
    }
}
