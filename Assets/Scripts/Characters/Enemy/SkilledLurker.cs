using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilledLurker : Boss
{
    GameObject canvas;

    WaitForSeconds animWaitSeconds;
    WaitForSeconds skillWaitSeconds;

    private bool isUsingSkill = false;

    [SerializeField]
    private float skillDuration = 3.0f;

    protected override void Awake()
    {
        base.Awake();
        canvas = transform.GetChild(1).gameObject;
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach(var clip in clips)
        {
            if(clip.name.Equals("Skill"))
            {
                animWaitSeconds = new WaitForSeconds(clip.length);
                break;
            }
        }
        skillWaitSeconds = new WaitForSeconds(skillDuration);
    }

    protected override void UseSkill()
    {
        if (!isUsingSkill)
        {
            isUsingSkill = true;
            base.UseSkill();
            StartCoroutine(SkillProcess());
        }
    }

    private IEnumerator SkillProcess()
    {
        currentSpeed = 0f;
        yield return animWaitSeconds;
        HideMonster();
        ResetSpeed();
        yield return skillWaitSeconds;
        ShowMonster();
        yield return animWaitSeconds;
        ResetSpeed();
    }

    private void HideMonster()
    {
        model.gameObject.SetActive(false);
        canvas.SetActive(false);
    }

    private void ShowMonster()
    {
        currentSpeed = 0f;
        model.gameObject.SetActive(true);
        canvas.SetActive(true);
        anim.SetTrigger("onSkillUse");
    }

    private void ResetSpeed()
    {
        currentSpeed = enemyStats.stats.moveSpeed;
    }
}
