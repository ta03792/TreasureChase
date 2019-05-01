using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private Vector2 moveVelocity;
    private bool stop;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        stop = false;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (stop == false)
        {
            Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            GameObject.Find("Player").transform.position += moveInput;
        }
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveVelocity * Time.deltaTime);
    }
}