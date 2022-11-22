using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject tile_Unit;
    public GameObject tile_Enemy;

    [SerializeField] private int board_UnitWidth = 18;
    [SerializeField] private int board_Unitdepth = 11;

    private const int tileDistance = 2;

    private Transform tile_Unit_Parent;
    private Transform tile_Enemy_Parent;

    private void Awake()
    {
        tile_Unit_Parent = transform.GetChild(1);
        tile_Enemy_Parent = transform.GetChild(0);

        // 전체 위치 중앙으로 옮기기 
        transform.position = new Vector3(-board_UnitWidth * tileDistance * 0.5f, -1.5f, -board_Unitdepth * tileDistance * 0.5f);

        for (int i = 0; i < board_Unitdepth; i++)
        {
            for (int j = 0; j < board_UnitWidth; j++)
            {
                if ((i == 0 && j == 0) || (i == 0 && j == board_UnitWidth - 1) ||
                    (i == board_Unitdepth - 1 && j == 0) ||
                    (i == board_Unitdepth - 1 && j == board_UnitWidth - 1))
                {
                    MakeEnemyTile(i, j);
                    continue;
                }
                MakeUnitTile(i, j);
            }
        }
        for(int i = 0; i < board_UnitWidth; i++)
        {
            //UP
            MakeEnemyTile(board_Unitdepth, i);
            //DOWN
            MakeEnemyTile(-1, i);
        }

        for(int i = 0; i < board_Unitdepth; i++)
        {
            //RIGHT
            MakeEnemyTile(i, board_UnitWidth);
            //LEFT
            MakeEnemyTile(i, -1);
        }
    }

    private void MakeUnitTile(int depth, int width)
    {
        GameObject obj = Instantiate(tile_Unit, tile_Unit_Parent);
        obj.transform.localPosition =
            new Vector3(width * tileDistance, 0, depth * tileDistance);
    }

    private void MakeEnemyTile(int depth, int width)
    {
        GameObject obj = Instantiate(tile_Enemy, tile_Enemy_Parent);
        obj.transform.localPosition =
            new Vector3(width * tileDistance, 0, depth * tileDistance);
    }
}
