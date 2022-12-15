using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    public int AttackPower { get; set; }

    public UnitSpace.UnitClasses ClassType { get; }

    /// <summary>
    /// 공격 함수 
    /// </summary>
    /// <param name="target">공격할 대상 </param>
    public void Attack(IAttackable target);
    public void Move(Vector3 destionation);
}
