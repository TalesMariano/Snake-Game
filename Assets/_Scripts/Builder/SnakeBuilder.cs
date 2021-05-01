using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBuilder : MonoBehaviour
{
    public ListBlocks listBlocks;

    public GameObject snakePrefab;

    /*
    public Snake TempBuildSnake(Vector2Int pos, Vector2Int dir, int[] arrayNodeTypes, Vector2Int[] nodesPos = null)
    {

        Snake newSnake = new Snake();

        newSnake.pos = pos;

        newSnake.direction = dir;

        // create nodePos if null
        if(nodesPos == null || nodesPos.Length == 0)
        {
            nodesPos = new Vector2Int[arrayNodeTypes.Length];
            for (int i = 0; i < arrayNodeTypes.Length; i++)
            {
                nodesPos[i] = pos + dir * 1;
            }
        }


        for (int i = arrayNodeTypes.Length-1; i >= 0; i--)
        {
            newSnake.AddBlock(listBlocks.GetBlock(arrayNodeTypes[i]), nodesPos[i]);
        }



        return null;
    }*/



    public void ModifySnakeNodes(Snake snake, int[] arrayNodeTypes)
    {
        // ajust node number

        //Can be a problem if ther is not enought NodePos

        // Replace nodes
        snake.nodes = null;

        for (int i = 0; i < arrayNodeTypes.Length; i++)
        {
            snake.nodes.Add(listBlocks.GetBlock(arrayNodeTypes[i]));
        }


        
    }


}
