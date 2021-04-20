using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVisual : MonoBehaviour
{
    public MapGrid mapGrid;

    public SpriteRenderer mapSprite;

    void Start()
    {
        mapSprite.size = new Vector2(mapGrid.size.x, mapGrid.size.y);
    }
}
