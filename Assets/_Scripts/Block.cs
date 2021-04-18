using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockType blockType;

    
    void Start()
    {
        
    }

    
    void BeingEaten()
    {
        if (blockType == BlockType.Food)
            blockType = BlockType.Snake;
    }
}

public enum BlockType
{
    Null,
    Food,
    Snake,
    Wall
}
