using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<Player> players = new List<Player>();  // Fix - Remove public


    [SerializeField] public List<Snake> snakesPlayers = new List<Snake>(); // Fix - Make private
    [SerializeField] private List<Snake> snakesAI = new List<Snake>();
    [SerializeField] private List<Food> foods = new List<Food>();

    [Header("References")]
    public MapGrid map;
    public FoodSpawner foodSpawner;
    //public TempSnakeSpawner tempSnakeSpawner;
    public TestBuildSnake2 tempSnakeSpawner;

    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion


    #region TimeRewind
    public void LoadWorldState(string jsonWorldState)
    {
        TestWorldState worldState = JsonUtility.FromJson<TestWorldState>(jsonWorldState);

        // Load Snakes Player
        /*
        for (int i = 0; i < snakesPlayers.Count; i++)
        {
            snakesPlayers[i].PrepareToLoad();
            JsonUtility.FromJsonOverwrite(worldState.jsonSnakesPl[i], snakesPlayers[i]);
            // Add call event onLoad            
        }*/

        // Test new load Snake
        for (int i = 0; i < snakesPlayers.Count; i++)
        {
            snakesPlayers[i].PrepareToLoad();
            worldState.saveStatePlayers[i].LoadSnake(snakesPlayers[i]);
        }



        // Load Snakes AI
        for (int i = 0; i < snakesAI.Count; i++)
        {
            snakesAI[i].PrepareToLoad();
            JsonUtility.FromJsonOverwrite(worldState.jsonSnakesAi[i], snakesAI[i]);
            // Add call event onLoad            
        }

        // Spawn new food, move Food
    }

    public string SaveWorldState()
    {
        TestWorldState worldState = new TestWorldState();
        // Save Snakes player
        string[] jsonSnakesPl = new string[snakesPlayers.Count];
        for (int i = 0; i < jsonSnakesPl.Length; i++)
        {
            jsonSnakesPl[i] = JsonUtility.ToJson(snakesPlayers[i], true);
        }
        worldState.jsonSnakesPl = jsonSnakesPl;

        // Test New save
        SnakeSaveState[] snakeSaves = new SnakeSaveState[snakesPlayers.Count];
        for (int i = 0; i < snakeSaves.Length; i++)
        {
            snakeSaves[i] = new SnakeSaveState(snakesPlayers[i]);
        }
        worldState.saveStatePlayers = snakeSaves;



        // Save Snakes AI
        string[] jsonSnakesAi = new string[snakesAI.Count];
        for (int i = 0; i < jsonSnakesAi.Length; i++)
        {
            jsonSnakesAi[i] = JsonUtility.ToJson(snakesAI[i], true);
        }
        worldState.jsonSnakesAi = jsonSnakesAi;

        // Save Food Pos
        Vector2Int[] foodPoss = new Vector2Int[foods.Count];
        for (int i = 0; i < foodPoss.Length; i++)
        {
            foodPoss[i] = foods[i].pos;
        }
        worldState.jsonFoodsPos = foodPoss;

        return JsonUtility.ToJson(worldState, true);
    }


    #endregion

    #region Score

    void AddScore(int id, int scoreAdd)
    {
        try
        {
            players[id].score += scoreAdd;
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
            throw;
        } 
    }

    #endregion


    void SpawnFood(int id)
    {
        Vector2Int foodPos;
        // Get Fair Position Both Player
        if (snakesPlayers[id].alive && snakesAI[id].alive)  // If both Player Alive
            foodPos = map.GetFairEmptyPosition(snakesPlayers[id].pos, snakesAI[id].pos);
        else
            foodPos = map.RandomEmptyPos();




        Food newFood = foodSpawner.SpawnRandomFood(foodPos);

        newFood.block.playerId = id;

        newFood.block.OnEat += () => { foods.Remove(newFood); };


        /*
        if (foods.Count > 0) // <------------
            foods.RemoveAt(id);
            */

        foods.Insert(id, newFood);

        newFood.block.OnEatId += SpawnFood; // Respawn food when eaten

        map.AddBlock(newFood.block, foodPos);

        snakesAI[id].GetComponent<AIController>().SetTarget(newFood.block, foodPos);
    }



    [ContextMenu("AddNewPlayer")]
    void TempAddNewPlayer()
    {
        AddNewPlayer();
    }

    public void AddNewPlayer(KeyCode[] keys)
    {
        AddNewPlayer(keys[0], keys[1]);
    }


    public void AddNewPlayer(KeyCode key1 = KeyCode.Z, KeyCode key2 = KeyCode.X)
    {
        int id = players.Count;

        // Add player, with id, score and stuff
        players.Add( new Player(id, key1, key2));



        // spawn player snake
        Snake playerSnake = tempSnakeSpawner.CreatePlayer();
        playerSnake.id = id;
        playerSnake.OnEatScore += AddScore;
        snakesPlayers.Add(playerSnake);

        // set snake controls
        PlayerController pc = playerSnake.GetComponent<PlayerController>();
        pc.keyLeft = key1;
        pc.keyRight = key2;

        // Add AI snake
        Snake aiSnake = tempSnakeSpawner.CreateAI();
        aiSnake.id = id;
        snakesAI.Add(aiSnake);

        // Spawn food
        SpawnFood(id);


        // OBS: Set playe rcontotrol and stuff
    }

    [ContextMenu("StartGame")]
    public void StartGame()
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


    public enum GameState
    {
        AddPlayers,
        Gameplay,
        GameOver
    }
}
