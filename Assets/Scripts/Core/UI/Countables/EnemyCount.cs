using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : CountAbsInt
{
    private const int MAX_ENEMYCOUNT = 150;

    public System.Action<int, int> onEnemyCountChange;

    public override int Count
    {
        get => count;
        set
        {
            count = value;
            onEnemyCountChange?.Invoke(count, MAX_ENEMYCOUNT);
            if (count == MAX_ENEMYCOUNT)
            {
                GameManager.Inst.GameOver();
            }
        }
    }
}
