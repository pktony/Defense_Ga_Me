using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryAbs_Monster<T> : MonoBehaviour
{
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

    public Enemy SpawnMonster(T type, Transform parent)
    {
        Enemy enemy = this.Create(type);
        enemy.transform.SetParent(parent);
        enemy.transform.position = parent.position;
        return enemy;
    }

    public abstract Enemy Create(T type);
}
