using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDataManager : MonoBehaviour
{
    public ProjectileData[] projectileDatas;

    public ProjectileData this[uint i] => projectileDatas[i];

}
