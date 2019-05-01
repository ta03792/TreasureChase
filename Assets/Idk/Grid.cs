using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{
    private int rows;
    private int cols;
    private float tileSize;
    private float tileSize2;
    public GameObject tile;
    public GameObject tile2;
    public List<GameObject> allTiles;
    // Start is called before the first frame update
    void Start()
    {
        rows = 12;
        cols = 16;
        tileSize = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        tileSize2 = tile2.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        allTiles = new List<GameObject>();
        CreateGrid();
    }
    
    private void PlaceTile(int x, int y, Vector3 worldStart)
    {
        GameObject newTile = Instantiate(tile);
        newTile.transform.position = new Vector3(worldStart.x + tileSize / 2 + (tileSize * x), worldStart.y - tileSize / 2 - (tileSize * y), 0);
    }

    private void PlaceTile2(int x, int y, Vector3 worldStart)
    {
        GameObject newTile2 = Instantiate(tile2);
        newTile2.transform.position = new Vector3(worldStart.x + tileSize2 / 2 + (tileSize2 * x), worldStart.y - tileSize2 / 2 - (tileSize2 * y), 0);
    }
    private void CreateGrid()
    {
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 1; y < 11; y++)
        {
            for (int x = 1; x < 15; x++)
            {
                PlaceTile(x, y, worldStart);
            }
        }
        for (int y = 0; y < rows; y++)

        { PlaceTile2(0, y, worldStart); }

        for (int x = 0; x < cols; x++)

        { PlaceTile2(x, 0, worldStart); }

        for (int x = 0; x < cols; x++)

        { PlaceTile2(x, 11, worldStart); }

        for (int y = 0; y < rows; y++)

        { PlaceTile2(15, y, worldStart); }



    }
    //allTiles[0].GetComponent<Tile>().Occupied = true;
    //Update is called once per frame
    void Update()
    {

    }
}
