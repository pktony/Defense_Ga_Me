using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTriggerHelper : MonoBehaviour
{
    private Unit_Magic unit;
    private float attackPower;
    private float tick = 0.5f;
    private WaitForSeconds tickWaitSeconds;

    public System.Action<float> onTriggerActivate;


    private void Awake()
    {
        unit = transform.parent.GetComponent<Unit_Magic>();

        tickWaitSeconds = new WaitForSeconds(tick);
    }

    private void Start()
    {// 팩토리를 통해서 생성되고 attackpower를 부여받기 때문에 awake 타이밍은 너무 이르다 
        attackPower = unit.AttackPower; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            StartCoroutine(Attack(other));
        }
    }

    private IEnumerator Attack(Collider collider)
    {
        while(this.gameObject.activeSelf)
        {
            if (collider.TryGetComponent<IAttackable>(out IAttackable enemy))
            {
                enemy.GetAttack(attackPower);
            }
            yield return tickWaitSeconds;
        }
    }
}
