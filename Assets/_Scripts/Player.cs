using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Player
{
    public int id;
    public int score;
    public KeyCode keyLeft;
    public KeyCode keyRigth;

    public Color color;

    public Player(int id, KeyCode keyLeft, KeyCode keyRigth)
    {
        this.id = id;
        this.keyLeft = keyLeft;
        this.keyRigth = keyRigth;
    }
}
