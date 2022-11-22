using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public float HP { get; set; }
    public float MaxHP { get; }
    public float DP { get;}
    public void GetAttack(float damage);

    public Vector3 CurrentPos { get; }
}
