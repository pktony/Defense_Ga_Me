using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "ScriptableObject/Enemy/ShieldMonster", order = 1)]
public class ShieldMonsterScriptables : MonsterScriptables
{
    public float shield = 30f;
}
