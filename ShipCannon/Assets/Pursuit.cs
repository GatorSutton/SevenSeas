using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour {

    private ShipControl SC;
    public float pursuitSpeed = 10;
    public float normalSpeed = 5;
    public float pursuitMultiplier;
    public float decelerationMultiplier;

    private bool accelerating = false;
    private float t = 0;
    private float accelerationMultiplier = -.1f;

	// Use this for initialization
	void Start () {
        SC = GetComponentInParent<ShipControl>();
        
	}
	
	// Update is called once per frame
	void Update () {
        speedAdjuster();
	}

    //Ramp up speed if in pursuit
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "pursuitangle" && (Mathf.Abs(other.transform.parent.transform.rotation.eulerAngles.y - transform.parent.transform.rotation.eulerAngles.y) < 45))
        {
            t += .02F;
            print(Mathf.Abs(other.transform.parent.transform.rotation.eulerAngles.y - transform.parent.transform.rotation.eulerAngles.y));
        }
    }


    private void speedAdjuster()
    {
        t -= .01F;
        t = Mathf.Clamp(t, 0, 1);
        SC.m_Speed = Mathf.Lerp(normalSpeed, pursuitSpeed, t);
        
 
    }


}
