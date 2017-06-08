using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class ShipManager
{

    public Transform m_SpawnPoint;
    public int m_Lives;
    public int m_Treasures;
    public CameraControl CC;
    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public bool m_Winner = false;

    private GameObject m_Player;


 
    private Rigidbody m_Rigidbody;
    private ShipControl m_Control;
    private ShipFiringJoystick m_FiringJoystick;

    bool respawning = false;

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("player");
        m_Rigidbody = m_Player.GetComponent<Rigidbody>();
    }

    /*
    void Update()
    {
        if (m_Player.activeSelf == false && !respawning)
        {
            respawning = true;
            Invoke("Respawn", 5);
            PF.CameraToSky();
        }
    }
    */

    public void Setup()
    {
        m_Control = m_Instance.GetComponent<ShipControl>();
        m_FiringJoystick = m_Instance.GetComponentInChildren<ShipFiringJoystick>();                                   //find script in children of object

        m_Control.m_PlayerNumber = m_PlayerNumber;
        m_FiringJoystick.m_PlayerNumber = m_PlayerNumber;
    }
    
    public void Respawn()
    {
        CC.CameraToShip();
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;
        m_Instance.SetActive(true);
        respawning = false;
    }
    
    public void EnableControl()
    {
        //m_Rigidbody.isKinematic = false;
        m_Control.enabled = true;
        m_FiringJoystick.enabled = true;
    }

    public void DisableControl()
    {
        //m_Rigidbody.isKinematic = true;
        m_Control.enabled = false;
        m_FiringJoystick.enabled = false;
    }
}
