using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour {

    public GameObject m_splashParticles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cannonball") 
        {
            Instantiate(m_splashParticles, collision.gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
            Destroy(collision.gameObject);
            
        }

    }

    void OnTriggerEnter(Collider collider)
    {
            if(collider.gameObject.tag == "tentacle")
        {
          //  Instantiate(m_splashParticles, collider.gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
        }
    }
}
