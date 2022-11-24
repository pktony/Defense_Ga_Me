using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryAbs_Monster<T> : MonoBehaviour
{
    GameManager gameManager;
    protected Transform[] waypoints;

    private void Awake()
    {
        Transform SpawnPoint = transform.parent;
        Transform waypointParent = SpawnPoint.GetChild(2);
        waypoints = new Transform[waypointParent.childCount];
        for(int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    private void Start()
    {
        gameManager = GameManager.Inst;
    }

    public Enemy SpawnMonster(T type, Transform parent)
    {
        Enemy enemy = this.Create(type);
        enemy.transform.SetParent(parent);
        enemy.transform.position = parent.position;
        gameManager.EnemyCount++;
        return enemy;
    }

    public abstract Enemy Create(T type);
}
