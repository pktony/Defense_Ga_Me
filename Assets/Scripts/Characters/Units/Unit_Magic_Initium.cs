using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Magic_Initium : Unit_Magic
{
    private int tileNumbers;

    private void Start()
    {
        tileNumbers = BoardManager.Inst.BoardTiles.Length;
    }

    protected override IEnumerator MagicSwitch(Vector3 position)
    {
        for (int i = 0; i < tileNumbers; i++)
        {
            if (i % 2 == 0) continue;
            UseMagic(BoardManager.Inst.BoardTiles[i]);
        }
        yield return magicWaitSeconds;
        for (int i = 0; i < tileNumbers; i++)
            DisableMagic();
    }   
}
