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
	        if(m_Alive == false)
        {
            Invoke("Respawn", 5);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "tentacle")
        { 
            gameObject.SetActive(false);
            m_Alive = false;
        }
    }

    public void Respawn()
    {
        gameObject.transform.position = m_SpawnPoint.position;
        gameObject.transform.rotation = m_SpawnPoint.rotation;

        gameObject.SetActive(true);
        m_Alive = true;
    }
}
