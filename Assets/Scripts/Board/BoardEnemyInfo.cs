using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEnemyInfo : MonoBehaviour
{
    Transform enemyGroundParent;

    private Vector3[] enemyGroundPositions;
    private string[] names;

    public Vector3[] EnemyGroundPositions => enemyGroundPositions;
    public string[] Names => names;

    private void Awake()
    {
        enemyGroundParent = transform.GetChild(0);
        enemyGroundPositions = new Vector3[enemyGroundParent.childCount];
        names = new string[enemyGroundParent.childCount];
        for (int i = 0; i < enemyGroundParent.childCount; i++)
        {
            names[i] = enemyGroundParent.GetChild(i).gameObject.name;
            enemyGroundPositions[i] = enemyGroundParent.GetChild(i).position +
                1.5f * Vector3.up;
        }
    }
}
