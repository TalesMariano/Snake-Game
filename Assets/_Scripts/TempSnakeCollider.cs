﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSnakeCollider : MonoBehaviour
{
    public Snake snake;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Block")
        {
            Block b = other.GetComponent<Block>();

            
        }
    }
}
