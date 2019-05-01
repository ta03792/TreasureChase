using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float moveSpeed = 3f;
    private int health;
    float velX;
    float velY;
    public string levelname;
    public Joystick joystick;


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
        if (collision.gameObject.CompareTag("Character"))
        {
            SceneManager.LoadScene(levelname);
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

    private void GameOver()
    {

    }
}
