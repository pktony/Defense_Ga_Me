using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<LevelInfos> levelInfos;
    public List<UnitProbabilityInfo> unitClassInfo;

    private Spawner spawner;
    private ProjectileDataManager projectileDatas;

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
            round = Mathf.Clamp(value, 0, levelInfos.Count - 1);
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
    }

    private void Update()
    {
        if (!isGameover)
        {
            //TimeLeft -= Time.deltaTime;
        }

#if UNITY_EDITOR
        for(int i = 0; i < levelInfos.Count; i++)
        {
            levelInfos[i].monster = (Monsters)i;
            // Boss Rounds
            //23, 35, 50, 66, 80, 95,96,97,98,99,100
            if(i == 23 || i == 35 || i == 50 || i == 66 || i == 80 || i == 95 ||
               (i >= 95 && i <= 100))
            {
                levelInfos[i].isBoss = true;
            }
        }


        if (UnityEngine.InputSystem.Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            Round = tempRound;
            RequestSpawn(Round, 1);
        }
        else if (UnityEngine.InputSystem.Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ToNextRound();
        }
#endif
    }

    protected override void Initialize()
    {
        base.Initialize();
        spawner = FindObjectOfType<Spawner>();
        projectileDatas = GetComponent<ProjectileDataManager>();
        EnemyCount = 0;
        Round = 0;
    }

    private void ToNextRound()
    {
        Round++;
        if (round > 0)
        {
            ResetTime(levelInfos[round].isBoss);
            RequestSpawn(round, levelInfos[round].spawnNumber);
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
