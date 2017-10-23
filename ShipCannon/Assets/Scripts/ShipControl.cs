using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {

    public int m_PlayerNumber = 1;
    public float m_Speed = 10f;
    public float m_CalculatedSpeed;
    public float m_TurnSpeed = 10f;
    public float m_SailMinValue;
    public float m_SailMaxValue;
    public float m_RutterMinValue;
    public float m_RutterMaxValue;
    public float m_AnchorSpeed;
    public float m_AnchorCooldownPeriod;

    public CameraControl PF;


    private ShipTreasure ST;

    private float m_TreasureSpeedInhibitor;
    private Rigidbody m_Rigidbody;
    private float m_SailInputValue;
    private float m_TurnInputValue;
    private float m_SailValue = 1;

    private bool m_AnchorDown = false;
    private float m_AnchorTurn = 1;
    private float m_AnchorMove = 1;
    private float m_Time = 0;

    public float RutterValue
    {
        set { m_RutterValue = value;}
        get { return m_RutterValue; }
    }

    private float m_RutterValue = 0;
    private float anchorTimeStamp = 0;
    private string m_AnchorButton;
    private string m_SailButton;

    
    

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

	// Use this for initialization
	void Start ()
    {
        ST = GetComponent<ShipTreasure>();
        m_AnchorButton = "Anchor" + m_PlayerNumber;
        m_SailButton = "Sail" + m_PlayerNumber;
	}
	
	// Update is called once per frame
	void Update ()
    {
       

        if(Input.GetButtonDown(m_SailButton) && (m_SailValue==m_SailMinValue))
        {
            if (m_SailValue == m_SailMinValue)
            {
                m_SailValue = m_SailMaxValue;
                m_RutterMaxValue = 200f;
                m_RutterMinValue = -200f;
            }
            else
            {
                m_SailValue = m_SailMinValue;
                m_RutterMaxValue = 600f;
                m_RutterMinValue = -600f;
            }
        }
        else if(Input.GetButtonDown(m_SailButton) && (m_SailValue==m_SailMaxValue))
        {
                m_SailValue = m_SailMinValue;
                m_RutterMaxValue = 600f;
                m_RutterMinValue = -600f;
        }

        if (Input.GetButtonDown(m_AnchorButton))
        {
            /*
            if (anchorTimeStamp <= Time.time)
            {
                anchorTimeStamp = Time.time + m_AnchorCooldownPeriod;
                m_AnchorDown = !m_AnchorDown;
                if (m_AnchorDown)
                {
                  //  PF.CameraToLeft();
                }
                else
                {
                  //  PF.CameraToShip();
                }
            }
            */

            if (PF.m_Position != CameraControl.Position.Above)
            {
                PF.CameraToAbove();
            }
            else
            {
                PF.CameraToShip();
            }
            

        }


    }

    void FixedUpdate()
    {
        Move();
        Turn();
        AnchorControl();
        WeightOnShip();
    }

    private void Move()
    {
        m_CalculatedSpeed = m_SailValue * m_Speed * Time.deltaTime * m_AnchorMove * m_TreasureSpeedInhibitor;
        Vector3 movement = -transform.right * m_CalculatedSpeed;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {
        m_RutterValue = Mathf.Max(m_RutterValue, m_RutterMinValue);
        m_RutterValue = Mathf.Min(m_RutterValue, m_RutterMaxValue);
        
        float turn = m_RutterValue * m_TurnSpeed * Time.deltaTime * m_AnchorTurn;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    private void AnchorControl()
    {
        if(m_AnchorDown == true)
        {
            m_Time += Time.deltaTime * m_AnchorSpeed;

            if (m_Time < 1)
            {
                m_AnchorMove = Mathf.Lerp(1, 0, m_Time);
                m_AnchorTurn = Mathf.Lerp(1, 4, m_Time);
            }
            else
            {
                m_AnchorTurn = 0;
            }
           
        }
        else
        {
            m_Time = 0;
            m_AnchorMove = 1f;
            m_AnchorTurn = 1f;
        }
    }

    private void WeightOnShip()
    {
        if(ST.hasTreasure)
        {
            m_TreasureSpeedInhibitor = .7f;
        }
        else
        {
            m_TreasureSpeedInhibitor = 1f;
        }
    }



  
}
