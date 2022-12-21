using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Instant : Unit
{
    protected UnitParticleController particle;

    private WaitForSeconds attackWaitSeconds;
    [SerializeField] protected int attackNumber = 3;

    protected override void Awake()
    {
        base.Awake();
        particle = GetComponentInChildren<UnitParticleController>();

        attackWaitSeconds = new WaitForSeconds(0.1f);
    }

    public override void Attack(IAttackable target)
    {
        if (target != null)
        {
            base.Attack(target);
            StartCoroutine(ShootProcess(target));
        }
    }

    protected virtual IEnumerator ShootProcess(IAttackable target)
    {
        int playCount = attackNumber;
        while (playCount > 0)
        {
            if (ReferenceEquals(target, null) || !target.IsDead)
            { // Fake Null
                target.GetAttack(AttackPower);
                particle.UseParticle(target.ParticlePos);
                particle.ReturnParitcle();
                playCount--;
            }
            else
            {
                particle.ReturnParitcle();
                break;
            }
            yield return attackWaitSeconds;
        }
    }

    protected override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
