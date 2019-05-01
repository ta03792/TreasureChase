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

    private int number_of_traps;

    [SerializeField]
    private Tile
        tilePrefab,
        obstaclePrefab,
        beartrap;

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
        LevelSize = new Point(15,11);
        CreateLevel();
        PlacePlayers();
    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, Tile>();

        Vector3 WorldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < LevelSize.Y; y++)
        {
            for (int x = 0; x < LevelSize.X; x++)
            {
                if (y == 10)
                {
                    PlaceTile(x, y, WorldStart,tilePrefab);
                }
                else if (x % 2 == 0 || y % 2 == 0)
                {
                    PlaceTile(x, y, WorldStart,tilePrefab);
                    if(Random.Range(0,20) == 1 && number_of_traps <= 9 )
                    {
                        PlaceHazards(x, y, WorldStart, beartrap);
                        number_of_traps += 1;
                    }
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

            newTile.GetComponent<Tile>().Setup(new Point(x, y), new Vector3(worldStart.x + TileSize / 2 + (TileSize * x), worldStart.y - TileSize / 2 - (TileSize * y), 0),true);

        Tiles.Add(new Point(x, y), newTile);
    }


    private void PlaceObstacles(int x, int y, Vector3 worldStart, Tile prefab)
    {
        Tile newTile = Instantiate(prefab.gameObject.GetComponent<Tile>());

        newTile.GetComponent<Tile>().Setup(new Point(x, y), new Vector3(worldStart.x + TileSize / 2 + (TileSize * x), worldStart.y - TileSize / 2 - (TileSize * y), 0),false);

        Tiles.Add(new Point(x, y), newTile);
    }

    private void PlaceHazards(int x, int y, Vector3 worldStart, Tile hazard)
    {
        Tile beartrap = Instantiate(hazard.gameObject.GetComponent<Tile>());

        beartrap.GetComponent<Tile>().Setup(new Point(x, y), new Vector3(worldStart.x + TileSize / 2 + (TileSize * x), worldStart.y - TileSize / 2 - (TileSize * y), 0), true);
    }

    /*private void CheckHazards()
    {
        if(number_of_traps == 5)
        {
            PlaceHazards(int x, int y, Vector3 worldStart, GameObject hazard);
        }
    }*/

    public bool InBounds(Point position)
    {
        return position.X >= 0 && position.Y >= 0 && position.X < LevelSize.X && position.Y < LevelSize.Y;
    }


    private void PlaceCharacter(int x, int y, GameObject prefab)
    {
        var targetTile = Tiles[new Point(x, y)];

        GameObject instance = Instantiate(prefab);
        instance.transform.position = targetTile.transform.position; // Maybe you should use targetTile.WorldPosition (I don't know)

        var character = instance.GetComponent<Character>();
        if (character)
        {
            character.GridPosition = targetTile.GridPosition;
        }

        //Debug.Log("Placing Characters:" + x + "," + y);
    }

    private void PlaceNinja()
    {
        PlaceCharacter(0, 0, ninjaPrefab);
    }
    private void PlacePirate()
    {
        PlaceCharacter(13, 0, piratePrefab);
    }

    private void PlaceWizard()
    {
        PlaceCharacter(0, 10, wizardPrefab);
    }
    private void PlaceBarbarian()   
    {
        PlaceCharacter(13, 10, barbarianPrefab);
    }
    private void PlacePlayers()
    {
        PlaceNinja();
        PlacePirate();
        PlaceWizard();
        PlaceBarbarian();
    }
}
