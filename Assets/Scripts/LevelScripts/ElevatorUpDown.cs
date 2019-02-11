using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUpDown : MonoBehaviour {

    public Transform ts;
    [Range(1, 100)]
    public float rangeUpAndDown;
    [Range(1, 100)]
    public float speed;
    private bool goingDown = true;
    private float position;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(goingDown)
        {
            position = speed * -1 * Time.deltaTime;
        }
        else if (!goingDown)
        {
            position = speed * Time.deltaTime;
        }
        
        ts.position += new Vector3(0, position, 0);

        if ((goingDown && ts.position.y < -rangeUpAndDown )||( !goingDown && ts.position.y > rangeUpAndDown))
        {
            if (goingDown)
                goingDown = false;
            else
                goingDown = true;
        }


    }
}
