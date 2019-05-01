using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float moveSpeed = 3f;
    public int health;
    float velX;
    float velY;
    public Joystick joystick;


    // Start is called before the first frame update
    void Start()
    {
        health = 10;
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
            BattleManager.Instance.StartBattle(this, character);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BearTrap"))
        {
            health -= 2;
            GetComponent<HealthScript>().health = this.health;
        }
        Destroy(collision.gameObject);
    }
}
