using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float moveSpeed = 3f;
    float velX;
    float velY;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    public string levelname;
    // Start is called before the first frame update
    void Start()
    {
        minX = -4.5f;
        maxX = 6.2f;
        minY = -4.7f;
        maxY = 5.0f;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveVertically()
    {
        velY = Input.GetAxisRaw("Vertical");
        rb2D.velocity = new Vector2(velX * moveSpeed, moveSpeed * velY);
    }

    public void MoveHorizontally()
    {
        velX = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(velX * moveSpeed, moveSpeed * velY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            SceneManager.LoadScene(levelname);
        }
    }
}
