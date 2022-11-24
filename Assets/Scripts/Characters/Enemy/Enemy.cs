using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IAttackable
{
    GameManager gameManager;

    protected float maxhealthPoint;
    protected float healthPoint;
    protected float defencePower;
    protected float moveSpeed;
    protected float shield;

    private Transform[] waypoints;
    private int currentIndex = 0;
    private const float STOPPING_DIST = 0.1f;

    private bool isDead = false;

    public float HP
    {
        get => healthPoint;
        set
        {
            healthPoint = Mathf.Clamp(value, 0f, MaxHP);
            if(healthPoint <= 0f)
            {
                Die();
            }
        }
    }
    public float MaxHP => maxhealthPoint;

    public float DP => defencePower;

    public Vector3 CurrentPos => transform.position;

    private void Start()
    {
        gameManager = GameManager.Inst;
        HP = MaxHP;
        LookTowardsWaypoint();
    }

    private void FixedUpdate()
    {
        if(!isDead)
        {
            Move();
        }
    }

    #region PRIVATE 함수 ########################################################
    private void Move()
    {
        Vector3 direction =
            (waypoints[currentIndex].position - transform.position).normalized;

        transform.position += moveSpeed * Time.fixedDeltaTime
                    * direction;

        if ((waypoints[currentIndex].position - transform.position).sqrMagnitude
            < STOPPING_DIST * STOPPING_DIST)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        currentIndex++;
        currentIndex %= waypoints.Length;
        LookTowardsWaypoint();
    }

    private void LookTowardsWaypoint()
    {
        transform.rotation = Quaternion.LookRotation(
                    waypoints[currentIndex].position - transform.position);
    }

    private void Die()
    {
        isDead = true;
        gameManager.EnemyCount--;
        Destroy(this.gameObject);
    }
    #endregion


    #region PUBLIC 함수 #########################################################
    public virtual void GetAttack(float damage)
    {
        HP -= Mathf.Max(1f, damage - DP);
        //Debug.Log($"{gameObject.name} HP : {HP}");
    }

    public void InitializeWaypoints(Transform[] waypoints)
    {
        this.waypoints = new Transform[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
            this.waypoints[i] = waypoints[i];
    }

    public abstract void SetStats(float maxHP, float dp, float moveSpeed, float shield = 0f);
    #endregion
}
