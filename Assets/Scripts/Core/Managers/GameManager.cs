using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<LevelInfos> levelInfos;
    [SerializeField] private int[] bossRounds;

    public List<UnitProbabilityInfo> unitClassInfo;

    Spawner spawner;
    ProjectileDataManager projectileDatas;

#if UNITY_EDITOR
    public int tempRound;
#endif

    private int round = 1;
    private const int MAX_ROUND = 100;

    private float timeLeft;
    private const float TIME_NORMAL = 5f;
    private const float TIME_BOSS = 330f;

    private int enemyCount;
    public const int MAX_ENEMYCOUNT = 150;

    private bool isGameover;

    public System.Action<int> onRoundChange;
    public System.Action<int> onEnemyCountChange;
    public System.Action<float> onTimeChange;

    public ProjectileDataManager ProjectileDatas => projectileDatas;
    public int Round
    {
        get => round;
        set
        {
            round = value;
            onRoundChange?.Invoke(round);
        }
    }

    public int EnemyCount
    {
        get => enemyCount;
        set
        {
            enemyCount = value;
            onEnemyCountChange?.Invoke(enemyCount);
            if(enemyCount == MAX_ENEMYCOUNT)
            {
                GameOver();
            }
        }
    }

    public float TimeLeft
    {
        get => timeLeft;
        set
        {
            timeLeft = value;
            onTimeChange?.Invoke(timeLeft);

            if (timeLeft <= 0f && round < MAX_ROUND)
            {
                ToNextRound();
            }
        }
    }

    private void Start()
    {
        ResetTime(false);
        ToNextRound();
    }

    private void Update()
    {
        if (!isGameover)
        {
            TimeLeft -= Time.deltaTime;
        }
//#if UNITY_EDITOR
//        if(Keyboard.current.digit1Key.wasPressedThisFrame)
//        {
//            Round = tempRound;
//            RequestSpawn(Round, 1);
//        }
//#endif
    }

    protected override void Initialize()
    {
        base.Initialize();
        spawner = FindObjectOfType<Spawner>();
        projectileDatas = GetComponent<ProjectileDataManager>();
        EnemyCount = 0;
        round = -1;
    }

    private void ToNextRound()
    {
        Round++;
        if (round > 0)
        {
            ResetTime(levelInfos[round - 1].isBoss);
            RequestSpawn(round - 1, levelInfos[round - 1].spawnNumber);
        }
    }

    private void RequestSpawn(int round, int spawnNumber)
    {
        spawner.SpawnEnemy((Monsters)round, spawnNumber);
    }

    private void ResetTime(bool isBoss = false)
    {
        TimeLeft = isBoss ? TIME_BOSS : TIME_NORMAL;
    }

    private void GameOver()
    {
        StopAllCoroutines();
        isGameover = true;
    }
}
