using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBtwshots;
    public float startTimeBtwShots;
    public GameObject projectile;
    private bool stop;
    int counter;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

        stop = false;
        player =GameObject.Find("Player").transform;
        counter = 3;
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
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwshots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            
            timeBtwshots = startTimeBtwShots;
           
        }
        else
        {
            timeBtwshots -= Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collision" + collision.collider.gameObject.name);
     
        if (collision.collider.gameObject.name == "Projectile_P")
        {
            //print("projectile");
            counter -= 1;
            print("Counter: " + counter.ToString());
            //health -= 2;
            if (counter == 0)
            {
                Die();
            }

            //GetComponent<Hea>
            //GameObject.Find("Health").healthText.text = "Test";
            //GetComponent<Health>();

        }
    }


    void Die()
    {
        print("Dead");
        SceneManager.LoadScene("MainScreen");

    }

}

