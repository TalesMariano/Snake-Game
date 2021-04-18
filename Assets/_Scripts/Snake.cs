using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public int id;

    public float speed = 10;

    List<Transform> nodes = new List<Transform>();
    public Transform[] tempNodes;

    public bool moving = true;
    bool haveTurned = false;
    bool eatenThisMove = false;


    
    void Start()
    {
        // Temp Add Nodes
        nodes.AddRange(tempNodes);


        StartCoroutine(TestMove());
    }
    
    void Update()
    {
        
    }

    void Move()
    {
        transform.position += transform.up;

        haveTurned = false;

        MoveNodes();
    }

    void Die()
    {

    }

    void Eat (Block node)
    {
        nodes.Insert(0, node.transform);
        //MoveNodes();
    }


    void MoveNodes()
    {
        
        for (int i = nodes.Count-1; i >= 1; i--)
        {
            nodes[i].position = nodes[i - 1].position;
        }

        nodes[0].position = transform.position;
    }


    public void Turn(int dir = 1)
    {
        if (haveTurned)
            return;


        transform.Rotate(Vector3.forward, -90 * dir);
        haveTurned = true;
    }


    IEnumerator TestMove()
    {
        do
        {
            if (moving)
            {
                Move();

                yield return new WaitForSeconds(1*10 / speed);
            }


        } while (true);
    }
}
