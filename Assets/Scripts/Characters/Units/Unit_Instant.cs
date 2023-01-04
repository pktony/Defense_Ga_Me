using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Instant : Unit
{
    protected UnitParticleController particle;

    private WaitForSeconds attackWaitSeconds;

    protected override void Awake()
    {
        base.Awake();
        particle = GetComponentInChildren<UnitParticleController>();

        attackWaitSeconds = new WaitForSeconds(0.1f);
    }

    public override void Attack(IAttackable target)
    {
        if (!ReferenceEquals(target, null) && !target.IsDead)
        {
            base.Attack(target);
            StartCoroutine(ShootProcess(target));
        }
    }

    protected virtual IEnumerator ShootProcess(IAttackable target)
    {
        int playCount = unitStats.stats.attackNumber;
        while (playCount > 0)
        {
            if (ReferenceEquals(target, null) || !target.IsDead)
            { // Fake Null
                target.GetAttack(AttackPower);
                particle.UseParticle(target.ParticlePos);
                playCount--;
            }
            else
            {
                particle.ReturnParitcle();
                break;
            }
            yield return attackWaitSeconds;
            particle.ReturnParitcle();
        }
    }
}
