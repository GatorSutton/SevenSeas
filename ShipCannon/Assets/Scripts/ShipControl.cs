using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {

    public int m_PlayerNumber = 1;

    public float m_CalculatedSpeed;
    public float m_TurnSpeed = 10f;
    public float m_SailMinValue;
    public float m_SailMaxValue;
    public float m_RutterMinValue;
    public float m_RutterMaxValue;
    public float m_AnchorSpeed;
    public float m_AnchorCooldownPeriod;
    public float m_SpinOutTime;
    public float m_SpinOutDegrees;

    public CameraControl PF;


    private ShipTreasure ST;

    private bool m_SpinningOut = false;
    private float m_Speed = 5;
    private float m_OldSpeed = 1;
    private float m_TargetSpeed = 1;
    private float m_Time = 0;
    private float m_TreasureSpeedInhibitor;
    private Rigidbody m_Rigidbody;
    private float m_SailValue = 1;

    public float RutterValue
    {
        set { m_RutterValue = value;}
        get { return m_RutterValue; }
    }

    public float RutterChange
    {
        set { m_RutterChange = value; }
        get { return m_RutterChange; }
    }

    private float m_SpinOutTimeLeft;
    private float[] m_rutterChanges = new float[20];
    private int m_RutterIndex = 0;
    private float m_RutterChange = 0;
    private float m_RutterValue = 0;
    private string m_AnchorButton;
    private string m_SailButton;



    
    

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

	void Start ()
    {
        ST = GetComponent<ShipTreasure>();
        m_AnchorButton = "Anchor" + m_PlayerNumber;
        m_SailButton = "Sail" + m_PlayerNumber;
	}
	
	void Update ()
    {

        if(Input.GetButtonDown(m_SailButton))
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

        if (Input.GetButtonDown(m_AnchorButton))
        {

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
        if (!m_SpinningOut)
        {
            Move();
            Turn();
        }
        WeightOnShip();
        SpeedAdjust();
    }

    private void SpeedAdjust()
    {
        m_Speed = Mathf.Lerp(m_OldSpeed, m_TargetSpeed, m_Time);
        m_CalculatedSpeed = m_SailValue * m_Speed * Time.deltaTime * m_TreasureSpeedInhibitor;
    }

    private void Move()
    {
        Vector3 movement = -transform.right * m_CalculatedSpeed;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {
        m_RutterValue = Mathf.Max(m_RutterValue, m_RutterMinValue);
        m_RutterValue = Mathf.Min(m_RutterValue, m_RutterMaxValue);
        
        float turn = m_RutterValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
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

    public void UpdateRutter()
    {
        m_rutterChanges[m_RutterIndex] = m_RutterChange;
        if (m_RutterIndex < m_rutterChanges.Length - 1)
        {
            m_RutterIndex++;
        }
        else
        {
            m_RutterIndex = 0;
        }

        float total = 0;
        for (int i = 0; i < m_rutterChanges.Length; i++)
        {
            total += m_rutterChanges[i];
        }
        if( Mathf.Abs(total) > 400 && !m_SpinningOut)
        { 
            //if cooldown and current speed are appropriate for a spinout
            StartCoroutine(SpinOut());
        }
    }

    private IEnumerator SpinOut()
    {
        m_SpinningOut = true;
        m_SpinOutTimeLeft = m_SpinOutTime;
        //hold intial direction for set amount of time and turn ship set amount of degrees during that time
        m_rutterChanges = new float[20];
        print("spinout");
        Vector3 direction = -transform.right;

        while (m_SpinOutTimeLeft >= 0.0f)
        {
            m_SpinOutTimeLeft -= Time.deltaTime;
            m_Rigidbody.MovePosition(m_Rigidbody.position + direction*m_CalculatedSpeed);
           m_Rigidbody.MoveRotation(m_Rigidbody.rotation * Quaternion.Euler(0f,m_SpinOutDegrees/m_SpinOutTime*Time.deltaTime,0f));
            yield return null;
        }

        m_SpinningOut = false;
        m_RutterValue = 0;
        print("doneSpinning");

        
    }





  
}
