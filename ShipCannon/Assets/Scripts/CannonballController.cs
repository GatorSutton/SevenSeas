using UnityEngine;
using System.Collections;

public class CannonballController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "water")
        {
         //   Destroy(gameObject);
        }
    }
}
