using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : Unit
{
    private ParticleSystem attackParticle;

    private WaitForSeconds particleWaitSeconds;
    [SerializeField] int particleRepeatNumber = 3;

    protected override void Awake()
    {
        base.Awake();
        attackParticle = GetComponentInChildren<ParticleSystem>();
        attackParticle.gameObject.SetActive(false);
        particleWaitSeconds = new WaitForSeconds(0.1f);
    }

    public override void Attack(IAttackable target)
    {
        if (target != null)
        {
            base.Attack(target);
            attackParticle.transform.position = target.CurrentPos + Vector3.up * 1f;
            StartCoroutine(PlayParticle());
        }
    }

    private IEnumerator PlayParticle()
    {
        int playCount = particleRepeatNumber;
        while (playCount > 0)
        {
            attackParticle.gameObject.SetActive(true);
            yield return particleWaitSeconds;
            attackParticle.gameObject.SetActive(false);
            playCount--;
        }
    }

    protected override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
