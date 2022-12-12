using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryAbs_Unit<T> : MonoBehaviour
{
    /// <summary>
    /// <typeparamref name="T"/>타입의 유닛을 스폰한다.
    /// </summary>
    /// <param name="type">스폰할 유닛의 타입</param>
    /// <param name="parent">생성 유닛 부모 오브젝트</param>
    /// <returns>생성한 유닛</returns>
    public Unit SpawnUnit(T type, Transform parent)
    {
        Unit unit = this.Create(type);
        unit.transform.SetParent(parent);
        unit.transform.position = parent.position;
        return unit;
    }

    public abstract Unit Create(T type);
}
