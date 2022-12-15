using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BuyButton : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(BuyUnit);
    }

    private void BuyUnit()
    {
        if (GameManager.Inst.CanBuyUnit())
        {
            float randNumber = RandomSeedGenerator.GenerateRandomNumber();
            UnitManager.Inst.SpawnUnit(randNumber);
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }
}
