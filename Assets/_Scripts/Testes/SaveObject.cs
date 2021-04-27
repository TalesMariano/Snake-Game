using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject
{
    [SerializeField] private Player[] players;

    [SerializeField] private List<Snake> snakesPlayers = new List<Snake>();
    [SerializeField] private List<Snake> snakesAI = new List<Snake>();
    [SerializeField] private List<Block> foods = new List<Block>();




    //This is forGame MAnager
    void LoadSave()
    {



    }
}
