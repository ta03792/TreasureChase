using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb2D;
    public float moveSpeed = 3f;
    private int health;
    float velX;
    float velY;
    public Joystick joystick;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        //health = GetComponents<Player>().health;
        rb2D = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    public void Update()
    {
        velX = joystick.Horizontal;
        velY = joystick.Vertical;
        rb2D.velocity = new Vector2(velX * moveSpeed, moveSpeed * velY);

        if (timeBtwShots <= 0)
        {
    
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

   
