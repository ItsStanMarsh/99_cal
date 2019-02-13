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

        CastRay();

    }

    private void CastRay()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, 1f);
        print(hit.Length);
        GameObject currentHit;
        if (hit.Length>=1)
        {
            for( int i = 1; i < hit.Length; i++)
            {
                currentHit = hit[i].collider.gameObject;
                if (currentHit.tag == "UI")
                {
                    print("ok");
                    currentHit.GetComponent<Parasite>().Decay(3);
                }
            }
            
        }
    }
}
