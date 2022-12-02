using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : FactoryAbs_Monster<BossType>
{
    [SerializeField] protected BossScriptables[] bosses;

    public override Enemy Create(BossType type)
    {
        BossScriptables bossInfo = bosses[(int)type];

        Boss boss = Instantiate(bossInfo.prefab).GetComponent<Boss>();
        boss.SetStats(bossInfo.maxHP, bossInfo.dp, bossInfo.moveSpeed, bossInfo.shield);
        boss.InitializeWaypoints(waypoints);
        return boss;
    }
}
