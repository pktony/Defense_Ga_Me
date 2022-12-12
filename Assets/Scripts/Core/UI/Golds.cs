using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golds : CountAbsInt
{
    public System.Action<int> onGoldChange;

    public override int Count
    {
        get => count;
        set
        {
            count = value;
            onGoldChange?.Invoke(count);
        }
    }
}
