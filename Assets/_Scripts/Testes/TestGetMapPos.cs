using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetMapPos : MonoBehaviour
{
    public  Vector2Int targetPos;

    public Block block;
    
    [ContextMenu("GetBlock")]
    public void GetBlock()
    {
        block = MapGrid.instance.CheckBlockPosition(targetPos);

        Debug.Log(block);
    }
}
