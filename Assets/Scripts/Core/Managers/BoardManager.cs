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

    public Vector3[] GolemSkillPositions()
    {
        Vector3[] pos = new Vector3[4] { BoardTiles[0], BoardTiles[16], BoardTiles[32], BoardTiles[47] };
        return pos;
    }
}
