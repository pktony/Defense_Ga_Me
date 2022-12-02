using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Laser : Unit_Instant
{
    private Laser laser;
    private WaitForSeconds waitSeconds;
    private Transform hitParticle;

    [SerializeField] private float laserTickInterval = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        laser = GetComponentInChildren<Laser>();
        waitSeconds = new WaitForSeconds(laserTickInterval);
        hitParticle = particleParent.GetChild(0);
        hitParticle.gameObject.SetActive(false);
    }

    public override void Attack(IAttackable target)
    {
        if (target != null)
        {
            base.Attack(target);
            StartCoroutine(ShootLaser(target));
        }
    }

    private IEnumerator ShootLaser(IAttackable target)
    {
        laser.ShootLaser(target);
        hitParticle.transform.parent = target.ParticleParent;
        hitParticle.transform.position = target.CurrentPos;
        hitParticle.gameObject.SetActive(true);
        int attackCount = 0;
        while (attackCount < attackNumber)
        {
            if (target != null && !target.IsDead)
            {
                target.GetAttack(AttackPower, isDPPentratable);
                attackCount++;
            }
            else
            {
                ReturnParticle();
                break;
            }
            yield return waitSeconds;
        }
        laser.TurnoffLaser();
        ReturnParticle();
    }

    private void ReturnParticle()
    {
        hitParticle.transform.parent = this.particleParent;
        hitParticle.gameObject.SetActive(false);
    }

    protected override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
