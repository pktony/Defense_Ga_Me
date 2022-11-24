using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameManager gameManager;
    #region Factory ###############################################################
    NormalEnemyFactory normalFactory;
    ShieldEnemyFactory shieldFactory;
    BossFactory bossFactory;
    #endregion

    Transform[] spawnParents;
    WaitForSeconds spawnWaitSeconds;

    [SerializeField] private float spawnCoolTime = 1.0f;

    private void Awake()
    {
        Transform factoryParent = transform.GetChild(1);
        normalFactory = factoryParent.GetComponent<NormalEnemyFactory>();
        shieldFactory = factoryParent.GetComponent<ShieldEnemyFactory>();
        bossFactory = factoryParent.GetComponent<BossFactory>();

        spawnParents = new Transform[factoryParent.childCount];
        for(int i = 0; i < spawnParents.Length; i++)
        {
            spawnParents[i] = factoryParent.GetChild(i);
        }

        spawnWaitSeconds = new WaitForSeconds(spawnCoolTime);
    }


    public IEnumerator SpawnNormalEnemy(NormalEnemyType type, int spawningNumber)
    {
        int enemiesToSpawn = spawningNumber;

        while (enemiesToSpawn > 0)
        {
            normalFactory.SpawnMonster(type, spawnParents[0]);
            enemiesToSpawn--;
            yield return spawnWaitSeconds;
        }
    }

    public IEnumerator SpawnShieldEnemy(ShieldEnemyType type, int spawningNumber)
    {
        int enemiesToSpawn = spawningNumber;

        while (enemiesToSpawn > 0)
        {
            shieldFactory.SpawnMonster(type, spawnParents[0]);
            enemiesToSpawn--;
            yield return spawnWaitSeconds;
        }
    }

    public void SpawnBoss(BossType type)
    {
        bossFactory.SpawnMonster(BossType.golem_Poly, spawnParents[1]);
    }
}
