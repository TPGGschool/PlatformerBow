using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRandomizer : MonoBehaviour
{
    //variables generales
    private Animator animator;
    float timer = 4f;
    void Start()
    {
        //getcomponents
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // codigo general para ransomizar la animacion idle
        float dt = Time.deltaTime;

        timer -= dt;

        if (timer < 0)
        {
            animator.SetInteger("IdleIndex", Random.Range(1, 7));
            timer = Random.Range(2, 5);
        }
        else animator.SetInteger("IdleIndex", 0);

    }
}
