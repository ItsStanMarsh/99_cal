using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    DecayTheFloor decay;

    // === the start function gets called once on awake
    void Start()
    {
        decay = GetComponent<DecayTheFloor>();
    }

    // === 
    public void Death()
    {
        
    }
}
