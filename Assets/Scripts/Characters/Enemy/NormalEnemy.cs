using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    public override void SetStats(float maxHP, float dp, float moveSpeed, float _ = 0)
    {
        this.maxhealthPoint = maxHP;
        this.defencePower = dp;
        this.moveSpeed = moveSpeed;
    }
}
