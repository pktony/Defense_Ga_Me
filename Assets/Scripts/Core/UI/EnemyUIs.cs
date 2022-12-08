using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIs : MonoBehaviour
{
    Enemy enemy;
    Slider hpBar;

    private void Awake()
    {
        hpBar = transform.GetChild(0).GetComponent<Slider>();

        enemy = GetComponentInParent<Enemy>();
        enemy.onHealthChange += RefreshHPBar;
    }

    void RefreshHPBar(float hp, float maxHP)
    {
        hpBar.value = hp / maxHP;
    }
}
