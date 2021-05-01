using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Block 
{
    public int playerId;
    public int score =100;

    public Sprite sprite;

    [SerializeField] bool active = true;
    public bool Active
    {
        get { return active; }
        set
        {
            active = value;
            OnActiveChange?.Invoke(active);
        }
    }

    public Action<bool> OnActiveChange;



    public BlockType blockType;

    protected int weight = 1;

    public virtual int Weight
    {
        get { return weight; }
    }

    public Action OnEat;
    public Action<int> OnEatId;
    
    public virtual void BeingEaten()
    {
        if (blockType == BlockType.Food)
            blockType = BlockType.Snake;

        OnEat?.Invoke();
        OnEatId?.Invoke(playerId);


        OnEat = null;
    }


    public object Copy()
    {
        return this.MemberwiseClone();
    }
}

public enum BlockType
{
    Null,
    Food,
    Snake,
    Wall
}
