using UnityEngine;

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

    private Tile[,] allTiles;

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
        CreateLevel();
        PlacePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlacePlayers()
    {
        PlaceNinja();
        PlacePirate();
        PlaceWizard();
        PlaceBarbarian();
    }

    private void PlaceCharacter(int x, int y, GameObject prefab)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.position = allTiles[x, y].transform.position;
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

    private void CreateLevel()
    {
        allTiles = new Tile[12, 11];

        Vector3 WorldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        
        for (int y = 0; y < 11; y++)
        {
            for (int x = 0; x < 12; x++)
            {
                if (y == 10)
                {
                    PlaceTile(x, y, WorldStart);               
                }
                else if (x % 2 == 0 || y % 2 == 0)
                {
                    PlaceTile(x, y, WorldStart);
                }
                else
                {
                    PlaceObstacles(x, y, WorldStart);
                }
            }
        }
    }

    private void PlaceTile(int x, int y, Vector3 worldStart, Tile prefab)
    {
        Tile newTile = Instantiate(prefab.gameObject.GetComponent<Tile>());

        newTile.transform.position = new Vector3(2.850601f + worldStart.x + TileSize / 2 + (TileSize * x), worldStart.y - TileSize / 2 - (TileSize * y), 0);

        allTiles[x, y] = newTile;
    }

    private void PlaceTile(int x, int y, Vector3 worldStart)
    {
        PlaceTile(x, y, worldStart, tilePrefab);
        
        allTiles[x, y].GetComponent<Tile>().Occupied = false;
    }

    private void PlaceObstacles(int x, int y, Vector3 worldStart)
    {
        PlaceTile(x, y, worldStart, obstaclePrefab);

        allTiles[x, y].GetComponent<Tile>().Occupied = true;
    }
}
