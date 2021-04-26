using System;
using System.Collections.Generic;
using UnityEngine;

public class Block 
{
    public int id;

    public Sprite sprite;

    bool active = true;
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
    
    public void BeingEaten()
    {
        if (blockType == BlockType.Food)
            blockType = BlockType.Snake;

        OnEat?.Invoke();
        OnEatId?.Invoke(id);


        OnEat = null;
    }
}

public enum BlockType
{
    Null,
    Food,
    Snake,
    Wall
}
