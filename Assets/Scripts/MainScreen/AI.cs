using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
internal sealed class AI : MonoBehaviour
{
    private static readonly Vector2[] MovementChoices = new Vector2[]
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
}

























/*using System;
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
