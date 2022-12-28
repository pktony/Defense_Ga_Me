using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIs_Shield : EnemyUIs
{
    Slider shieldBar;


    protected override void Awake()
    {
        base.Awake();
        shieldBar = transform.GetChild(1).GetComponent<Slider>();

        ShieldEnemy shield = enemy as ShieldEnemy;
        shield.onShieldChange += RefreshShieldBar;
    }

    private void RefreshShieldBar(float shield, float maxShield)
    {
        shieldBar.value = shield / maxShield;
    }
}
