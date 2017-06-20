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

    private float alternateSide = 0;
    private float timeStamp = 0;
    private float m_CannonHorizontalInputValue;
    private float m_CannonVerticalInputValue;
    private float m_HorizontalRelativeAngle;
    private float m_VerticalRelativeAngle;

    private int m_HorizontalCannonInput;
    private int m_VerticalCannonInput;

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
        }
        m_HorizontalRelativeAngle = 0;
        m_VerticalRelativeAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalTurn();
        HorizontalTurn();

        if (Input.GetButtonDown("Shoot"))
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + m_CoolDownPeriod;
                Fire();
            }
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
        float ratio = Mathf.InverseLerp(0, 1024, m_HorizontalCannonInput);
        m_HorizontalRelativeAngle = -45 + ratio * 90 + alternateSide;
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