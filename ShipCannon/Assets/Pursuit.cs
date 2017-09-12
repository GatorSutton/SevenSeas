using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour {

    private ShipControl SC;
    public float pursuitSpeed = 10;
    public float normalSpeed = 5;

	// Use this for initialization
	void Start () {
        SC = GetComponent<ShipControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "pursuitangle")
        {
            SC.m_Speed = pursuitSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pursuitangle")
        {
            SC.m_Speed = normalSpeed;
        }
    }


}
