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
    SpriteRenderer sprite;



    public float healthTime = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerInt)
        {
            if (healthTime > 0)
                healthTime -= Time.deltaTime;

            else if (healthTime <= 0 && isAlive)
            {
                healthPoints--;
                if (healthPoints <= 0)
                {
                    isAlive = false;
                    Debug.Log("Perdiste");
                    PlayerLose();
                }
                healthTime = 0.1f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {

            Debug.Log("Ganaste");
        }
    }
    private void PlayerLose()
    {
        sprite.color = Color.red;
    }
}
