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

    /// <summary>
    /// Gold가 충분한지 확인
    /// </summary>
    /// <param name="requiredMoney">필요한 골드</param>
    /// <returns>True : 돈이 충분하다, False : 돈이 충분하지 않다</returns>
    public bool IsEnoughGold(int requiredMoney)
    {
        return count >= requiredMoney;
    }
}
