using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject prefabFood;

    [SerializeField] ListBlocks listBlocks;

    public Food SpawnRandomFood(Vector2Int foodPos)
    {
        int numRandomFood = Random.Range(0, System.Enum.GetNames(typeof(ListBlocks.BlockTypes)).Length);

        GameObject go = Instantiate(prefabFood, (Vector3Int)foodPos, Quaternion.identity) as GameObject;

        Food food = go.GetComponent<Food>();

        food.SetBlock(listBlocks.GetBlock(numRandomFood));

        return food;
    }
}
