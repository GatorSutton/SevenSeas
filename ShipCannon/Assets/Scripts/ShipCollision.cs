using UnityEngine;
using System.Collections;

public class ShipCollision : MonoBehaviour {

    public GameObject m_Player;
    public Transform m_SpawnPoint;
    public GameController GC;

    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "tentacle")
        {
            GC.SpawnPlayer();
            Destroy(gameObject);
         
        }
    }


}
