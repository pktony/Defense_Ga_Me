using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public float HP { get; set; }
    public float MaxHP { get; }
    public float DP { get;}
    public void GetAttack(float damage, bool isDefencePenetratable = false);

    public bool IsDead { get; set; }
    public Vector3 CurrentPos { get; }
    public Transform Trans { get; }
    public Transform ParticleParent { get; }
}
