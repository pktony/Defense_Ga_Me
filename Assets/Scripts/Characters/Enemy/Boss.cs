using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : ShieldEnemy
{
    [SerializeField]
    private float skillCoolTime;

    private WaitForSeconds waitSeconds;

    protected override void Start()
    {
        base.Start();
        waitSeconds = new WaitForSeconds(skillCoolTime);
        StartCoroutine(SkillCoroutine());
    }

    private IEnumerator SkillCoroutine()
    {
        while(!IsDead)
        {
            yield return waitSeconds;
            UseSkill();
        }
    }

    protected virtual void UseSkill()
    {
        anim.SetTrigger("onSkillUse");
    }
}
