﻿using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {

    public float m_Speed = 10f;
    public float m_TurnSpeed = 10f;
    public float m_SailMinValue;
    public float m_SailMaxValue;
    public float m_RutterMinValue;
    public float m_RutterMaxValue;
    public float m_AnchorSpeed;
 


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
    
  

    
    

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       

        if(Input.GetButtonDown("SailUp"))
        {
            if (m_SailValue < m_SailMaxValue)
            {
                m_SailValue++;
            }
        }

        if(Input.GetButtonDown("SailDown"))
        {
            if (m_SailValue > m_SailMinValue)
            {
                m_SailValue--;
            }
        }

        if(Input.GetButtonDown("Anchor"))
        {
            print(m_AnchorDown);
            m_AnchorDown = !m_AnchorDown;
        }




    }

    void FixedUpdate()
    {
        Move();
        Turn();
        AnchorControl();
    }

    private void Move()
    {
        Vector3 movement = -transform.right * m_SailValue * m_Speed * Time.deltaTime * m_AnchorMove;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {

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



  
}
