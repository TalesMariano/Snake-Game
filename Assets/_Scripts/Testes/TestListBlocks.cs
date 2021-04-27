using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestListBlocks : ScriptableObject
{
    public BlockEngine blockEngine;


    public BlockTypes blockEnum;

    public Block[] blockTypes;

    public List<TestObject> listObjsNova = new List<TestObject>
    {
        new TestObjectChildOne (),
        new TestObjectChildTwo ()
    };

    public List<TestObjectChildOne> listObjs;


    public List<Vector3> vecs = new List<Vector3>
    {
        Vector3.up,

        new Vector3(0,1,2)
    };

    void Test()
    {
        Type.GetType("TestObjectChildOne");
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
