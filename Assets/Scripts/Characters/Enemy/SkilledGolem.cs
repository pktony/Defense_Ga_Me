using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilledGolem : Boss
{
    [SerializeField]
    private GameObject skillObj;

    private Vector3[] skillPos;

    protected override void Start()
    {
        base.Start();
        skillPos = BoardManager.Inst.GolemSkillPositions();
    }

    protected override void UseSkill()
    {
        base.UseSkill();
        for (int i = 0; i < 4; i++)
        {
            GameObject bulletObj = Instantiate(skillObj);
            bulletObj.transform.position = transform.position + Vector3.up * 2f;

            Projectile_Golem stone = bulletObj.GetComponent<Projectile_Golem>();
            stone.InitializeProjectile(skillPos[i], 0, true);
        }
    }

    public void Heal(float healAmount)
    {
        HP += healAmount;
    }
}
