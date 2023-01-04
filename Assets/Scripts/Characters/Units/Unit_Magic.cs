using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Magic : Unit
{
    [SerializeField] private GameObject magicPrefab;
    [SerializeField] private float magicDuration = 2.0f;

    protected WaitForSeconds magicWaitSeconds;

    private Queue<GameObject> magics;
    private Queue<GameObject> usedMagics;
    private Vector3[] targetPos;

    private Transform magicParent;

    protected override void Awake()
    {
        base.Awake();
        magicParent = transform.GetChild(2);
        magics = new Queue<GameObject>(magicParent.childCount);
        usedMagics = new Queue<GameObject>(magicParent.childCount);
        for(int i = 0; i < magicParent.childCount; i++)
        {
            GameObject obj = magicParent.GetChild(i).gameObject;
            magics.Enqueue(obj);
            obj.SetActive(false);
        }
        targetPos = new Vector3[1];

        magicWaitSeconds = new WaitForSeconds(magicDuration);
    }

    public override void Attack(IAttackable target)
    {
        if (!ReferenceEquals(attackTarget, null))
        {
            base.Attack(target);
            StartCoroutine(MagicSwitch(target.CurrentPos));
        }
    }

    protected virtual IEnumerator MagicSwitch(Vector3 position)
    {
        UseMagic(position);
        yield return magicWaitSeconds;
        DisableMagic();
    }

    protected void UseMagic(Vector3 position)
    {
        if (magics.TryDequeue(out GameObject magic))
        {
            usedMagics.Enqueue(magic);
            magic.transform.position = position;
            magic.transform.parent = null;
            magic.SetActive(true);
        }
        else
        {
            GameObject obj = Instantiate(magicPrefab);
            usedMagics.Enqueue(obj);
            obj.transform.position = position;
            obj.SetActive(true);
        }
    }

    protected void DisableMagic()
    {
        if(usedMagics.TryDequeue(out GameObject usedMagic))
        {
            usedMagic.transform.parent = magicParent;
            usedMagic.SetActive(false);
            magics.Enqueue(usedMagic);
        }
    }
}
