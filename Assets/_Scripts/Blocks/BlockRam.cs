﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockRam : Block, IColission
{
    public void OnCollision(Block otherBlock, Action callback)
    {
        // Disable this block
        Active = false;

        // Disable coliding Block
        otherBlock.Active = false;

        // Move snake foward
        //do Nothing should move foward already
    }
}
