using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuildSnake2 : MonoBehaviour
{
    public GameObject snakePrefabPlayer;
    public GameObject snakePrefabAI;

    [Space]

    public int numNodes = 3;

    public Vector3Int nodesNumbers = Vector3Int.one;

    public ListBlocks listBlocks;

    private void Start()
    {
        if (GetComponent<Snake>())
            BuildSnake(GetComponent<Snake>());
    }


    [ContextMenu("BuildSnake")]
    public void BuildSnake(Snake snake)
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2Int pos = snake.pos + Vector2Int.down * (2 - i);

            Block node = listBlocks.GetBlock(nodesNumbers[i]);

            node.blockType = BlockType.Snake;

            MapGrid.instance.AddBlock(node, pos);

            snake.AddBlock(node, pos);

        }


    }

    /*
    public Snake SpawnSnake()
    {
        Snake s = Instantiate(snakePrefab, (Vector3Int)mapGrid.SpawnPositionSnake(), Quaternion.identity).GetComponent<Snake>();

        BuildSnake(s);

        return s;
    }*/


    public Snake CreatePlayer()
    {
        Snake s = SpawnSnake(snakePrefabPlayer);

        return s;
    }

    public Snake CreateAI()
    {
        Snake s = SpawnSnake(snakePrefabAI);

        return s;
    }


    Snake SpawnSnake(GameObject prefab)
    {
        Vector2Int dir = Vector2Int.up;

        Vector2Int pos = MapGrid.instance.SpawnPositionSnake(dir);

        Snake s = Instantiate(prefab, (Vector3Int)pos, Quaternion.identity).GetComponent<Snake>();

        s.pos = pos;

        BuildSnake(s);

        return s;
    }
}
