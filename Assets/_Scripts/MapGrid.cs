using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    public Vector2Int size;

    Block[,] blockGrid;


    public static MapGrid instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        blockGrid = new Block[size.x, size.y] ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector2Int RandomEmptyPos()
    {
        //return new Vector2Int(Random.Range(0, size.x), Random.Range(0, size.y));

        Vector2Int pos;

        do
        {
            pos = new Vector2Int(Random.Range(0, size.x), Random.Range(0, size.y));

            if (PositionEmpty(pos))
                return pos;


        } while (true);

    }

    public void AddBlock(Block block, Vector2Int pos)
    {
        blockGrid[pos.x, pos.y] = block;
    }

    public void Moveblock(Vector2Int startPos, Vector2Int endPos)
    {
        // Check Errors
        // ---

        // Move Blocks
        blockGrid[endPos.x, endPos.y] = blockGrid[startPos.x, startPos.y];
        blockGrid[startPos.x, startPos.y] = null;
    }


    public void RemoveBlock(Vector2Int pos)
    {
        if (!CheckPosValid(pos))
        {
            Debug.LogError("Invalid Position");
            return;
        }

        if (blockGrid[pos.x, pos.y] == null)
            Debug.Log("Possition already empty");
        else
            blockGrid[pos.x, pos.y] = null;

    }


    public Block CheckBlockPosition(Vector2Int pos)
    {
        // This is not right, should return an error
        if (!CheckPosValid(pos))
            return null;

        return blockGrid[pos.x, pos.y];

    }


    public bool PositionEmpty(Vector2Int pos)
    {
        return blockGrid[pos.x, pos.y] == null;
    }


    public bool PositionWall(Vector2Int pos)
    {
        if (blockGrid[pos.x, pos.y] == null)
            return false;
        else if (blockGrid[pos.x, pos.y].blockType != BlockType.Food)
            return true;
        return false;
    }

    public bool CheckPosValid(Vector2Int pos)
    {
        if (pos.x >= size.x || pos.x < 0 || pos.y >= size.y || pos.y < 0)
            return false;

        return true;
    }

    public bool PositionPassable(Vector2Int pos)
    {
        return (CheckPosValid(pos) && (blockGrid[pos.x, pos.y] == null));
    }


    // Temp

    public int Cost(Vector2Int pos)
    {
        if (blockGrid[pos.x, pos.y] == null)
            return 1;
        else
            return System.Int32.MaxValue;
    }


    public Vector2Int SpawnPositionSnake()
    {
        return new Vector2Int(Random.Range(2, size.x-2), Random.Range(0+2, size.y-2));

    }


}
