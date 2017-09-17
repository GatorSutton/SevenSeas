using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour {

    private ShipControl SC;
    public float pursuitSpeed = 10;
    public float normalSpeed = 5;
    public float pursuitMultiplier;
    public float decelerationMultiplier;

    private float t = 0;
    private float accelerationMultiplier = -.1f;

	// Use this for initialization
	void Start () {
        SC = GetComponent<ShipControl>();
	}
	
	// Update is called once per frame
	void Update () {
        speedAdjuster();
        print(t);
	}

    //Ramp up speed if in pursuit
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "pursuitangle" )//&& (Mathf.Abs(other.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y) < 45))
        {
                accelerationMultiplier = pursuitMultiplier;
            print("pursuitBegin");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pursuitangle")
        {
                accelerationMultiplier = decelerationMultiplier;
            print("slow your roll");
        }
    }




    private void speedAdjuster()
    {
        t = Mathf.Clamp(t, 0, 1);
            t += accelerationMultiplier * Time.deltaTime;
        SC.m_Speed = Mathf.Lerp(normalSpeed, pursuitSpeed, t);
    }


}
