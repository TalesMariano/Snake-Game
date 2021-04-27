using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Food))]
public class FoodVisual : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    Food food;

    private void Start()
    {
        food = GetComponent<Food>();


        spriteRenderer.sprite = food.block.sprite;
    }

}
