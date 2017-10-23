using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldRotation : MonoBehaviour {

    private Quaternion startRotation;

	// Use this for initialization
	void Start () {
       startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = startRotation;
	}
}
