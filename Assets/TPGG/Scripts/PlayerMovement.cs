using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public SpriteRenderer sprite;

    private int jumpCounter = 0;
    private int speed = 1000;
    void Start()
    {

    }


    void Update()
    {

        float dt = Time.deltaTime;

        // para quitar el doble salto pon jumpcounter en 1 abajo
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 2)
        {
            rb2d.velocity = 7 * transform.up;
            jumpCounter++;

        }

        Movement();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {

            jumpCounter = 0;
        }
    }

    private void Movement()
    {

        float dt = Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(horizontalInput * speed * dt, rb2d.velocity.y);
        rb2d.velocity = movimiento;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2000;
        }
        else speed = 1000;

        if (movimiento.x < 0)
        {
            sprite.flipX = true;
        }
        if (movimiento.x > 0)
        {
            sprite.flipX = false;
        }
    }
}
