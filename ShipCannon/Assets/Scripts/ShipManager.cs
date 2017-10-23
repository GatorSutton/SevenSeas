using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

[Serializable]
public class ShipManager
{

    public Transform m_SpawnPoint;
    public int m_Lives;
    public int m_Treasures;
    public ShipControl m_Control;
    public CameraControl CC;
    public GameObject m_Canvas;
    public BaseTreasure m_BT;
    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public bool m_Winner = false;
    [HideInInspector] public Text m_TreasureText;
    [HideInInspector] public Text m_AnnouncementText;
    [HideInInspector] public Text m_LivesText;
    [HideInInspector] public Text m_SpeedText;

    private GameObject m_Player;


 
    private Rigidbody m_Rigidbody;

    //private ShipFiringJoystick m_FiringJoystick;

    private ShipFiringJoystick m_FiringJoystickR;
    private ShipFiringJoystick m_FiringJoystickL;


    bool respawning = false;

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("player");
        m_Rigidbody = m_Player.GetComponent<Rigidbody>();
    }

    public void Setup()
    {
        m_Control = m_Instance.GetComponent<ShipControl>();
        //m_FiringJoystick = m_Instance.GetComponentInChildren<ShipFiringJoystick>();                                   //find script in children of object
        ShipFiringJoystick[] joysticks = m_Instance.GetComponentsInChildren<ShipFiringJoystick>();                      //find the 2 joystick scripts L and R attached to ship instance
        m_FiringJoystickR = joysticks[0];
        m_FiringJoystickL = joysticks[1];

        m_Control.m_PlayerNumber = m_PlayerNumber;
        m_FiringJoystickR.m_PlayerNumber = m_PlayerNumber;
        m_FiringJoystickL.m_PlayerNumber = m_PlayerNumber;
        m_BT.m_playerNumber = m_PlayerNumber;

        Text[] allUIText = m_Canvas.GetComponentsInChildren<Text>();
        m_TreasureText = allUIText[0];
        m_LivesText = allUIText[2];
        m_SpeedText = allUIText[3];

        CC.initialize(m_Instance);
        CC.CameraToShip();

        //Set CC to the CC of the Ship Control using m_Instance
        //shading in world space landing points could be set up here as well

        m_Control.PF = CC;

        
        ShadingInWorldSpace SIWS =  GameObject.Find("Sea").GetComponent<ShadingInWorldSpace>();
        if (SIWS != null)
        {
            var transforms = m_Instance.GetComponentsInChildren<Transform>();
            foreach (Transform thing in transforms)
            {
                if (thing.tag == "landingspot")
                {
                    SIWS.addLandingPoint(thing.gameObject);
                }
            }
        }
        
    }
    
    public void Respawn()
    {
        CC.CameraToShip();
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;
        m_Instance.SetActive(true);
        respawning = false;
        m_Lives--;
    }
    
    public void EnableControl()
    {
        //m_Rigidbody.isKinematic = false;
        m_Control.enabled = true;
        m_FiringJoystickR.enabled = true;
        m_FiringJoystickL.enabled = true;
    }

    public void DisableControl()
    {
        //m_Rigidbody.isKinematic = true;
        m_Control.enabled = false;
        m_FiringJoystickR.enabled = false;
        m_FiringJoystickL.enabled = false;
    }
}
