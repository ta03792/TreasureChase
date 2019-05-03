using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerFight : MonoBehaviour
{
    private float timeBtwshots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public Text healthText;
    private Rigidbody2D rb2D;
    public float speed;
    private Vector2 moveVelocity;
    private bool stop;
    private CapsuleCollider2D myCollider;
    private int health;
    int counter;

    public Transform enemy;

    //private void Awake()
    //{
    //    GetComponent<Health>().healthText = GameObject.Find("Health").GetComponent<Text>();
    //}
    // Start is called before the first frame update
    void Start()
    {
        //Projectile = GameObject.Find("Projectile");
        //myCollider = GetComponent<CapsuleCollider2D>();
        enemy = GameObject.Find("Enemy").transform;
        rb2D = GetComponent<Rigidbody2D>();
        health = 10;
        counter = 5;
        //healthText.text = health.ToString();
        stop = false;
        timeBtwshots = startTimeBtwShots;


    }

    // Update is called once per frame

    void Update()
    {
        //-4.98 3.25
        //5, -3.23
        //if (myCollider.IsTouchingLayers(LayerMask.GetMask( "Walls")))
        //{
        //    Debug.Log("dasdasd");
        //}

        //healthText.text = health.ToString();
        if (stop == false)
        {
            Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            if (((transform.position + moveInput).x > -6) && ((transform.position + moveInput).x < 5.98) && ((transform.position + moveInput).y > -4.23) && ((transform.position + moveInput).y < 4.25))
                GameObject.Find("Player").transform.position += moveInput;
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
    
    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveVelocity * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collision");
        if (collision.collider.gameObject.name == "Projectile")
        {
            //print("projectile");
            counter -= 1;
            //print("Counter: " + counter.ToString());
            health -= 2;
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
        SceneManager.LoadScene("MainMenu");

    }


    //void Die()
    //{
    //    if (GetComponent<Health>().HealthProperties <= 0)
    //    {
    //        GetComponent<Health>().HealthProperties = 0;
    //        Destroy(this.gameObject);
    //    }

    //}
}