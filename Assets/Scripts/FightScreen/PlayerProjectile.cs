using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;

    private Transform character;
    private Vector2 target;

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Character").transform;

        target = new Vector2(character.position.x, character.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            DestroyProjectile();
        }
        else
        {
            Update();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
