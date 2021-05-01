using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SnakeSaveState : MonoBehaviour
{
    public Snake testSnake;

    public string jsonSnake;

    public string[] jsonNodes;

    public Type[] blockTypes;

    public SnakeSaveState (Snake snake)
    {
        SaveJson(snake);
        SaveTypes(snake);
    }

    public void LoadSnake(Snake snake)
    {
        //LoadTypes(snake);
        JsonUtility.FromJsonOverwrite(jsonSnake, snake);
    }

    


    public void SaveJson(Snake snake)
    {
        jsonSnake = JsonUtility.ToJson(snake, true);
    }

    public void SaveTypes(Snake snake)
    {
        blockTypes = new Type[snake.nodes.Count];

        for (int i = 0; i < snake.nodes.Count; i++)
        {
            blockTypes[i] = snake.nodes[i].GetType();
        }
    }
    /*
    void SaveNodes(Snake snake)
    {
        jsonNodes = new string[snake.nodes.Count];
        for (int i = 0; i < jsonNodes.Length; i++)        {
            jsonNodes[i] = JsonUtility.ToJson(snake.nodes.[i]);
        }
    }*/

    void LoadNodes(Snake snake)
    {
        // new nodes
        //Block[] blocks = new Block[jsonNodes.Length];

        for (int i = 0; i < jsonNodes.Length; i++)
        {
            //blocks[i] = JsonUtility.FromJson<blockTypes[i]>(jsonNodes[i], blockTypes[i]);
            ;
        }

        //snake.nodes = new List<Block>(blocks);
    }

    
    /*
    void LoadTypes(Snake snake)
    {
        snake.nodes = null;

        // Get all public constructors for types[0]
        var ctors = blockTypes[0].GetConstructors(BindingFlags.Public);

        // Create a class of types[0] using the first constructor
        var test = ctors[0].Invoke(new object[] { });

        snake.nodes.Add(test);

        for (int i = 0; i < blockTypes.Length; i++)
        {
            var instance = Activator.CreateInstance(blockTypes[i]);
            snake.nodes.Add(instance);
        }
    }*/
}
