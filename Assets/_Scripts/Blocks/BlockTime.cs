using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockTime : Block, IBeforeDeath
{
    public string jsonWorldState;

    public override void BeingEaten()
    {
        SaveWorld();

        base.BeingEaten();
    }


    public void SaveWorld()
    {
        jsonWorldState = GameManager.instance.SaveWorldState();
    }

    public void RewindTime()
    {
        GameManager.instance.LoadWorldState(jsonWorldState);

        // Get reference from Game manager


        // set snakes values, ie pos, dir, node pos, & nodes

        // Set food in the whorld


    }

    public bool DoBeforeDeath()
    {
        RewindTime();

        return false;
    }
}

public class GameSaveState
{
    public string[] snakesJsons;

    public string[] foodJsons;



}
