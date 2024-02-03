using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // variables generales del script
    private float MoveSpeed;
    [SerializeField]
    private SpriteRenderer Sprite;
    private Rigidbody2D rbPlayer;
    private float JumpForce = 5;
    private bool InFloor;
    int Jumps = 2;

    void Start()
    {
        // getcomponents abajo
        Sprite = gameObject.GetComponent<SpriteRenderer>();

        rbPlayer = gameObject.GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        Movimiento();
        Jump();

    }

    private void Movimiento()
    {
        // definicion de varialbles
        float dt = Time.deltaTime;
        float HiInput = Input.GetAxisRaw("Horizontal");
        Vector2 Move = new Vector2(HiInput * MoveSpeed * dt, rbPlayer.velocity.y);
        rbPlayer.velocity = Move;

        // sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 45000;
        }
        else MoveSpeed = 22500;

        // voltear sprite
        if (Move.x < 0)
        {
            Sprite.flipX = true;
        }
        if (Move.x > 0)
        {
            Sprite.flipX = false;
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Jumps < 2) 
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x,JumpForce);
            Jumps++;

        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Jumps = 0;

        }
     
        
    }
}
