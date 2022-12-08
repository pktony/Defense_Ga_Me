using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSpace;
#if UNITY_EDITOR
using UnityEngine.InputSystem;
#endif

public class UnitFactoryController : MonoBehaviour
{
    InstantUnitFactory instantUnitFactory;
    ProjectileUnit_Factory projectilUnitFactory;

#if UNITY_EDITOR
    [SerializeField] InstantUnitType unit;
    [SerializeField] ProjectileUnitType projectileUnit;
#endif

    private void Awake()
    {
        instantUnitFactory = GetComponent<InstantUnitFactory>();
        projectilUnitFactory = GetComponent<ProjectileUnit_Factory>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if(Keyboard.current.digit0Key.wasPressedThisFrame)
        {
            instantUnitFactory.SpawnUnit(unit, this.transform);
        }
        else if(Keyboard.current.digit9Key.wasReleasedThisFrame)
        {
            projectilUnitFactory.SpawnUnit(projectileUnit, this.transform);
        }

#endif
    }
}
