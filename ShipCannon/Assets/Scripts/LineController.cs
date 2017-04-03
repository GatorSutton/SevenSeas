using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour {

    public Transform splashPoint;
    public Transform launchPoint;

    private LineRenderer lr;
    private Transform[] projectilePoints;
   

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        
	}
	
	// Update is called once per frame
	void Update ()
    { 
       
	}

    void calculatePoints()
    {
       // float distance = Vector3.Distance(splashPoint.position, launchPoint.position);
        float xDistance = Mathf.Abs(splashPoint.position.x - launchPoint.position.x);
        float zDistance = Mathf.Abs(splashPoint.position.y - launchPoint.position.y);
        float distance = Mathf.Sqrt(xDistance * xDistance + zDistance * zDistance);

        for(int i=0; i<3; i++)
        {

        }
    }


}
