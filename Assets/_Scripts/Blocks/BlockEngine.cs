using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockEngine : Block
{
    [SerializeField] int activeWeight = -1;

    public override int Weight
    {
        get {
            if (Active)
                return activeWeight;
            else
                return weight;
        }
    }
}
