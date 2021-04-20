using System;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockType blockType;

    public int weight = 1;

    public Action OnEat;
    
    public void BeingEaten()
    {
        if (blockType == BlockType.Food)
            blockType = BlockType.Snake;

        OnEat?.Invoke();

        OnEat = null;
    }
}

public enum BlockType
{
    Null,
    Food,
    Snake,
    Wall
}
