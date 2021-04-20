using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player[] players;


    [SerializeField] private Snake[] snakes;
    [SerializeField] private Snake[] snakesAI;
    [SerializeField] private Block[] foods;

    [Header("References")]
    public MapGrid map;
    public TempFoodSpawner foodSpawner;



    void Start()
    {

    }
    
    void Update()
    {

    }

    public void StartGame()
    {

    }

    [ContextMenu("Spawn Food")]
    void SpawnFood()
    {
        Vector2Int pos = map.RandomEmptyPos();

        Block newFood = foodSpawner.SpawnFood(pos);

        newFood.OnEat += SpawnFood;

        map.AddBlock(newFood, pos);
    }
}
