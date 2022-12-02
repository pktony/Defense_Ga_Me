using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryAbs_Unit<T> : MonoBehaviour
{

    public Unit SpawnUnit(T type, Transform parent)
    {
        Unit unit = this.Create(type);
        unit.transform.SetParent(parent);
        unit.transform.position = parent.position;
        return unit;
    }

    public abstract Unit Create(T type);
}
