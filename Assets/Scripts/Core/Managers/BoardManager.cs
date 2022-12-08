using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    private BoardEnemyInfo board;

    public string[] TileNames => board.Names;
    public Vector3[] BoardTiles => board.EnemyGroundPositions;

    protected override void Initialize()
    {
        board = FindObjectOfType<BoardEnemyInfo>();
    }
}
