using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Unit_Magic : Unit
{
    [SerializeField] private GameObject magicPrefab;
    [SerializeField] private float magicDuration = 2.0f;

    private WaitForSeconds magicWaitSeconds;

    private Queue<GameObject> magics;
    private Queue<GameObject> usedMagics;

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

        magicWaitSeconds = new WaitForSeconds(magicDuration);
    }

    public override void Attack(IAttackable target)
    {
        if (attackTarget != null)
        {
            base.Attack(target);
            StartCoroutine(MagicSwitch(target.CurrentPos));
        }
    }

    private IEnumerator MagicSwitch(Vector3 position)
    {
        UseMagic(position);
        yield return magicWaitSeconds;
        DisableMagic();
    }

    private void UseMagic(Vector3 position)
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

    private void DisableMagic()
    {
        if(usedMagics.TryDequeue(out GameObject usedMagic))
        {
            usedMagic.transform.parent = magicParent;
            usedMagic.SetActive(false);
            magics.Enqueue(usedMagic);
        }
    }

    protected override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
