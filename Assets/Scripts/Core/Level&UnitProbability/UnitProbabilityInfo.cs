using UnitSpace;
using UnityEngine;

[System.Serializable]
public class UnitProbabilityInfo
{
    public string className = "";
    public float percentage;
    public UnitClasses unitClasses;
    public Color color;
    public bool isSellable;
    public bool isExchangable;
    public int sellPrice;
}
