using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSnakeSpawner : MonoBehaviour
{
    public GameObject snakePrefab;

    public Vector3 location;



    public Snake SpawnSnake()
    {
        return Instantiate(snakePrefab, location, Quaternion.identity).GetComponent<Snake>();
    }
}
