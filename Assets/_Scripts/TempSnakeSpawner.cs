using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSnakeSpawner : MonoBehaviour
{
    public GameObject snakePrefab;
    public GameObject snakeAIPrefab;


    public MapGrid mapGrid;

    public Vector3 location;

    TempBuildSnake buildSnake;

    private void Awake()
    {
        buildSnake = GetComponent<TempBuildSnake>();
    }

    public Snake SpawnSnake()
    {
        Snake s = Instantiate(snakePrefab, (Vector3Int)mapGrid.SpawnPositionSnake(), Quaternion.identity).GetComponent<Snake>();

        buildSnake.BuildSnake(s);

        return s;
    }


    public Snake CreatePlayer()
    {
        Snake s = SpawnSnake(snakePrefab);

        return s;
    }

    public Snake CreateAI()
    {
        Snake s = SpawnSnake(snakeAIPrefab);

        return s;
    }

    Snake SpawnSnake(GameObject prefab)
    {
        Vector2Int pos = mapGrid.SpawnPositionSnake();

        Snake s = Instantiate(prefab, (Vector3Int)pos, Quaternion.identity).GetComponent<Snake>();

        s.pos = pos;

        buildSnake.BuildSnake(s);

        return s;
    }
}
