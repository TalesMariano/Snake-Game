using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public int id;

    public Vector2Int pos;
    public Vector2Int direction = Vector2Int.up;

    public float speed = 10;

    List<Transform> nodes = new List<Transform>();
    List<Vector2Int> nodePos = new List<Vector2Int>();


    public bool moving = true;
    bool haveTurned = false;
    bool eatenThisMove = false;



    [ContextMenu("Start Moving")]
    public void StartMoving()
    {
        moving = true;
        StopAllCoroutines();
        StartCoroutine(TestMove());

        // Temp
        foreach (var item in nodes)
        {
            item.transform.parent = null;
        }
    }

    void MoveOneStep()
    {
        // 
        Vector2Int nextPosition = pos + direction;

        // Check Colision

        // Check for end of map
        if(MapGrid.instance.CheckPosValid(nextPosition) == false)   // if get outside map
        {
            Die();
            return;
        }

        // 
        Block targetBlock = MapGrid.instance.CheckBlockPosition(nextPosition);

        // is empty where its going
        if (targetBlock == null)
        {
            transform.position += (Vector3Int)direction;

            pos += direction;


            haveTurned = false;

            MoveNodes();

            return;
        }

        //its food
        else if (targetBlock.blockType == BlockType.Food)
        {
            Eat(targetBlock);

            MapGrid.instance.RemoveBlock(nextPosition);



            transform.position += (Vector3Int)direction;

            pos += direction;


            haveTurned = false;

            //MoveNodes();
        }


    }

    void Die()
    {
        Destroy(this.gameObject);

        foreach (var node in nodes)
        {
            Destroy(node.gameObject);
        }
    }


    public void AddBlock(Block block, Vector2Int pos)
    {
        nodes.Insert(0, block.transform);
        nodePos.Insert(0, pos);
    }


    void AddNode(Vector2Int pos)
    {
        nodePos.Insert(0, pos);
    }


    void Eat (Block node)
    {
        Debug.Log("Eat");

        node.BeingEaten();

        nodes.Insert(0, node.transform);
        AddNode(pos);

        //MoveNodes();
    }


    void MoveNodes()
    {
        for (int i = nodes.Count-1; i >= 1; i--)
        {
            nodePos[i] = nodePos[i - 1];

            nodes[i].position = (Vector3Int)nodePos[i - 1];

            // Temp code
            MapGrid.instance.Moveblock(nodePos[i], nodePos[i - 1]);

        }

        nodePos[0] = pos;
        MapGrid.instance.Moveblock(nodePos[0], pos);


        nodes[0].position = (Vector3Int)pos;
    }


    public void Turn(int dir = 1)
    {
        if (haveTurned)
            return;

        if (dir == 1)
            direction = TurnRight(direction);
        else
            direction = TurnLeft(direction);


        transform.Rotate(Vector3.forward, -90 * dir);
        haveTurned = true;
    }


    /// <summary>
    /// Calculate speed based on all blocks on body
    /// </summary>
    void CalculateSpeed()
    {

    }

    IEnumerator TestMove()
    {
        do
        {
            if (moving)
            {
                MoveOneStep();

                yield return new WaitForSeconds(1*10 / speed);
            }


        } while (moving);
    }


    Vector2Int TurnRight(Vector2Int dir)
    {
        if (dir == Vector2Int.up)
            return Vector2Int.right;
        else if (dir == Vector2Int.right)
            return Vector2Int.down;
        else if (dir == Vector2Int.down)
            return Vector2Int.left;
        else if (dir == Vector2Int.left)
            return Vector2Int.up;
        else
        {
            Debug.LogError("ERROR");
            return dir; // ERR
        } 
    }

    Vector2Int TurnLeft(Vector2Int dir)
    {
        if (dir == Vector2Int.up)
            return Vector2Int.left;
        else if (dir == Vector2Int.left)
            return Vector2Int.down;
        else if (dir == Vector2Int.down)
            return Vector2Int.right;
        else if (dir == Vector2Int.right)
            return Vector2Int.up;
        else
        {
            Debug.LogError("ERROR");
            return dir; // ERR
        }
    }
}


