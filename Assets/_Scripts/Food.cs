using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Vector2Int pos;


    [Space]
    public ListBlocks listBlocks;

    public ListBlocks.BlockTypes blockType;

    public Block block; // Set get here

    private void Awake()
    {
        block = GetBlock();
    }



    private void OnEnable()
    {
        block.OnEatId += DestroyThis;
    }

    private void OnDisable()
    {
        block.OnEatId -= DestroyThis;
    }


    public Block GetBlock()
    {
        return listBlocks.GetBlock(blockType);
    }

    void DestroyThis(int i = 0)
    {
        Destroy(this.gameObject);
    }
}
