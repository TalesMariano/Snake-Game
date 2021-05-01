// References
// https://stackoverflow.com/questions/3150678/using-linq-with-2d-array-select-not-found
// https://stackoverflow.com/questions/3173718/how-to-get-a-random-object-using-linq
// https://www.tutorialfor.com/questions-79494.htm
// https://stackoverflow.com/questions/31425494/linq-select-null-values-from-list

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapGrid : MonoBehaviour
{
    public Vector2Int size = Vector2Int.one*10;

    Block[,] blockGrid;


    public static MapGrid instance;

    public MapGrid(Vector2Int mapDimention)
    {
        size = mapDimention;
        BuildMap();
    }

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        BuildMap();
    }

    public void BuildMap()
    {
        blockGrid = new Block[size.x, size.y];
    }

    public Vector2Int RandomEmptyPos()
    {
        //return new Vector2Int(Random.Range(0, size.x), Random.Range(0, size.y));

        Vector2Int pos;

        do
        {
            pos = new Vector2Int(Random.Range(0+3, size.x-3), Random.Range(0+3, size.y-3));

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
    

    public Vector2Int SpawnPositionSnake(Vector2Int direction)
    {
        //Random Direction
        //Vector2Int[] directions = new Vector2Int[] { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

        //Vector2Int direction = directions.OrderBy(_ => System.Guid.NewGuid()).First();
        //Vector2Int direction = Vector2Int.up;

        Vector2Int[] relativeArea = new Vector2Int[] { direction * 0, direction * -1, direction * -2 };


        return GetRandomPositionAreaEmpty(relativeArea);

    }

    public Vector2Int GetRandomPositionAreaEmpty( Vector2Int[] relativeArea)
    {
        

        var query = blockGrid.Cast<Block>() // Revert to a one-dimensional array
        .Select((d, i) => new { X = i % blockGrid.GetLength(0), Y = i / blockGrid.GetLength(0), Value = d }) // Select with index, x, y Get value
        .Where(pair => pair.Value == null) // Extract only the thing with value null
        .Where(xx => IsPositionAreaEmpty( new Vector2Int(xx.X,xx.Y), relativeArea)); 


        // Return Random
        if (query.Any())
        {
            // Set order random
            var rnd = new System.Random();
            var result = query.OrderBy(n => rnd.Next()).First();

            return new Vector2Int(result.X, result.Y);    // return empty position
        }

        print("No pos found");
        // No pos found
        return (Vector2Int.one * -1);
        //return new Vector2Int(Random.Range(2, size.x-2), Random.Range(0+2, size.y-2));
    }

    bool IsPositionValidAndEmpty(Vector2Int pos)
    {
        if (pos.x >= size.x || pos.x < 0 || pos.y >= size.y || pos.y < 0)
            return false;

        return blockGrid[pos.x, pos.y] == null;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <returns> Returns (-1,-1) if there is no empty Poss</returns>
    [ContextMenu("GetRandomEmptyPos")]
    public Vector2Int GetRandomEmptyPos()
    {
        var query = blockGrid.Cast<Block>() // Revert to a one-dimensional array
            .Select((d, i) => new { X = i % blockGrid.GetLength(0), Y = i / blockGrid.GetLength(0), Value = d }) // Select with index, x, y Get value
            .Where(pair => pair.Value == null); // Extract only the thing with value null


        // Return Random
        if (query.Any())
        {
            // Set order random
            var rnd = new System.Random();
            var result = query.OrderBy(n => rnd.Next()).First();

            return new Vector2Int(result.X, result.Y); //(query.First().X, query.First().Y);    // return empty position
        }

        print("No pos found");
        // No pos found
        return (Vector2Int.one * -1);
    }

    [ContextMenu("TestLinq")]
    void TestLinq()
    {
        int[,] array = { { 1, 2 }, { 3, 4 } };

        var query = from int item in array
                    where item % 2 == 0
                    select item;


        /*
        foreach (int item in query)
        {
            print(item);
        }*/

        var SelectedPost = query.OrderBy(qu => System.Guid.NewGuid()).First();


        print(SelectedPost);
    }


    bool IsPositionAreaEmpty(Vector2Int pos, Vector2Int[] relativeArea)
    {
        // if not valid or empty
        if (!IsPositionValidAndEmpty(pos))
            return false;

        foreach (Vector2Int v in relativeArea)
        {
            if (!IsPositionValidAndEmpty(pos + v))
                return false;
        }

        return true;
    }

    #region Fair Distance Points
    int PositionCostFairDistance(int x, int y, Vector2Int point1, Vector2Int point2)
    {
        return PositionCostFairDistance(new Vector2Int(x, y), point1, point2);
    }

    public int PositionCostFairDistance(Vector2Int pos, Vector2Int point1, Vector2Int point2) // Fix - Remove Public
    {
        Vector2Int middle = (point1 + point2) / 2;

        int valueDistanceMiddle = ValueDistancePoint(pos, middle);

        int valueDistancePoint1 = ValueDistancePoint(pos, point1);
        int valueDistancePoint2 = ValueDistancePoint(pos, point2);

        return valueDistanceMiddle + Mathf.Abs(valueDistancePoint1 - valueDistancePoint2);
    }

    int ValueDistancePoint(Vector2Int point1, Vector2Int point2)
    {
        Vector2Int vectorDistance = point1 - point2;
        vectorDistance = new Vector2Int(Mathf.Abs(vectorDistance.x), Mathf.Abs(vectorDistance.y));  // make distance absolute

        return vectorDistance.x + vectorDistance.y;
    }

    public Vector2Int GetFairEmptyPosition(Vector2Int pos1, Vector2Int pos2)
    {
        var query = blockGrid.Cast<Block>() // Revert to a one-dimensional array
            .Select((d, i) => new { X = i % blockGrid.GetLength(0), Y = i / blockGrid.GetLength(0), Value = d }) // Select with index, x, y Get value
            .Where(pair => pair.Value == null) // Extract only the thing with value null
            .OrderBy(n => PositionCostFairDistance(n.X, n.Y, pos1, pos2)); // sort by distance value

        //foreach (var item in query)
        //{
        //    print(string.Format("Position {0}-{1} : score = {2}", item.X, item.Y, PositionCostFairDistance(item.X, item.Y, pos1, pos2)));
        //}

        // Return Random
        if (query.Any())
        {
            var result = query.First();

            return new Vector2Int(result.X, result.Y); //(query.First().X, query.First().Y);    // return empty position
        }

        print("No pos found");
        // No pos found
        return (Vector2Int.one * -1);
    }

    #endregion



}
