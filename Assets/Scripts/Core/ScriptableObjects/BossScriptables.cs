using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss", menuName = "ScriptableObject/Boss", order = 2)]
public class BossScriptables : MonsterScriptables
{
    public float shield = 100f;
}
