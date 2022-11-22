using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    SlimeFactory slimeFactory;

    Transform slimeParent;

    private void Awake()
    {
        slimeFactory = GetComponentInChildren<SlimeFactory>();
        slimeParent = slimeFactory.transform.GetChild(0);
    }

    private void Start()
    {
        slimeFactory.SpawnMonster(SlimeType.red, slimeParent);
    }
}
