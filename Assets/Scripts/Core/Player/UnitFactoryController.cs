using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSpace;
#if UNITY_EDITOR
using UnityEngine.InputSystem;
#endif

public class UnitFactoryController : MonoBehaviour
{
    private InstantUnitFactory instantUnitFactory;
    private ProjectileUnit_Factory projectileUnitFactory;

    private int[] classUnitCounts;
    private int unitSeed;

    private Dictionary<UnitClasses, Units[]> unitInfos = new Dictionary<UnitClasses, Units[]>();

#if UNITY_EDITOR
    [SerializeField] InstantUnitType unit;
    [SerializeField] ProjectileUnitType projectileUnit;
#endif

    private void Awake()
    {
        instantUnitFactory = GetComponent<InstantUnitFactory>();
        projectileUnitFactory = GetComponent<ProjectileUnit_Factory>();

        unitSeed = Random.Range(0, int.MaxValue);
        RandomSeedGenerator.SetupUnitRandom(unitSeed);

        int classCount = System.Enum.GetValues(typeof(UnitClasses)).Length;
        int j = 0;
        for(int i = 0; i < classCount; i++)
        {
            Units[] tempUnit = new Units[3];
            unitInfos.Add((UnitClasses)i, tempUnit);
            for (int k = 0; k < 3; k++)
            {
                tempUnit[k] = (Units)j;
                j++;
            }
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Keyboard.current.digit0Key.wasPressedThisFrame)
        {
            instantUnitFactory.SpawnUnit(unit, this.transform);
        }
        else if (Keyboard.current.digit9Key.wasReleasedThisFrame)
        {
            projectileUnitFactory.SpawnUnit(projectileUnit, this.transform);
        }
#endif
    }

    /// <summary>
    /// 유닛을 생성
    /// </summary>
    /// <param name="type">생성할 유닛의 타입</param>
    public void SpawnUnit(UnitClasses type)
    {
        int randNum = RandomSeedGenerator.GenerateRandomInteger();

        Units unit = unitInfos[type][randNum];
        if(unit == Units.gunner_7mmBullet || unit == Units.Turret_Rocket ||
           unit == Units.Tank_Missile || unit == Units.Miner ||
           unit == Units.Turret_Fast || unit == Units.Miner_Fast ||
           unit == Units.Tank_Nuclear)
        {
            var convertedUnit = unit.ConvertEnumTo<ProjectileUnitType>();
            SpawnProjectileUnit(convertedUnit);
        }
        else
        {
            var convertedUnit = unit.ConvertEnumTo<InstantUnitType>();
            SpawnInstantUnit(convertedUnit);
        }
    }

    private void SpawnInstantUnit(InstantUnitType type)
    {
        instantUnitFactory.SpawnUnit(type, this.transform);
    }

    private void SpawnProjectileUnit(ProjectileUnitType type)
    {
        projectileUnitFactory.SpawnUnit(type, this.transform);
    }


}
