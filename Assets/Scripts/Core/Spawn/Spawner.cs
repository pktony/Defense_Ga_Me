using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Factory ###############################################################
    EnemyFactory enemyFactory;
    #endregion

    Transform[] spawnParents;
    WaitForSeconds spawnWaitSeconds;

    [SerializeField] private float spawnCoolTime = 1.0f;

    private void Awake()
    {
        Transform factoryParent = transform.GetChild(1);
        enemyFactory = factoryParent.GetComponent<EnemyFactory>();

        spawnParents = new Transform[factoryParent.childCount];
        for(int i = 0; i < spawnParents.Length; i++)
        {
            spawnParents[i] = factoryParent.GetChild(i);
        }

        spawnWaitSeconds = new WaitForSeconds(spawnCoolTime);
    }

    public void SpawnEnemy(Monsters type, int spawningNumber)
    {
        StartCoroutine(StartSpawning(type, spawningNumber));
    }

    private IEnumerator StartSpawning(Monsters type, int spawningNumber)
    {
        int enemiesToSpawn = spawningNumber;

        while (enemiesToSpawn > 0)
        {
            enemyFactory.SpawnMonster(type, spawnParents[0]);
            enemiesToSpawn--;
            GameManager.Inst.enemyCount.ChangeCountBy(1);
            yield return spawnWaitSeconds;
        }
    }
}
