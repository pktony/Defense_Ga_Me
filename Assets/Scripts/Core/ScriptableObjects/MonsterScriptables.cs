using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterName", menuName = "ScriptableObject/Enemy/Monster", order = 0)]
public class MonsterScriptables : ScriptableObject
{
    public GameObject prefab;
    public float maxHP;
    public float dp;
    public float moveSpeed;
}
