using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField]
    private GameObject
        ninjaPrefab,
        piratePrefab,
        wizardPrefab,
        barbarianPrefab;

    [SerializeField]
    private Tile
        tilePrefab,
        obstaclePrefab;

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
        LevelSize = new Point(11,12);
        CreateLevel();
        PlacePlayers();
    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, Tile>();

        Vector3 WorldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < 11; y++)
        {
            for (int x = 0; x < 12; x++)
            {
                if (y == 10)
                {
                    PlaceTile(x, y, WorldStart,tilePrefab);
                }
                else if (x % 2 == 0 || y % 2 == 0)
                {
                    PlaceTile(x, y, WorldStart,tilePrefab);
                }
                else
                {
                    PlaceObstacles(x, y, WorldStart,obstaclePrefab);
                }
            }
        }
    }

    private void PlaceTile(int x, int y, Vector3 worldStart, Tile prefab)
    {
        Tile newTile = Instantiate(prefab.gameObject.GetComponent<Tile>());

        newTile.GetComponent<Tile>().Setup(new Point(x, y), new Vector3(2.850601f + worldStart.x + TileSize / 2 + (TileSize * x), worldStart.y - TileSize / 2 - (TileSize * y), 0),true);

        Tiles.Add(new Point(x, y), newTile);

        Debug.Log("PlacingTiles: " + x + "," + y);
    }


    private void PlaceObstacles(int x, int y, Vector3 worldStart, Tile prefab)
    {
        Tile newTile = Instantiate(prefab.gameObject.GetComponent<Tile>());

        newTile.GetComponent<Tile>().Setup(new Point(x, y), new Vector3(2.850601f + worldStart.x + TileSize / 2 + (TileSize * x), worldStart.y - TileSize / 2 - (TileSize * y), 0),false);

        Tiles.Add(new Point(x, y), newTile);

        Debug.Log("PlacingTiles: " + x + "," + y);
    }

    public bool InBounds(Point position)
    {
        return position.X >= 0 && position.Y >= 0 && position.X < LevelSize.X && position.Y < LevelSize.Y;
    }



    private void PlaceCharacter(int x, int y, GameObject prefab)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.position = Tiles[new Point(x, y)].transform.position;
        if(prefab.GetComponent<Character>() != null)
        {
            prefab.GetComponent<Character>().GridPosition = new Point(x, y);
        }
        Debug.Log("Placing Characters:" + x + "," + y);
    }

    private void PlaceNinja()
    {
        PlaceCharacter(0, 0, ninjaPrefab);
    }
    private void PlacePirate()
    {
        PlaceCharacter(11, 0, piratePrefab);
    }

    private void PlaceWizard()
    {
        PlaceCharacter(0, 10, wizardPrefab);
    }
    private void PlaceBarbarian()   
    {
        PlaceCharacter(11, 10, barbarianPrefab);
    }
    private void PlacePlayers()
    {
        PlaceNinja();
        PlacePirate();
        PlaceWizard();
        PlaceBarbarian();
    }
}
