using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float moveSpeed = 3f;
    float velX;
    float velY;
    public Joystick joystick;


    void Awake()
    {
        GetComponent<HealthScript>().healthtext = GameObject.Find("Health").GetComponent<Text>();
        GetComponent<HealthScript>().Currenthealth = 10;
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
        Die();
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
            GetComponent<HealthScript>().Currenthealth -= 2;   
        }
        Destroy(collision.gameObject);
    }

    void Die()
    {
        if(GetComponent<HealthScript>().Currenthealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
