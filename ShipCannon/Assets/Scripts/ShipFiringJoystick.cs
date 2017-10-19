using UnityEngine;
using System.Collections;

public class ShipFiringJoystick : MonoBehaviour
{

    public int m_PlayerNumber = 1;
    public Rigidbody m_Cannonball;
    public Transform m_FireTransform;
    public Rigidbody m_Player;
    public float m_RecoilForce;
    public float m_LaunchVelocity = 30f;
    public float m_CoolDownPeriod;
    public float m_CannonTurnSpeed;
    public float m_MaxCannonTurn;
    public Transform ship;
    public bool isLeftSide;

    public float m_VerticalRelativeAngle = -15;

    private float alternateSide = 0;
    private float timeStamp = 0;
    private float m_CannonHorizontalInputValue;
    private float m_CannonVerticalInputValue;
    private float m_HorizontalRelativeAngle;


    private int m_HorizontalCannonInput;
    private int m_VerticalCannonInput;
    private string m_FiringButton;

    public int HorizontalCannonInput
    {
        set { m_HorizontalCannonInput = value; }
    }

    public int VerticalCannonInput
    {
        set { m_VerticalCannonInput = value; }

    }


    void Start()
    {
        if(isLeftSide)
        {
            alternateSide = 180;
            m_FiringButton = "PortFire" + m_PlayerNumber;
        }
        else
        {
            m_FiringButton = "StarboardFire" + m_PlayerNumber;
        }
        m_HorizontalRelativeAngle = 0;
        m_VerticalRelativeAngle = -15;
    }

    // Update is called once per frame
    void Update()
    {
       // VerticalTurn();
        HorizontalTurn();

        /*
        if (Input.GetButtonUp(m_FiringButton))
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + m_CoolDownPeriod;
                Fire();
            }
        }
        */

        if (Input.GetButton(m_FiringButton))
        {
            if (m_VerticalRelativeAngle > -45)
            {
                m_VerticalRelativeAngle -= .5f;
            }
        }

        if (Input.GetButtonUp(m_FiringButton))
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + m_CoolDownPeriod;
                Fire();
                
            }
            m_VerticalRelativeAngle = -15;
        }



    }

    void FixedUpdate()
    {
        KeepUpWithShip();
    }

    private void Fire()
    {

        Rigidbody cannonBallInstance = Instantiate(m_Cannonball, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        cannonBallInstance.velocity = m_LaunchVelocity * m_FireTransform.forward;

        m_Player.AddForce(-m_FireTransform.forward * m_RecoilForce);
    }

    private void HorizontalTurn()
    {
        //float ratio = Mathf.InverseLerp(0, 1024, m_HorizontalCannonInput);
        float ratio = Mathf.InverseLerp(337, 686, m_HorizontalCannonInput);                         //limit the input of the sensor to 90 degrees

        if (isLeftSide)
        {
            m_HorizontalRelativeAngle = -(m_MaxCannonTurn/2) + ratio * m_MaxCannonTurn + 180;
        }
        else
        {
            m_HorizontalRelativeAngle = -(m_MaxCannonTurn/2) + ratio * m_MaxCannonTurn;
        }

        //m_HorizontalRelativeAngle = -45 + ratio * m_MaxCannonTurn + alternateSide;
    }

    private void VerticalTurn()
    {
        float ratio = Mathf.InverseLerp(0, 1024, m_VerticalCannonInput);
        m_VerticalRelativeAngle = -30 * ratio;
    }

    private void KeepUpWithShip()
    {
        transform.rotation = Quaternion.Euler(0f, m_HorizontalRelativeAngle, 0f) * ship.rotation;
        transform.Rotate(m_VerticalRelativeAngle, 0f, 0f, Space.Self);
    }
}