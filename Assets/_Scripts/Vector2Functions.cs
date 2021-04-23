using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame
{
    /*
    */
}

public class Vector2Functions
{
    public static Vector2Int TurnRight(Vector2Int dir)
    {
        if (dir == Vector2Int.up)
            return Vector2Int.right;
        else if (dir == Vector2Int.right)
            return Vector2Int.down;
        else if (dir == Vector2Int.down)
            return Vector2Int.left;
        else if (dir == Vector2Int.left)
            return Vector2Int.up;
        else
        {
            Debug.LogError("ERROR");
            return dir; // ERR
        }
    }

    public static Vector2Int TurnLeft(Vector2Int dir)
    {
        if (dir == Vector2Int.up)
            return Vector2Int.left;
        else if (dir == Vector2Int.left)
            return Vector2Int.down;
        else if (dir == Vector2Int.down)
            return Vector2Int.right;
        else if (dir == Vector2Int.right)
            return Vector2Int.up;
        else
        {
            Debug.LogError("ERROR");
            return dir; // ERR
        }
    }
}
