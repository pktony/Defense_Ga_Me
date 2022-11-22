using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IAttackable
{
    protected float maxhealthPoint;
    protected float healthPoint;
    protected float defencePower;
    protected float moveSpeed;

    private Transform[] waypoints;
    private int currentIndex = 0;
    private const float STOPPING_DIST = 0.1f;

    public float HP
    {
        get => healthPoint;
        set
        {
            healthPoint = Mathf.Clamp(value, 0f, MaxHP);
        }
    }
    public float MaxHP => maxhealthPoint;

    public float DP => defencePower;

    public Vector3 CurrentPos => transform.position;

    private void Start()
    {
        HP = MaxHP;
        LookTowardsWaypoint();
    }

    private void FixedUpdate()
    {
        Move();
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
        Debug.Log(currentIndex);
    }

    private void LookTowardsWaypoint()
    {
        transform.rotation = Quaternion.LookRotation(
                    waypoints[currentIndex].position - transform.position);
    }
    #endregion


    #region PUBLIC 함수 #########################################################
    public void GetAttack(float damage)
    {
        HP -= Mathf.Max(1f, damage - DP);
        Debug.Log($"{gameObject.name} HP : {HP}");
    }

    public void InitializeWaypoints(Transform[] waypoints)
    {
        this.waypoints = new Transform[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
            this.waypoints[i] = waypoints[i];
    }

    public abstract void SetStats(float maxHP, float dp, float moveSpeed);
    #endregion
}
