using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private int rows;
    private int cols;
    private float tilewidth;
    private float tileheight;
    public GameObject tile;
    List<GameObject> allTiles;
    
    void Start()
    {
        rows = 13;
        cols = 12;
        tilewidth = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        tileheight = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        allTiles = new List<GameObject>();
        CreateGrid();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceTile(int x, int y, Vector3 worldStart)
    {
        GameObject newTile = Instantiate(tile);
        newTile.transform.position = new Vector3(2.5f + worldStart.x + tilewidth / 2 + (tilewidth * x),worldStart.y - tileheight / 2 - (tileheight * y), 0);
        allTiles.Add(newTile);
    }

    private void CreateGrid()
    {
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < cols; y++)
        {
            for(int x = 0; x < rows; x++)
            {
                PlaceTile(x, y, worldStart);
            }
        }
    }
}
