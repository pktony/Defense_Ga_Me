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
    public Vector3 ParticlePos { get; }

    //Laser -----
    public Transform Trans { get; }
}
