using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 Location;
    

    void Start()
    {
        Vector2 Location = new Vector2(Random.Range(0f, 10f), Random.Range(0f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("UpWall"))
        {
            if (Random.Range(0, 2) == 0)  // go right
            {
                Location = new Vector2(Random.Range(0, 5f), 0);
                transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
            }
            else      //go left
            {
                Location = new Vector2(Random.Range(-5f, 0), 0);
                transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
            }

        }
             
        if (collision.gameObject.CompareTag("LeftWall"))    // go down
        {
            if (Random.Range(0, 2) == 0)  // go up
            {
               Location = new Vector2(0, Random.Range(0, 5f));
               transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
            }
            else     
            {
               Location = new Vector2(0, Random.Range(-5f, 0));
               transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
            }
        }
        if (collision.gameObject.CompareTag("DownWall"))   
        {
            if (Random.Range(0, 2) == 0)  // go right
            {
               Location = new Vector2(Random.Range(0, 5f), 0);
               transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
            }
            else        // go left
            {
                Location = new Vector2(Random.Range(-5f, 0), 0);
                transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
            }
        }
        if (collision.gameObject.CompareTag("RightWall"))   
        {
           if (Random.Range(0, 2) == 0)  // go up
           {
               Location = new Vector2(0, Random.Range(0, 5f));
               transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
           }
           else      // go down
           {
               Location = new Vector2(0, Random.Range(-5f, 0));        
               transform.position = Vector2.MoveTowards(transform.position, Location, speed * Time.deltaTime);
           }
        }
    }
}
