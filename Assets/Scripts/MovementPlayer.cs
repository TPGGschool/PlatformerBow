using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // variables generales del script
    private float MoveSpeed;
    [SerializeField]
    private Rigidbody2D rbPlayer;
    private SpriteRenderer Sprite;

    void Start()
    {
        // getcomponents abajo
        Sprite = gameObject.GetComponent<SpriteRenderer>();


    }

    void Update()
    {
        Movimiento();

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
            MoveSpeed = 4000;
        }
        else MoveSpeed = 2500;

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
}
