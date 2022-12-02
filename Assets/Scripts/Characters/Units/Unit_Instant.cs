using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Instant : Unit
{
    protected Transform particleParent;
    private ParticleSystem attackParticle;

    private WaitForSeconds attackWaitSeconds;
    [SerializeField] protected int attackNumber = 3;

    protected override void Awake()
    {
        base.Awake();
        particleParent = transform.GetChild(2);
        attackParticle = particleParent.GetChild(0).GetComponent<ParticleSystem>();
        attackParticle.gameObject.SetActive(false);
        attackWaitSeconds = new WaitForSeconds(0.1f);
    }

    public override void Attack(IAttackable target)
    {
        if (target != null)
        {
            base.Attack(target);
            StartCoroutine(PlayParticle(target));
        }
    }

    private IEnumerator PlayParticle(IAttackable target)
    {
        int playCount = attackNumber;
        attackParticle.transform.parent = attackTarget.ParticleParent;
        while (playCount > 0)
        {
            target.GetAttack(AttackPower);
            attackParticle.transform.position = target.CurrentPos + Vector3.up * 1f;
            attackParticle.gameObject.SetActive(true);
            yield return attackWaitSeconds;
            attackParticle.gameObject.SetActive(false);
            playCount--;
        }
        attackParticle.transform.parent = particleParent ;
    }

    protected override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
