using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {

    public Transform m_SpawnPoint;


    private bool m_Alive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "tentacle")
        {
            killShip();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "cannonball")
        {
            killShip();
            Destroy(collision.gameObject);
        }
    }

    void killShip()
    {
        gameObject.SetActive(false);
        m_Alive = false;

    }



}
