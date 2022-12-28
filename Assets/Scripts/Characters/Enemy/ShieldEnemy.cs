using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Enemy
{
    private readonly float shieldRechargeInterval = 1.0f;
    private readonly float shieldRechargeAmount = 1f;
    private float shieldTimer = 0f;

    public System.Action<float, float> onShieldChange;

    public float Shield
    {
        get => enemyStats.Shield;
        set
        {
            enemyStats.Shield = Mathf.Clamp(value, 0f, enemyStats.stats.maxShield);
            onShieldChange?.Invoke(Shield, enemyStats.stats.maxShield);
        }
    }

    protected override void Start()
    {
        base.Start();
        Shield = enemyStats.stats.maxShield;
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

    public override void GetAttack(float damage, bool isDPPenetratable = false)
    {
        if(Shield > 0f)
        {// 실드가 있을 때는 실드를 깍고
            if (!isDPPenetratable)
                Shield -= Mathf.Max(1f, damage - DP);
            else
                Shield -= Mathf.Max(1f, damage);

            if (Shield < 0f)
                {// 실드보다 데미지가 쎌경우 남은 데미지를 HP로 데미지 입힘 
                    damage = -Shield;
                }
            else
                return;
        }
        base.GetAttack(damage);
    }
}
