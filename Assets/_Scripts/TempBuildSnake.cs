using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBuildSnake : MonoBehaviour
{
    public GameObject nodePrefab;

    public int numNodes = 3;

    private void Start()
    {
        if(GetComponent<Snake>())
            BuildSnake(GetComponent<Snake>());
    }


    [ContextMenu("BuildSnake")]
    public void BuildSnake(Snake snake)
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2Int pos = snake.pos + Vector2Int.down * (2-i);

            GameObject go = (GameObject)Instantiate(nodePrefab, (Vector3Int)pos, Quaternion.identity);

            print(go);

            Block node = go.GetComponent<Block>();

            node.blockType = BlockType.Snake;

            MapGrid.instance.AddBlock(node, pos);

            snake.AddBlock(node, pos);

        }


    }
}
