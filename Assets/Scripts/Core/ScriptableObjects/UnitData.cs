using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "ScriptableObject/Unit/Unit", order = 1)]
public class UnitData : ScriptableObject
{
    public GameObject unitPrefab;
    public string unitName = "";
    public UnitSpace.UnitClasses classType;
    public UnitSpace.UnitTypes type;
    public int attackPower;
    public int attackNumber = 1;
    public float attackCoolTime;
    public float attackRange;
}
