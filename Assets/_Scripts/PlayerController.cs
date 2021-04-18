using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode keyLeft;
    public KeyCode keyRight;


    public Snake tempSnake;


    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(keyLeft))
        {
            tempSnake.Turn(-1);
        }

        if (Input.GetKeyDown(keyRight))
        {
            tempSnake.Turn(1);
        }
    }
}
