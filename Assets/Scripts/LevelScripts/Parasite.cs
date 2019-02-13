using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite : MonoBehaviour
{
    // the current decay level
    public int decay = 0;
    // reset timer befor next "pulse"
    private float decayTimer = 0;
    
    // === update every frame
    void Update()
    {
        // if the timer is not zero but more, count down the timer
        if (decayTimer > 0)
        {
            // timer - the time it took between this frame and the one before
            decayTimer -= Time.deltaTime;
        }
    }

    // === the decay function 
    public void Decay(int infectMore)
    {
        // if decay hasn't gotten past 5 
        if(decay < 5 && decayTimer <= 0)
        {
            // set the timer to 1
            decayTimer = 1;
            // dacay couter +1
            decay++;
            // calc the next greyTone
            float greyTone = 1f - ((decay*1.5f) / 10f);
            // set the materials color to the greytone to darken the skin
            this.gameObject.GetComponent<Renderer>().material.color = new Color(greyTone, greyTone, greyTone, 1);
        }
        // if it still needs to infect more then itself? do so
        if (infectMore > 0)
        {
            //infect Right
            infectRight(infectMore);
            //infect Left
            infectLeft(infectMore);
        }
    }
    
    // === function to infect the object to its right
    public void infectRight(int infect)
    {
        // raycast to the right
        RaycastHit2D[] hitRight = Physics2D.RaycastAll(transform.position, Vector2.right, 0.2f);
        // refrence to the object to the right
        Parasite par = hitRight[2].collider.gameObject.GetComponent<Parasite>();
        par.Decay(infect-1);
    }

    // === function to infect the object to its left
    public void infectLeft(int infect)
    {
        // raycast to the left
        RaycastHit2D[] hitLeft = Physics2D.RaycastAll(transform.position, Vector2.left, 0.2f);
        // refrence to the object to the left
        Parasite par = hitLeft[2].collider.gameObject.GetComponent<Parasite>();
        par.Decay(infect-1);
    }

    // === function that gets activated when another collider enters this object
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if the other colider is inhabited by a player
        if(other.tag == "Player")
        {
            // call the death function of the other player
            other.gameObject.GetComponent<playerManager>().Death();
        }
    }
}
