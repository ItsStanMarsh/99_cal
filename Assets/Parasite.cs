using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite : MonoBehaviour
{

    public int decay = 0;
    private float decayTimer = 0;

    public bool temp;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (decayTimer > 0)
        {
            decayTimer -= Time.deltaTime;
        }
        if (temp) { temp = false; Decay(); }
    }

    public void Decay()
    {
        if(decay <= 5 && decayTimer <= 0)
        {
            decayTimer = 1;
            decay += 1;
            float greyTone = 1f - (decay / 10f);
            print(greyTone);
            this.gameObject.GetComponent<Renderer>().material.color = new Color(greyTone, greyTone, greyTone, 1);
        }
    }
}
