using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColission 
{
    void OnCollision(Block otherBlock, Action callback);

}
