using UnityEngine;
using System.Collections;

public class ShipManager : MonoBehaviour {

   
    public Transform m_SpawnPoint;

    private GameObject m_Player;
    private Rigidbody m_Rigidbody;

    bool respawning = false;

    void Start()
    {

        m_Player = GameObject.FindGameObjectWithTag("player");
        m_Rigidbody = m_Player.GetComponent<Rigidbody>();
    }

    void Update()
    {
           if(m_Player.activeSelf == false && !respawning)
        {
            respawning = true;
            Invoke("Respawn", 5);
        } 
    }

    public void Respawn()
    {
        m_Player.transform.position = m_SpawnPoint.position;
        m_Player.transform.rotation = m_SpawnPoint.rotation;

        m_Player.SetActive(true);
        respawning = false;
    }

    public void EnableControl()
    {
        m_Rigidbody.isKinematic = false;
    }

    public void DisableControl()
    {
        m_Rigidbody.isKinematic = true;
    }
}
