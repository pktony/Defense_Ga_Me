using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CountAbsInt : MonoBehaviour   
{
    protected int count;

    public abstract int Count { get; set; }

    public void ChangeCountBy(int value)
    {
        Count += value;
    }

    public void ResetCount()
    {
        Count = 0;
    }
}
