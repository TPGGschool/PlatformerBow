using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

    private float MoveSpeed;
    [SerializeField]
    private Rigidbody2D rbPabloElFlaco;
    //EL RB NO ME LO MUEVAN , ASI DEJENLO CON EL SERIALIZEFIELD,PARA QUE EN EL INSPECTOR LE COLOQUEN A PLAYER , SI NO , NO SE MUEVE EL BASTARDO
    private SpriteRenderer Sprite;

    //MUCHA SUERTE CESAR c: <3 

    void Start()
    {

        Sprite = gameObject.GetComponent<SpriteRenderer>();
        //MI SPRITE LLAMDO DE TAL MANERA , SERA IGUAL AL GAMEOBJECT ASIGNADO A ESTE QUE ESTARA ACCEDIENDO AL COMPONENTE SPRITE RENDERER


    }


    void Update()
    {
        Movimiento();

    }
    private void Movimiento()

    {


        //if (Input.GetKeyDown(KeyCode.D))

        //{
        //    Vector2 Move = Vector2.right;
        //    transform.Translate(Move * MoveSpeed * dt * rb.velocity.y);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Vector2 Move = Vector2.left;
        //    transform.Translate(Move* MoveSpeed * dt * rb.velocity.y);
       

        
        //INTENTE HACER MI PROPIO CODIGO , HMM FUNCIONA , PEEEERO YA NO SABIA COMO HACERLE PARA QUE SE VOLTIE EL SPRITE :C F
        // ¿PUEDO HACER YO LA RESPIRACION DE PABLO "EL FLACO" ? . THAMMER NO QUISE SONAR GROSERO , SOLO FUE UN COMENTARIO FUERA DE LUGAR 
        //POR PARTE MIA , NO DEBI DECIR ESO , INTENTASTE EXPLICARME Y FUI GROSERO AUNQUE NO FUE MI INTENCION, PROMETO QUE NO SE REPETIRA:)


        float dt = Time.deltaTime;
        // DT ES IGUAL  LA UNIDAD DE TIEMPO X FRAME X SEGUNDO QUE MIDE UNITY EJN TIEMPO REAL DESDE LA INTERFASE 
        float HiInput = Input.GetAxisRaw("Horizontal");
        //LE PONGO UN NOMBRE A MI FLOTANTE QUE ES IGUAL AL INTERFACE DEL SISTEMA QUE ACCEDE QUE CAUNDO APRETO UN BOTON HACE TAL MOV.
        Vector2 Move = new Vector2(HiInput * MoveSpeed * dt, rbPabloElFlaco.velocity.y);
        //CREO UN VECTOR 2 CON UN NOMBRE QUE SERA IGUAL A UN NUEVO VECTOR QUE ME DAN UN X E Y DE COMPONENTES CON UN VALOR IGUAL 
        // A LA MULTIPLICACION DE MI FLOTANTE ANTES MENCIONADA , EL TIEMPO , LA VELOCIDAD DE MI MONO QUE SE MOVERA Y SU RB QUE CONTENGA Y ACCEDA
        // A ALGUNA UNIDAD QUE CONTENGA EL COMPONENTE Y DEL VECTOR 
        rbPabloElFlaco.velocity = Move;
        //ASI QUE VELOCITY LE ESTA DANDO UNA UNIDAD DE VELOCIDAD POR SEGUNDO A MI RB Y LE ESTOY DICIENDO QUE SE LLAMA DE TAL MANERA 

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed = 2500;
            //NO ENTIENDO QUE SI LE PONGO POCA VELOCIDAD CASI NI SE VE QUE SE MUEVE , AL CONTRARIO QUE SI LE PONGO UN NUMEROTE SE MUEVE NORMAL
        }
        else MoveSpeed = 1500;
        //HACIENDO QUE CUANDO APRETE EL BOTON IZQ.sHIFT ACCELERA MI MONO A TAL VELOCIDAD , PERO SI NO LO HAGO TENDRA TAL VELOCIDAD

        if (Move.x < 0)
        {
            Sprite.flipX = true;
        }

        if (Move.x > 0)
        {
            Sprite.flipX = false;
        }

        else if (Move.x == 0)
        {

        }
        // ESTA CORELACIONADO CON MI INPUT.GETAXIS , SI APRETO EJEMPLO EL BOTON A O FLECHA IZQ , SE MOVERA DE TAL FORMA PORQUE ES
        //MAYOR A CERO Y EL SPRITE DEL GATITO SE MOVERA A ESA DIRECCION Y VICEVERSA , SI EL JUGADOR ESTA QUIERO SE MANTIENE DONDE SE DEJO 
        //POR ULTIMA VEZ 
    }
}
