using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    public bool IsSelected { get; set; }
    public int AttackPower { get; set; }

    /// <summary>
    /// 공격 함수 
    /// </summary>
    /// <param name="target">공격할 대상 </param>
    public void Attack(IAttackable target);
    public void Move(Vector3 destionation);

    /// <summary>
    /// 클릭했을 때 유닛 선택
    /// </summary>
    public bool GetSelected();
    public void UnSelect();

}
