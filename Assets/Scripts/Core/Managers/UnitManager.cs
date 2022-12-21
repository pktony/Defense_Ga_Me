using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSpace;

public class UnitManager : Singleton<UnitManager>
{
    UnitFactoryController unitController;

    public List<UnitProbabilityInfo> unitClassInfo;
    private float[] probabilityRanges;

    private Dictionary<UnitClasses, List<Unit>> spawnedUnits;
    private Unit selectedUnit;

    private int classSeed;

    protected override void Initialize()
    {
        unitController = FindObjectOfType<UnitFactoryController>();
        // 게임을 시작할 떄 새로운 시드를 부여.
        classSeed = Random.Range(0, int.MaxValue);
        RandomSeedGenerator.SetupClassRandom(classSeed);

        probabilityRanges = new float[unitClassInfo.Count];
        for(int i = 0; i < probabilityRanges.Length; i++)
        {
            probabilityRanges[i] = 100 - unitClassInfo[i].percentage;
        }        
    }

    public void SpawnUnit(float randomNumber)
    {
        for (int i = 0; i < probabilityRanges.Length; i++)
        {
            if (randomNumber < probabilityRanges[i])
            {
                unitController.SpawnUnit(unitClassInfo[i].unitClasses);
                UIManager.Inst.PopupText(unitClassInfo[i].className,
                    unitClassInfo[i].color);
                break;
            }
        }
    }

    public void SellSelectedUnit()
    {
        if (selectedUnit != null)
        {
            int sellPrice = unitClassInfo[(int)selectedUnit.ClassType].sellPrice;
            GameManager.Inst.GetGolds(sellPrice);
            Destroy(selectedUnit.gameObject);
        }
    }

    public void SetSelectedUnit(Unit selectedUnit)
    {
        this.selectedUnit = selectedUnit;
        UIManager.Inst.DisableButtons(IsExchangable(), IsSellable());
    }

    public void ExchangeUnit()
    {
        if(IsExchangable())
        {
            //GameManager.Inst.Player.SelectedCharacter.UnSelect();
            Destroy(selectedUnit.gameObject);
            SpawnUnit(probabilityRanges[(int)selectedUnit.ClassType]);
        }
    }

    private bool IsExchangable() => unitClassInfo[(int)selectedUnit.ClassType].isExchangable;
    private bool IsSellable() => unitClassInfo[(int)selectedUnit.ClassType].isSellable;


#if UNITY_EDITOR
    //private void Update()
    //{
    //    if(UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
    //    {
    //        TestProbability();
    //        counts = new int[7];
    //    }
    //}
    //int[] counts = new int[7];

    //private void TestProbability()
    //{
    //    for(int i = 0; i < 1000; i++)
    //    {
    //        float temp = RandomSeedGenerator.GenerateRandomNumber();
    //        SpawnUnit(temp);
    //    }

    //    for (int i = 0; i < counts.Length; i++)
    //    {
    //        Debug.Log($"{unitClassInfo[i].className} : {counts[i]}");
    //    }
    //}
#endif
}
