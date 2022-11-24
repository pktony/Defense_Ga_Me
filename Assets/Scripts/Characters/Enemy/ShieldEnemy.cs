using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Enemy
{
    public override void SetStats(float maxHP, float dp, float moveSpeed, float shield = 0)
    {
        this.maxhealthPoint = maxHP;
        this.defencePower = dp;
        this.moveSpeed = moveSpeed;
        this.shield = shield;
    }

    public override void GetAttack(float damage)
    {
        if(shield > 0f)
        {// 실드가 있을 때는 실드를 깍고
            shield -= Mathf.Max(1f, damage - DP);
            if (shield < 0f)
            {// 실드보다 데미지가 쎌경우 남은 데미지를 HP로 데미지 입힘 
                damage = -shield;
            }
            else
                return;
        }
        base.GetAttack(damage);
    }
}
