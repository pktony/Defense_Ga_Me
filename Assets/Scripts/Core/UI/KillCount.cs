using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCount : CountAbsInt
{
    private const int REWARDED_KILL = 10;

    public System.Action<int, int> onEnemykill;

    public override int Count
    {
        get => count;
        set
        {
            count = value;
            if (count == REWARDED_KILL)
            {
                count = 0;
                GameManager.Inst.GetGolds();
            }
            onEnemykill?.Invoke(count, REWARDED_KILL);
        }
    }

}
