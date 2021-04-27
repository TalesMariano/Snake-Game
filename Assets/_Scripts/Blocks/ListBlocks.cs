using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ListBlocks : ScriptableObject
{
    [Header("Blocks Base")]
    [SerializeField] BlockEngine blockEngine;
    [SerializeField] BlockRam blockRam;
    [SerializeField] BlockTime blockTime;


    public Block GetBlock(int numBlock)
    {
        // Fix - Check if int is valid

        return GetBlock((BlockTypes)numBlock);
    }

    public Block GetBlock(BlockTypes blockTypes)
    {
        switch (blockTypes)
        {
            case BlockTypes.BlockEngine:
                return (BlockEngine)blockEngine.Copy();
            case BlockTypes.BlockRam:
                return (BlockRam)blockRam.Copy();
            case BlockTypes.BlockTime:
                return (BlockTime)blockTime.Copy();
            default:
                return null;
        }
    }

    public Dictionary<BlockTypes, Block> dictBlocks = new Dictionary<BlockTypes, Block>
    {
        {BlockTypes.BlockEngine, new BlockEngine() },
        {BlockTypes.BlockRam, new BlockRam() },
        {BlockTypes.BlockTime, new BlockTime() }
    };

    public enum BlockTypes
    {
        BlockEngine,
        BlockRam,
        BlockTime
    }
}
