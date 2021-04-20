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
        return new Vector2Int(Random.Range(0, size.x), Random.Range(0, size.y));
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
            Debug.LogError("Possition already empty");
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

    public bool CheckPosValid(Vector2Int pos)
    {
        if (pos.x >= size.x || pos.x < 0 || pos.y >= size.y || pos.y < 0)
            return false;

        return true;
    }
}
