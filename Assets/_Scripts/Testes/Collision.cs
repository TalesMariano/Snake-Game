using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : Block, IColission
{
    public void OnCollision(Block otherBlock, Action callback)
    {
        CollisionRam(otherBlock, callback);
    }

    void CollisionRam(Block otherBlock, Action callback)
    {
        // Disable this
        Active = false;

        // Disable coliding Block
        otherBlock.Active = false;
        // Move foward
        //do Nothing should move foward already
    }

    void BaseCollision(Block otherBlock, Action callback)
    {
        callback?.Invoke();
    }
}
