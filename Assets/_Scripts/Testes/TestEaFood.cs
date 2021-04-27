using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEaFood : MonoBehaviour
{
    public Snake snake;

    public Food food;

    [ContextMenu("EatFood")]
    void EatFood()
    {
        snake.Eat(food.block);
    }
}
