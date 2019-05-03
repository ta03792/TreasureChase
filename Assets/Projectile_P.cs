using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_P : MonoBehaviour
{
    public float speed;
    private Transform Enemy;
    string target_id;
    private Vector2 target;
    private int i = 0;

    //public void SetTarget(string targetName)
    //{
    //    target_id = targetName;

    //}


    // Start is called before the first frame update
    void Start()
    {

        Enemy = GameObject.Find("Enemy").transform;
        name = "Projectile_P";
        target = new Vector2(Enemy.position.x, Enemy.position.y);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            //GetComponent<Health>().HealthProperties -= 2;
            //i = i + 1;
            // if (i < 8)
            //{ print(i); }
            DestroyProjectile();
        }
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))

    //    {

    //        //GetComponent<Health>().HealthProperties -= 2;
    //        //i = i + 1;
    //        //print(i);
    //        DestroyProjectile();

    //    }

    //}
    //void zoha_collide()
    //{
    //    if (transform.position.x == target.x && transform.position.y == target.y)
    //    {
    //        print("kill");
    //    }
    //}
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
