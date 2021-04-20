using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;



    public Block SpawnFood(Vector2Int pos)
    {
        GameObject go = Instantiate(foodPrefab, (Vector3Int)pos, Quaternion.identity) as GameObject;

        return go.GetComponent<Block>();
    }
}
