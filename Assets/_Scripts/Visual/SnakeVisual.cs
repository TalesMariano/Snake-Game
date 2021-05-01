using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeVisual : MonoBehaviour
{
    [SerializeField] private Snake snake;

    [SerializeField] Transform snakeHead;


    public LineRenderer lineRenderer;

    private List< SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

    void Awake()
    {
        if(!snake) snake = GetComponent<Snake>();

        ColorSnake(ColorFunctions.RandomColor());

        FixNumberSpriteRenderer();
    }

    private void Update()
    {
        if (!snake.alive)
        {
            ClearSnake();
            return;
        }
            


        UpdateLineRenderer();
        UpdateSprites();

        RotateHead();
    }

    void UpdateLineRenderer()
    {
        lineRenderer.positionCount = snake.nodePos.Count;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, (Vector3Int)snake.nodePos[i] + (Vector3.back * 0.5f));
        }

    }

    void UpdateSprites()
    {
        //int numSprites = snake.

        if (spriteRenderers.Count != snake.nodes.Count)
            FixNumberSpriteRenderer();


        for (int i = 0; i < snake.nodes.Count; i++)
        {
            spriteRenderers[i].transform.position = (Vector3Int)snake.nodePos[i] + (Vector3.back * 1);   // Change pos
            spriteRenderers[i].sprite = snake.nodes[i].sprite;
            spriteRenderers[i].color = snake.nodes[i].Active ? Color.white : (Color.white / 3);
        }


        //Upd head pos
        snakeHead.position = (Vector3Int)snake.pos;
    }

    void ClearSnake()
    {
        foreach (var sr in spriteRenderers)
        {
            sr.color = Color.clear;
        }

        lineRenderer.positionCount = 0;

        snakeHead.gameObject.SetActive(false);
    }


    [ContextMenu("FixNumberSpriteRenderer")]
    void FixNumberSpriteRenderer()
    {

        if(spriteRenderers.Count > snake.nodes.Count)
        {
            for (int i = spriteRenderers.Count-1; i > snake.nodes.Count-1; i--)
            {
                Destroy(spriteRenderers[i].gameObject);
                spriteRenderers.RemoveAt(i);
            }
        }
        else if(spriteRenderers.Count < snake.nodes.Count)
        {
            for (int i = spriteRenderers.Count; i < snake.nodes.Count; i++)
            {
                CreateSprite();
            }
        }
    }

    void CreateSprite()
    {
        GameObject go = new GameObject();

        SpriteRenderer sr =  go.AddComponent<SpriteRenderer>();

        go.transform.parent = this.transform;

        spriteRenderers.Add(sr);
    }

    [ContextMenu("RotateHead")]
    void RotateHead()
    {
        snakeHead.rotation =  Quaternion.LookRotation((Vector3Int) snake.direction, Vector3.back);
    }

    void ColorSnake(Color color)
    {
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }


}
