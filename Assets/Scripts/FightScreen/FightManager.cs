using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FightManager : Singleton<LevelManager>
{


    private int number_of_traps;

    [SerializeField]
    private Tile
        tilePrefab;

    private Point LevelSize;

    public Dictionary<Point, Tile> Tiles { get; set; }


    public float TileSize
    {
        get
        {
            return tilePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        number_of_traps = 0;
        LevelSize = new Point(15, 11);
        CreateLevel();
    }

    private void CreateLevel()
    {
        Vector3 WorldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < LevelSize.Y; y++)
        {
            for (int x = 0; x < LevelSize.X; x++)
            {
                
                PlaceTile(x, y, WorldStart, tilePrefab);    
            }
        }
    }

    private void PlaceTile(int x, int y, Vector3 worldStart, Tile prefab)
    {
        Tile newTile = Instantiate(prefab.gameObject.GetComponent<Tile>());

        newTile.GetComponent<Tile>().Setup(new Point(x, y), new Vector3(worldStart.x + TileSize / 2 + (TileSize * x), worldStart.y - TileSize / 2 - (TileSize * y), 0), true);
    }
}
