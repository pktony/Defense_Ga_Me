using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI에 정보를 넘겨주기 위해서 여러가지 타입을 넘겨줘야 한다. 
/// </summary>
public struct Stats
{
    public string name;
    public int attackPower;
    public float attackCoolTime;
    public float attackRange;

    public Stats(string name, int AP, float attackSpeed, float attackRange)
    {
        this.name = name;
        this.attackPower = AP;
        this.attackCoolTime = attackSpeed;
        this.attackRange = attackRange;
    }

    // 구조체는 DEFAULT 생성자를 만들 수 없다
    //public Stats()
    //{

    //}
}
