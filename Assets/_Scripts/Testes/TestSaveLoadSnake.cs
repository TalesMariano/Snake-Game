using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveLoadSnake : MonoBehaviour
{
    public Snake snake;

    [TextArea(3,10)]
    public string json;


    [ContextMenu("Save Snake")]
    void SaveSnake()
    {
        json = JsonUtility.ToJson(snake, true);
    }

    [ContextMenu("Load Snake")]
    void LoadSnake()
    {
        JsonUtility.FromJsonOverwrite(json, snake);
    }
}
