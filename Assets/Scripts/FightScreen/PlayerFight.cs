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
    public GameObject projectile;

    // Start is called before the first frame update

    private void Awake()
    {
        health = 10;
    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    public void Update()
    {
        velX = joystick.Horizontal;
        velY = joystick.Vertical;
        rb2D.velocity = new Vector2(velX * moveSpeed, moveSpeed * velY);
        Die();
    }

    public void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit!");
        if (collision.CompareTag("Projectile"))
        {
            health -= 1;
        }
    }

    void Die()
    {
        if(health <= 0)
        {
            BattleManager.Instance.EndBattle(false);
        }        
    }
}

   
