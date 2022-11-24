using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : ShieldEnemy
{
    public override void SetStats(float maxHP, float dp, float moveSpeed, float shield)
    {
        this.maxhealthPoint = maxHP;
        this.defencePower = dp;
        this.moveSpeed = moveSpeed;
        this.shield = shield;
    }
}
