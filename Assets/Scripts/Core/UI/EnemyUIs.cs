using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIs : MonoBehaviour
{
    protected Enemy enemy;
    Slider hpBar;

    protected virtual void Awake()
    {
        hpBar = transform.GetChild(0).GetComponent<Slider>();

        enemy = GetComponentInParent<Enemy>();
        enemy.onHealthChange += RefreshHPBar;
    }

    private void RefreshHPBar(float hp, float maxHP)
    {
        hpBar.value = hp / maxHP;
    }
}
