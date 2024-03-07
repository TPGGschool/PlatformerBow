using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public bool isAlive = true;
    [SerializeField]
    public int healthPoints = 3;
    [SerializeField]
    private int LayerInt;

    public SpriteRenderer SpriteRend;

    private Color Normalcol;

    float timedamageindicator = 0.3f;



    private float healthTime = 0;

    void Start()
    {
        Normalcol = SpriteRend.color;
    }

    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Die")
        {
           
            if (healthTime <= 0 && isAlive)
            {
                healthPoints--;
                timedamageindicator = 0;
                Showdamage();
                
                Debug.Log("vidas: " + healthPoints);
                if (healthPoints <= 0)
                {
                    isAlive = false;
                    Debug.Log("Perdiste");
                  
                }
                healthTime = 1;
                
            }

            healthTime -= Time.deltaTime;
        }
   

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {

            Debug.Log("Ganaste");
        }

        if (collision.gameObject.tag == "Vida")
        {
            if (healthPoints < 3)
            {
                healthPoints++;
                Debug.Log("Ganaste Vida");
                Debug.Log("vidas: " + healthPoints);
                Destroy(collision.gameObject);

            }
        }
    }

    private void Showdamage()
    {
        

        if (timedamageindicator < 0.1f)
        {


            SpriteRend.color = Color.red;



            timedamageindicator += Time.deltaTime;
        }
        else
        {
            SpriteRend.color = Color.white;
            
        }
    }
  
}
