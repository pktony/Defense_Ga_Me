using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Laser : Unit_Instant
{
    private Laser laser;
    private WaitForSeconds waitSeconds;

    [SerializeField] private float laserTickInterval = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        laser = GetComponentInChildren<Laser>();
        waitSeconds = new WaitForSeconds(laserTickInterval);
    }

    protected override IEnumerator ShootProcess(IAttackable target)
    {
        laser.ShootLaser(target);
        int attackCount = 0;
        while (attackCount < attackNumber)
        {
            if (target != null && !target.IsDead)
            {
                particle.UseParticle(target.ParticlePos);
                target.GetAttack(AttackPower, unitStats.IsDPPenetratable);
                attackCount++;
            }
            else
            {
                particle.ReturnParitcle();
                break;
            }
            yield return waitSeconds;
        }
        laser.TurnoffLaser();
        particle.ReturnParitcle();
    }
}
