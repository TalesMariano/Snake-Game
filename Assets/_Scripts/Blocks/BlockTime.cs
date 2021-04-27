using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockTime : Block, IBeforeDeath
{
    public string jsonWorldState;


    public void SaveWorld()
    {

    }

    public void RewindTime()
    {
        // Get reference from Game manager


        // set snakes values, ie pos, dir, node pos, & nodes

        // Set food in the whorld


    }
}

public class GameSaveState
{
    public string[] snakesJsons;

    public string[] foodJsons;



}
