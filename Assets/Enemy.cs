using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBtwshots;
    public float startTimeBtwShots;
    public GameObject projectile;
    private bool stop;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        player = GameObject.Find("Player").transform;

        timeBtwshots = startTimeBtwShots;

    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print(collision.gameObject.name);
    //    if (collision.gameObject.name == "thumbnail (Clone)")
    //    {
    //        stop = true;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        /*else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }*/
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwshots <= 0)
        {
            //Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwshots = startTimeBtwShots;

        }
        else
        {
            timeBtwshots -= Time.deltaTime;
        }
    }
}
