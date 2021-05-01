using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWall : Block
{
    public GameObject blockWallPrefab;

    public override void BeingEaten()
    {
        base.BeingEaten();

        SpawnWall();
    }

    void SpawnWall()
    {
        // Grid 3x3
        Vector2Int[] area = new Vector2Int[]
        {
            Vector2Int.zero,
            Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left,
            Vector2Int.up + Vector2Int.right, Vector2Int.up + Vector2Int.left,
            Vector2Int.down + Vector2Int.right, Vector2Int.down + Vector2Int.left
        };


        Vector2Int posWall = MapGrid.instance.GetRandomPositionAreaEmpty(area);


        if (posWall == Vector2Int.one * -1)
        {
            Debug.Log("No Space Left");
            return;
        }

        /*
        GameObject go = (GameObject)Instantiate(blockWallPrefab, (Vector3Int)posWall, Quaternion.identity);

        Block blockPoop = go.GetComponent<Food>().GetBlock();

        MapGrid.instance.AddBlock(blockPoop, posWall);*/

    }
}
