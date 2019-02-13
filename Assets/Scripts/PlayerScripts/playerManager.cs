using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    DecayTheFloor decay;

    void Start()
    {
        decay = GetComponent<DecayTheFloor>();
    }

    public void Death()
    {

    }
}
