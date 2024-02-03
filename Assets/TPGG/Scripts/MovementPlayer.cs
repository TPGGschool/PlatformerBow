using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

    [SerializeField]
    float MoveSpeed = 50;
    private float DerIzq;
    public Transform Punto1;
    public Transform Punto2; //Representa posicion,rotacion,y la escala de un objeto , siendo mi GameObject Player y el otro el arma


    //ESPACIO PARA CESAR PARA LA INTEGRACION DEL SALTO Y DOBLE SALTO, POR FAVOR COMPAÑERO :3 BUENA SUERTE <3




    [SerializeField]
    private SpriteRenderer Sprite;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;


    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

        if (DerIzq < 1)
        {
            float dt = Time.deltaTime;

            float VoInput = Input.GetAxisRaw("HorizontalWASD");

            float HoInput = Input.GetAxisRaw("HorizontalARROWS");

            Vector2 Direccion1 = new Vector2(VoInput, HoInput);

            Punto1.Translate(MoveSpeed * Direccion1 * dt);
            //siendo que el transform que representa mi GameObject posicion , escala y rotacion accede al Translate que hace que el 
            //transform lo pueda mover y darle dirrecion y una distancia a la transicion de este 

            Sprite.flipX = false;

            animator = SetBool("", true);


        }

        if (DerIzq > -1)
        {
            float dt = Time.deltaTime;

            float ViInput = Input.GetAxisRaw("VerticalWASD");
            //llamos a mis flotantes ViInput y HiInput y asi accedo al input GetAxisRaw 

            float HiInput = Input.GetAxisRaw("VerticalARROWS");
            //"Vertical WASD y ARROWS que cada vez que aprete las teclas aran el movimeinto deseado 


            Vector2 Direccion2 = new Vector2(ViInput, HiInput);
            //le doy un nombre a mi vector que este me genere un nuevo vector X e Y representando mis (ViInput.x , HiInput.y)

            Punto2.position = MoveSpeed * Direccion2 * dt;
            //tal vez = MoveSpeed * (Vector3) direccion2 *dt; no estoy seguro

            Sprite.flipX = true;
            //codigo visto en clase el 01/02/24 Programacion de videojuegos  

            animator = SetBool("", true);
            // ara que mi animacion gire al lado donde el usuario quiere que camine el muñeco a base de un booleano y accedienmdo a un flip
            //haciendo que este gire en la otra direcion x 


        }

        else if (DerIzq == 0)
        {

            animator.SetBool("", false);
            //copia del codigo de la clase de Programacion de videojuegos 01 /02 /24

        }

        void OnCollisionEnter2D(Collision collision)

        {

            if (collision.gameObject.tag == "Suelo") ;
            Debug.Log("Hay gravedad y toco suelo UwU");

        }

    }
}
