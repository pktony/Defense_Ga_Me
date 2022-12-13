using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class Unit : MonoBehaviour, IUnit
{
    private Animator anim;
    private CharacterStats unitStats;
    
    private bool isMoving = false;

    private float attackTimer = 0f;
    private WaitForSeconds detectWaitSeconds;
    private IEnumerator detectCoroutine;
    private Vector3 destination;
    private float detectInterval = 0.5f;
    private float stoppingDistance = 1;

    //private Stats stats;
    //private float attackCoolTime = 3.0f;
    //private float attackRange = 10f;
    //private int attackPower = 1;

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] protected float turnSpeed = 10f;
    [SerializeField] protected bool isDPPentratable = false;

    protected IAttackable attackTarget;
    #region IUNIT #############################################################
    
    public int AttackPower
    {
        get => unitStats.stats.attackPower;
        set
        {
            unitStats.stats.attackPower = value;
        }
    }

    /// <summary>
    /// 예외처리 필수 ! !!
    /// </summary>
    /// <param name="target"></param>
    public virtual void Attack(IAttackable target)
    {
        anim.SetTrigger("onAttack");
    }

    public void Move(Vector3 destination)
    { 
        IsMoving = true;
        destination.y = 0f;
        this.destination = destination;
    }

    
    #endregion

    public bool IsMoving
    {
        get => isMoving;
        set
        {
            isMoving = value;
            if (!isMoving)
                StartCoroutine(detectCoroutine);
            else
                StopCoroutine(detectCoroutine);
        }
    }

    #region UNITY EVENT 함수 ####################################################
    protected virtual void Awake()
    {
        unitStats = GetComponent<CharacterStats>();
        anim = GetComponentInChildren<Animator>();

        detectWaitSeconds = new WaitForSeconds(detectInterval);
        detectCoroutine = FindTarget();
        
        IsMoving = false;
    }

    private void Update()
    {
        if(!isMoving)
        {
            if (attackTarget != null)
            {
                LookTowardsTarget();
            }

            attackTimer += Time.deltaTime;
            if(attackTimer > unitStats.stats.attackCoolTime)
            {
                Attack(attackTarget);
                attackTimer = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
            MoveTo(destination);
    }
    #endregion

    public void SetStats(UnitData data)
    {
        unitStats.stats = new Stats(data.name, data.attackPower,
            data.attackCoolTime, data.attackRange);
        //this.attackPower = attackPower;
        //this.attackRange = attackRange;
        //this.attackCoolTime = attackCoolTime;
    }

    private void MoveTo(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.position += moveSpeed * Time.deltaTime * direction.normalized;
        if (direction.sqrMagnitude < stoppingDistance * stoppingDistance)
            IsMoving = false;
    }

    protected virtual void LookTowardsTarget()
    {
        if (!attackTarget.IsDead && attackTarget != null)
        {
            Vector3 lookDir = attackTarget.CurrentPos - transform.position;
            lookDir = lookDir.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(lookDir),
                turnSpeed * Time.deltaTime);
        }
    }

    private IEnumerator FindTarget()
    {
        while (!isMoving)
        {
            //Debug.Log("Detecting");
            Collider[] colls = Physics.OverlapSphere(
                transform.position, unitStats.stats.attackRange, LayerMask.GetMask("Enemy"));

            if (colls.Length > 0)
                attackTarget = colls[0].GetComponent<IAttackable>();
            else
                attackTarget = null;
            yield return detectWaitSeconds;
        }
    }

    protected abstract void Upgrade();

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position, transform.up, unitStats.stats.attackRange);
    }
#endif
}
