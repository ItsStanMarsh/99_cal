using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript: MonoBehaviour {

    public Animator anim;
    public SpriteRenderer spriterenderer;
    public float xInput;

    private bool dead = false;


    void Update () {

        
        if (!dead)
            dead = Input.GetButton("KYS");

        if (!dead)
        {
            Movement();
        }
        else anim.SetBool("isDead", true);

    }

  

    public void Movement()
    {

        xInput = Input.GetAxisRaw("Horizontal");
       
            if (xInput == 1 || xInput == -1)
            {
                anim.SetInteger("Speed", 1);
            }
            else anim.SetInteger("Speed", 0);
        
    }

}
