using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFactory : FactoryAbs_Monster<SlimeType>
{
    [SerializeField] private MonsterScriptables[] slimes;
    
    public override Enemy Create(SlimeType type)
    {
        MonsterScriptables slimeInfo = slimes[(int)type];

        Slime slime = Instantiate(slimeInfo.prefab).GetComponent<Slime>();
        slime.SetStats(slimeInfo.maxHP, slimeInfo.maxHP, slimeInfo.moveSpeed);
        slime.InitializeWaypoints(waypoints);
        return slime;
    }
}
