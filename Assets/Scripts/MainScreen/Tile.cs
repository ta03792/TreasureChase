using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Point GridPosition { get; private set; }

    private SpriteRenderer spriteRenderer;
   

    public bool Walkable { get; set; }

    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2(GetComponent<SpriteRenderer>().bounds.center.x, GetComponent<SpriteRenderer>().bounds.center.y);
        }
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Setup(Point gridPos, Vector3 worldPos,bool walkable)
    {
        this.Walkable = walkable;
        this.GridPosition = gridPos;
        transform.position = worldPos;
    }
}
