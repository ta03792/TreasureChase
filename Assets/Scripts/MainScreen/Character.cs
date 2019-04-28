using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class Character : MonoBehaviour
{
    public GameObject character;    

    [SerializeField]
    private float speed;

    private Stack<Node> path;

    public Point GridPosition { get; set; }

    private Vector3 destination;

    public Stack<Node> Path
    {
        get
        {
            Debug.Log("Get Called!");
            if (path == null)
            {
                Debug.Log("Generate!");
                GeneratePath(this.GridPosition);
                Debug.Log(path.Count);
            }
            return new Stack<Node>(new Stack<Node>(path));
        }
    }

    void Start()
    {
        Debug.Log("StartPosition:" + this.GridPosition.X + "," + this.GridPosition.Y);
        SetPath(Path);
    }

    void Update()
    {
        StartCoroutine("StartMoving");
        Move();
    }

    private IEnumerator StartMoving()
    {
        if (path != null && path.Count == 0)
        {
            GeneratePath(this.GridPosition);
            yield return new WaitForSeconds(2.5f);
        }
    }

    public void GeneratePath(Point start)
    {
        start = this.GridPosition;

        while (true)
        {
            int goalx = Random.Range(0, 10);
            int goaly = Random.Range(0, 11);
            Debug.Log("GoalTile: " + goalx + "," + goaly);

            if(LevelManager.Instance.Tiles.ContainsKey(new Point(goalx, goaly)) == true)
            {
                Debug.Log("Key Found!");
                Tile goalTile = LevelManager.Instance.Tiles[new Point(goalx, goaly)];
                if (goalTile.GetComponent<Tile>().Walkable == true)
                {
                    path = Astar.GetPath(start, goalTile.GridPosition);
                    break;
                }
            }
        }
    }



    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        
        if (transform.position == destination)
        {
            if (path != null && path.Count > 0)
            {
                GridPosition = path.Peek().GridPosition;
                Debug.Log("Character Movement:" + GridPosition.X + " , " + GridPosition.Y);
                destination = path.Pop().WorldPosition;
            }
            
            if (path != null && path.Count == 0)
            {
                path = null;
                Debug.Log("called again!");
                GeneratePath(this.GridPosition);
                SetPath(Path);
            }
        }
    }
    
    private void SetPath(Stack<Node> newPath)
    {
        if(newPath != null)
        {
            this.path = newPath;

            GridPosition = path.Peek().GridPosition;
            destination = path.Pop().WorldPosition;
        }
    }
}


/*
 * private static readonly Vector2[] MovementChoices = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
    };

    private Rigidbody2D rb;
    private Vector2 movementDirection;

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.StartCoroutine(this.ChangeDirectionContinuously());
    }

    private void Update()
    {
        this.rb.velocity = this.movementDirection * 2f;
    }

    private IEnumerator ChangeDirectionContinuously()
    {
        while (true)
        {
            this.movementDirection = MovementChoices[Random.Range(0, MovementChoices.Length)];
            yield return new WaitForSeconds(2f);
        }
    }
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    public float moveSpeed = 7f;
    private Rigidbody2D rb2d;
    private float tileSize;


    private void Start()
    {
        minX = -4.5f;
        maxX = 6.2f;
        minY = -4.7f;
        maxY = 5.0f;
        rb2d = GetComponent<Rigidbody2D>();
        float tileSize = GetComponent<LevelManager>().TileSize;
    }

    private void Start()
    {
        this.StartCoroutine(this.ChangeDirectionContinuously());
    }

    private void Update()
    {
        this.rb.velocity = this.movementDirection;
    }

    private IEnumerator ChangeDirectionContinuously()
    {
        while (true)
        {
            this.movementDirection = MovementChoices[Random.Range(0, MovementChoices.Length)];
            yield return new WaitForSeconds(1f);
        }
    }
}

/*  private readonly Vector2[] MovementChoices = new Vector2[]
{
    Vector2.up,
    Vector2.down,
    Vector2.left,
    Vector2.right,
}; 

    private void Update()
    {
        // Click to see next move 
        if (Input.GetButtonDown("Fire1"))
        {
            int choiceIndex = Random.Range(0, this.MovementChoices.Length);
            var movement = this.MovementChoices[choiceIndex];
        }
    }
}


private void Movement()
    {
        int move = UnityEngine.Random.Range(0, 4);
        if (move == 0)
        {
            MoveLeft();
        }
        if (move == 1)
        {
            MoveRight();
        }
        if (move == 2)
        {
            MoveDown();
        }
        if (move == 3)
        {
            MoveUp();
        }
    }

    private void MoveLeft()
    {
        float startPos = Math.Abs(transform.position.x);
        float distance = 0;

        while (tileSize >= distance)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            distance = Math.Abs(startPos) - Math.Abs(transform.position.x);
            if (transform.position.x < minX)
            {
                transform.position = new Vector2(minX, transform.position.y);
                break;
            }
        }
    }

    private void MoveRight()
    {
        float startPos = Math.Abs(transform.position.x);
        float distance = 0;

        while (tileSize >= distance)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            distance = Math.Abs(transform.position.x) - Math.Abs(startPos);
            if (transform.position.x < minX)
            {
                transform.position = new Vector2(minX, transform.position.y);
                break;
            }
        }
    }

    private void MoveUp()
    {
        float startPos = transform.position.y;
        float distance = 0;

        while (tileSize >= distance)
        {
            rb2d.velocity = new Vector2(0, moveSpeed);
            distance = Math.Abs(transform.position.y) - Math.Abs(startPos);
            if (transform.position.x < minX)
            {
                transform.position = new Vector2(minX, transform.position.y);
                break;
            }
        }
    }
    private void MoveDown()
    {
        float startPos = transform.position.y;
        float distance = 0;

        while (tileSize >= distance)
        {
            rb2d.velocity = new Vector2(0, -moveSpeed);
            distance = Math.Abs(startPos) - Math.Abs(transform.position.y);
            if (transform.position.x < minX)
            {
                transform.position = new Vector2(minX, transform.position.y);
                break;
            }
        }
    }

}*/
