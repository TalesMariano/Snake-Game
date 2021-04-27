using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public int id;

    public Vector2Int pos;
    public Vector2Int direction = Vector2Int.up;

    public float speed = 10;
    [SerializeField] float weight;

    public List<Block> nodes = new List<Block>(); // chaqnge to gget
    public List<Vector2Int> nodePos = new List<Vector2Int>();


    public bool moving = true;
    bool haveTurned = false;
    bool eatenThisMove = false;


    // Actions
    public Action OnMove;
    public Action TestCallback;



    [ContextMenu("Start Moving")]
    public void StartMoving()
    {
        moving = true;
        StopAllCoroutines();
        StartCoroutine(TestMove());

        CalculateSpeed();
    }

    void MoveOneStep()
    {
        //CalculateSpeed();

        // 
        Vector2Int nextPosition = pos + direction;

        // Check Colision

        // Check for end of map
        if(MapGrid.instance.CheckPosValid(nextPosition) == false /*|| MapGrid.instance.PositionWall(nextPosition)*/)   // if get outside map
        {
            OnColision();
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

            //return;
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
        }else if (targetBlock.blockType == BlockType.Snake)
        {
            BeforeCollision(targetBlock);

            transform.position += (Vector3Int)direction;

            pos += direction;


            haveTurned = false;

            MoveNodes();
        }

            OnMove?.Invoke();
    }

    void BeforeCollision(Block collidingEnemyBlock)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            //if(nodes[i].Active && nodes[i].GetComponent<IColission>() != null)
            if(nodes[i].Active && nodes[i] is IColission)
            {

                IColission col = nodes[i] as IColission;

                Action fCollision;// += OnColision;
                //fCollision += OnColision;
                TestCallback = OnColision;

                col.OnCollision(collidingEnemyBlock, TestCallback);


                return;
            }
        }

        OnColision();
    }


    void OnColision()
    {
        Die();
    }

    void Die()
    {
        Destroy(this.gameObject);

        /*
        foreach (var node in nodes)
        {
            Destroy(node.gameObject);
        }*/
    }


    public void AddBlock(Block block, Vector2Int pos)
    {
        nodes.Insert(0, block);
        nodePos.Insert(0, pos);
    }


    void AddNode(Vector2Int pos)
    {
        nodePos.Insert(0, pos);
    }

    // FIX - Remove Public
    public void Eat (Block node)
    {
        Debug.Log("Eat");

        node.BeingEaten();

        nodes.Insert(0, node);
        AddNode(pos);

        //MoveNodes();
    }


    void MoveNodes()
    {
        // Remove Blocks Grid
        for (int i = 0; i < nodes.Count; i++)
        {
            MapGrid.instance.RemoveBlock(nodePos[i]);
        }



        for (int i = nodes.Count-1; i >= 1; i--)
        {
            nodePos[i] = nodePos[i - 1];

            //nodes[i].transform.position = (Vector3Int)nodePos[i - 1];

            // Temp code
            // Error Overlaping blocks during ram
            //MapGrid.instance.Moveblock(nodePos[i], nodePos[i - 1]);

        }


        nodePos[0] = pos;
        //MapGrid.instance.Moveblock(nodePos[0], pos);

        for (int i = 0; i < nodes.Count; i++)
        {
            MapGrid.instance.AddBlock(nodes[i], nodePos[i]);
        }

        //nodes[0].transform.position = (Vector3Int)pos;


        
    }


    public void Turn(int dir = 1)
    {
        if (haveTurned)
            return;

        if (dir == 1)
            direction = Vector2Functions.TurnRight(direction);
        else
            direction = Vector2Functions.TurnLeft(direction);


        //transform.Rotate(Vector3.forward, -90 * dir);
        haveTurned = true;
    }

    public void SetTurn(Vector2Int dir)
    {
        direction = dir;
    }


    /// <summary>
    /// Calculate speed based on all blocks on body
    /// </summary>
    void CalculateSpeed()
    {
        float totalWeight = 0;
        foreach (var item in nodes)
        {
            totalWeight += item.Weight;
        }

        float baseWeight = 5;

        weight = Mathf.Clamp(baseWeight + totalWeight, 1, int.MaxValue);
    }

    IEnumerator TestMove()
    {
        do
        {
            if (moving)
            {
                MoveOneStep();

                yield return new WaitForSeconds(1* weight / speed);
            }


        } while (moving);
    }
}


