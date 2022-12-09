using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Enemy
{
    private readonly float shieldRechargeInterval = 1.0f;
    private readonly float shieldRechargeAmount = 1f;
    private float shieldTimer = 0f;

    private float maxShield;

    public System.Action<float, float> onShieldChange;

    public float Shield
    {
        get => shield;
        set
        {
            shield = Mathf.Clamp(value, 0f, maxShield);
            onShieldChange?.Invoke(shield, maxShield);
        }
    }

    protected override void Start()
    {
        base.Start();
        Shield = maxShield;
    }

    private void Update()
    {
        if(!IsDead)
        {
            shieldTimer += Time.deltaTime;
            if(shieldTimer > shieldRechargeInterval)
            {
                Shield += shieldRechargeAmount;
            }
        }
    }

    public override void SetStats(float maxHP, float dp, float moveSpeed, float shield = 0)
    {
        this.maxhealthPoint = maxHP;
        this.defencePower = dp;
        this.moveSpeed = moveSpeed;
        this.maxShield = shield;
    }

    public override void GetAttack(float damage, bool isDPPenetratable = false)
    {
        if(shield > 0f)
        {// 실드가 있을 때는 실드를 깍고
            if (!isDPPenetratable)
                shield -= Mathf.Max(1f, damage - DP);
            else
                shield -= Mathf.Max(1f, damage);

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
