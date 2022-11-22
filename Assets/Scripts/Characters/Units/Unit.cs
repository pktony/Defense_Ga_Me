using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class Unit : MonoBehaviour, IUnit
{
    private GameObject selectionCircle;
    private Rigidbody rigid;
    private Animator anim;
    
    private bool isSelected;
    private bool isMoving = false;

    private IAttackable attackTarget;
    private float attackTimer = 0f;
    private WaitForSeconds detectWaitSeconds;
    private float detectInterval = 0.5f;

    [SerializeField] private float attackCoolTime = 3.0f;
    [SerializeField] float stoppingDistance = 0.1f;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] float detectRadius = 10f;

    #region IUNIT #############################################################
    public virtual bool IsSelected
    {
        get => isSelected;
        set
        {
            if (!isSelected)
            {// 선택되지 않았으면
                selectionCircle.SetActive(true);
                Debug.Log("selected");
            }
            else
            {// 이미 선택 됐으면
                UnSelect();
                return;
            }
            isSelected = value;
        }
    }
    public int AttackPower { get; set; }

    /// <summary>
    /// 예외처리 필요
    /// </summary>
    /// <param name="target"></param>
    public virtual void Attack(IAttackable target)
    {
        //if(target != null)
        //{
            anim.SetTrigger("onShoot");
            target.GetAttack(AttackPower);
        //}
    }

    public void Move(Vector3 destination)
    {
        if(isSelected)
        {
            isMoving = true;
            StartCoroutine(MoveTo(destination));
        }
    }

    public bool GetSelected()
    {
        IsSelected = true;
        return IsSelected;
    }

    public void UnSelect()
    {
        selectionCircle.SetActive(false);
        isSelected = false;
        Debug.Log("unselected");
    }
    #endregion

    #region UNITY EVENT 함수 ####################################################
    protected virtual void Awake()
    {
        selectionCircle = transform.GetChild(1).gameObject;
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        detectWaitSeconds = new WaitForSeconds(detectInterval);
    }

    private void Update()
    {
        if(!isMoving)
        {
            if (attackTarget != null)
            {
                Vector3 lookDir = attackTarget.CurrentPos - transform.position;
                lookDir = lookDir.normalized;
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(lookDir),
                    turnSpeed * Time.deltaTime);
            }

            attackTimer += Time.deltaTime;
            if(attackTimer > attackCoolTime)
            {
                Attack(attackTarget);
                attackTimer = 0f;
            }
        }
    }
    #endregion

    private IEnumerator MoveTo(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        while ((transform.position - destination).sqrMagnitude >
            stoppingDistance * stoppingDistance)
        {
            rigid.position += moveSpeed * Time.deltaTime * direction;
            yield return null;
        }
        isMoving = false;
        StartCoroutine(FindTarget());
    }

    private IEnumerator FindTarget()
    {
        while (!isMoving)
        {
            Collider[] colls = Physics.OverlapSphere(
                transform.position, detectRadius, LayerMask.GetMask("Enemy"));

            if(colls != null)
            {
                attackTarget = colls[0].GetComponent<IAttackable>();
            }
            yield return detectWaitSeconds;
        }
    }

    protected abstract void Upgrade();

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position, transform.up, detectRadius);
    }
#endif
}
