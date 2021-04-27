using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVisual : MonoBehaviour
{
    Block block;

    Renderer render;

    [SerializeField] SpriteRenderer spriteRenderer;

    public Sprite[] tempListSprites;


    private void Awake()
    {
        block = GetComponent<Block>();

        render = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        block.OnActiveChange += ChangeActive;
    }
    private void OnDisable()
    {
        block.OnActiveChange -= ChangeActive;
    }


    [ContextMenu("TestChange")]
    void TestChange()
    {
        block.Active = !block.Active;
    }

    void ChangeActive(bool b)
    {
        if (b)
            OnActivated();
        else
            OnDeactivated();
    }


    void OnActivated()
    {
        Color tempColor = render.material.color;

        tempColor.a = 1f;

        render.material.color = tempColor;
        spriteRenderer.color = tempColor;
    }

    void OnDeactivated()
    {

        Color tempColor = render.material.color;

        tempColor.a = 0.5f;

        render.material.color = tempColor;
        spriteRenderer.color = tempColor;
    }
}
