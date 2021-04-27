using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player[] players;


    [SerializeField] private List<Snake> snakesPlayers = new List<Snake>();
    [SerializeField] private List<Snake> snakesAI = new List<Snake>();
    [SerializeField] private List<Block> foods = new List<Block>();

    [Header("References")]
    public MapGrid map;
    public TempFoodSpawner foodSpawner;
    //public TempSnakeSpawner tempSnakeSpawner;
    public TestBuildSnake2 tempSnakeSpawner;


    [ContextMenu("Spawn Food")]
    void SpawnFoodOld()
    {
        Vector2Int pos = map.RandomEmptyPos();

        Block newFood = foodSpawner.SpawnFood(pos);

        foods.Add(newFood);

        newFood.OnEat += SpawnFoodOld; // <-------------------

        map.AddBlock(newFood, pos);
    }

    [ContextMenu("TestRemove")]
    void TestRemove()
    {
        SpawnFood(0);
    }


    void SpawnFood(int id)
    {
        

        Vector2Int pos = map.RandomEmptyPos();

        Block newFood = foodSpawner.SpawnFood(pos);

        newFood.id = id;

        print("foods.Count " + foods.Count + " _ id " + id);
        if (foods.Count > 0) // <------------
            foods.RemoveAt(id);

        foods.Insert(id, newFood);

        newFood.OnEatId += SpawnFood; // <-------------------

        map.AddBlock(newFood, pos);

        snakesAI[id].GetComponent<AIController>().SetTarget(newFood, pos);
    }

    [ContextMenu("AddNewPlayer")]
    public void AddNewPlayer()
    {
        int id = 0;

        // Add player, with id, score and stuff


        // spawn player snake
        Snake playerSnake = tempSnakeSpawner.CreatePlayer();
        snakesPlayers.Add(playerSnake);

        // set snake controls

        // Add AI snake
        Snake aiSnake = tempSnakeSpawner.CreateAI();
        snakesAI.Add(aiSnake);

        // Spawn food
        SpawnFood(id);


        // OBS: Set playe rcontotrol and stuff
    }

    [ContextMenu("StartGame")]
    void StartGame()
    {
        foreach (var item in snakesPlayers)
        {
            item.StartMoving();
        }

        foreach (var item in snakesAI)
        {
            item.StartMoving();
        }

    }

    void FoodEaten(int foodId)
    {

        // spawn new food

        // ? add score

        // set food to ai Snake
    }
}
