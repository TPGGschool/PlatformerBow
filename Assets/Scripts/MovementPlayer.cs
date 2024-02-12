using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // variables generales del script
    private float MoveSpeed = 700;
    [SerializeField]
    private SpriteRenderer Sprite;
    private Rigidbody2D rbPlayer;
    private float JumpForce = 6;
    int Jumps = 2;
    private Animator animator;

    void Start()
    {
        // getcomponents abajo
        Sprite = gameObject.GetComponent<SpriteRenderer>();

        rbPlayer = gameObject.GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        Movimiento();
        Jump();
        
    }
    void Update()
    {

    }
    private void Movimiento()
    {
        // definicion de varialbles
        float HiInput = Input.GetAxisRaw("Horizontal" ) * Time.deltaTime;
        Vector2 Move = new Vector2(HiInput * MoveSpeed * Time.deltaTime, rbPlayer.velocity.y);
        rbPlayer.velocity = Move;

        // sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 1400;
            animator.SetBool("IsRuning", true);
        }
        else
        {
            MoveSpeed = 700;
            animator.SetBool("IsRuning", false);
        }

        // voltear sprite
        if (Move.x < 0)
        {
            Sprite.flipX = false;
            animator.SetBool("Iswalking", true);

        }
        else if (Move.x > 0)
        {
            Sprite.flipX = true;
            animator.SetBool("Iswalking", true);
        }
        else animator.SetBool("Iswalking", false);
    }
    private void Jump()
    {
        // salto
        if (Input.GetKeyDown(KeyCode.Space) && Jumps < 2) 
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x,JumpForce);
            Jumps++;
            animator.SetBool("IsJumping", true);

        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {

        // resetear salto
        if (collision.collider.CompareTag("Floor"))
        {


            // esto es para que el salto solo se resetee cuando toca el suelo, y no una pared, techo etc...
            // Aquí se utiliza un condicional para verificar el ángulo entre la normal de la colisión y el vector hacia arriba (Vector2.up).
            // La normal es un vector perpendicular a la superficie de colisión. 
            // Este condicional verifica si el ángulo entre la normal y el vector hacia arriba es menor a 45 grados.
            // conseguido de stack overflow de usuario "Voidsay"
            if (Vector2.Angle(collision.GetContact(0).normal, Vector2.up) < 45)
            {
                Jumps = 0;
                animator.SetBool("IsJumping", false);

            }

        }
     
        
    }
}
