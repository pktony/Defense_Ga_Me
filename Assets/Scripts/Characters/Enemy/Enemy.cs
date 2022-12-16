using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IAttackable
{
    GameManager gameManager;
    Transform model;
    Animator anim;

    protected EnemyStats enemyStats;

    private Transform[] waypoints;
    private int currentIndex = 0;
    private const float STOPPING_DIST = 0.1f;

    private bool isDead = false;
    public System.Action<float, float> onHealthChange;

    public float HP
    {
        get => enemyStats.hp;
        set
        {
            enemyStats.hp = Mathf.Clamp(value, 0f, enemyStats.stats.maxHP);
            onHealthChange?.Invoke(HP, MaxHP);
            if(HP <= 0f)
            {
                Die();
            }
        }
    }
    public float MaxHP => enemyStats.stats.maxHP;
    public float DP => enemyStats.stats.dp;

    public bool IsDead
    {
        get => isDead;
        set => isDead = value; 
    }
    public Vector3 CurrentPos => model.transform.forward * 3.0f + transform.position;
    public Vector3 ParticlePos => transform.position + Vector3.up * 1f;
    public Transform Trans => this.transform;


    private void Awake()
    {
        model = transform.GetChild(0);
        enemyStats = GetComponent<EnemyStats>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    protected virtual void Start()
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

        transform.position += enemyStats.stats.moveSpeed * Time.fixedDeltaTime
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
        model.rotation = Quaternion.LookRotation(
                    waypoints[currentIndex].position - transform.position);
    }

    private void Die()
    {
        isDead = true;
        anim.SetBool("isDead", isDead);
        gameManager.DecreaseEnemyCount();
        Destroy(this.gameObject, 3f);
    }
    #endregion


    #region PUBLIC 함수 #########################################################
    public virtual void GetAttack(float damage, bool isDPPenetratable = false)
    {
        if (!isDead)
        {
            if (!isDPPenetratable)
                HP -= Mathf.Max(1f, damage - DP);
            else
                HP -= Mathf.Max(1f, damage);
            //Debug.Log($"{gameObject.name} HP : {HP}");
        }
    }

    public void InitializeWaypoints(Transform[] waypoints)
    {
        this.waypoints = new Transform[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
            this.waypoints[i] = waypoints[i];
    }
    #endregion
}
