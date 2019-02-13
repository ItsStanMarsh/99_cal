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
            decayTimer = 1;
            decay += 1;
            float greyTone = 1f - ((decay*1.5f) / 10f);
            print(greyTone);
            this.gameObject.GetComponent<Renderer>().material.color = new Color(greyTone, greyTone, greyTone, 1);
        }
        if (infectMore > 0)
        {
            //right
            infectRight(infectMore);
            infectLeft(infectMore);
        }
    }
    
    public void infectRight(int infect)
    {
        RaycastHit2D[] hitRight = Physics2D.RaycastAll(transform.position, Vector2.right, 0.2f);
        Parasite par = hitRight[2].collider.gameObject.GetComponent<Parasite>();
        par.Decay(infect-1);
    }

    public void infectLeft(int infect)
    {
        RaycastHit2D[] hitRight = Physics2D.RaycastAll(transform.position, Vector2.left, 0.2f);
        Parasite par = hitRight[2].collider.gameObject.GetComponent<Parasite>();
        par.Decay(infect-1);
    }
}
