using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour, IController
{
    public Snake tempSnake;


    [SerializeField] public Block targetBlock;
    public Vector2Int targetPos;

    [SerializeField] private Vector2Int[] path;


    private void OnEnable()
    {
        tempSnake.OnMove += PathAndUpdMove;
    }

    private void OnDisable()
    {
        tempSnake.OnMove -= PathAndUpdMove;
    }

    public void SetTarget(Block block, Vector2Int pos)
    {
        targetBlock = block;
        // Replace - Food Obj
        targetPos = pos;

        PathAndUpdMove();
    }



    //private AStarSearch starSearch = new AStarSearch();

    void PathAndUpdMove()
    {
        GetPath();
        UpdateDirection();

    }

    [ContextMenu("GetPath")]
    void GetPath()
    {
        MapGrid grid = MapGrid.instance;

        if (targetBlock == null)
            return;

         
        //targetPos = Vector2Int.FloorToInt(targetBlock.transform.position); // delete this


        path = AStarSearch.StarSearch(grid, tempSnake.pos, targetPos);
    }

    void UpdateDirection()
    {
        if (path == null || path.Length == 0)
        {
            AvoidColision();
        }
        else
        {
            tempSnake.direction =  path[0] - tempSnake.pos; 
        }
    }


    void AvoidColision()
    {
        MapGrid grid = MapGrid.instance;

        if (!grid.PositionPassable(tempSnake.pos+tempSnake.direction))
        {
            if(grid.CheckPosValid(tempSnake.pos + Vector2Functions.TurnRight(tempSnake.direction)))
                tempSnake.Turn(1);
            else if (grid.CheckPosValid(tempSnake.pos + Vector2Functions.TurnLeft(tempSnake.direction)))
                tempSnake.Turn(-1);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        if (path == null || path.Length < 2)
            return;

        for (int i = 0; i < path.Length - 1; i++)
        {
            Gizmos.DrawLine((Vector3Int)path[i], (Vector3Int)path[i + 1]);
        }
    }
}
