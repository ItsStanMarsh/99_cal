using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayTheFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void CastRay()
    {
        RaycastHit2D[] hit = new RaycastHit2D[10];
        GameObject currentHit;
        if (Collider2D.Raycast(Vector2.down, hit, 5f , LayerMask.GetMask("UI")))  
        {
            for(int i = 0; i < hit.Length; i++)
            {
                currentHit = hit[i].collider.gameObject;
                if (true)
                {
                
                }
            }
        }
    }
}
