using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float moveSpeed = 3f;
    private int health;
    public int Health { get => health; set => health = value; }
    float velX;
    float velY;
    public Joystick joystick;


    void Awake()
    {
        Health = 10;    
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        velX = joystick.Horizontal;
        velY = joystick.Vertical;
        rb2D.velocity = new Vector2(velX * moveSpeed, moveSpeed * velY);
    }
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();

        if (character)
        {
            SceneManager.LoadScene("MainScreen");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BearTrap"))
        {
            Health -= 2;
            //GetComponent<HealthScript>().health = this.Health;
        }
        Destroy(collision.gameObject);
    }

    void Die()
    {
        if(Health == 0)
        {
            //BattleManager.Instance.EndBattle(false);
        }
    }
}
