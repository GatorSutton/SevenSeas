using UnityEngine;
using System.Collections;

public class ShipFiring : MonoBehaviour {

    public Rigidbody m_Cannonball;
    public Transform m_FireTransform;
    public float m_LaunchVelocity = 30f;
    public float m_CoolDownPeriod;
    public float m_CannonTurnSpeed;
    public float m_MaxCannonTurn;
    public Transform ship;

    private float timeStamp = 0;
    private float m_CannonHorizontalInputValue;
    private float m_CannonVerticalInputValue;
    private float m_HorizontalRelativeAngle;
    private float m_VerticalRelativeAngle;


    void Start()
    {
        m_HorizontalRelativeAngle = 0;
        m_VerticalRelativeAngle = 0;
    }

	// Update is called once per frame
	void Update () {

        VerticalTurn();
        HorizontalTurn();
	    
        if(Input.GetButtonDown("Shoot"))
        {
            print(timeStamp);
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + m_CoolDownPeriod;
                Fire();
            }
            
     
        }

        m_CannonHorizontalInputValue = Input.GetAxis("CannonHorizontal");
        m_CannonVerticalInputValue = Input.GetAxis("CannonVertical");

    }

    void FixedUpdate()
    {
        KeepUpWithShip();
    }

    private void Fire()
    {

        Rigidbody cannonBallInstance = Instantiate(m_Cannonball, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        cannonBallInstance.velocity = m_LaunchVelocity * m_FireTransform.forward;
    }

    private void HorizontalTurn()
    {
        
        float turnAngle = transform.rotation.eulerAngles.y;

        if(m_HorizontalRelativeAngle > 45)
        {
          m_CannonHorizontalInputValue = Mathf.Min(m_CannonHorizontalInputValue, 0);
        }

        if (m_HorizontalRelativeAngle < - 45)
        {
            m_CannonHorizontalInputValue = Mathf.Max(m_CannonHorizontalInputValue, 0);
        }

        m_HorizontalRelativeAngle += (m_CannonHorizontalInputValue * m_CannonTurnSpeed * Time.deltaTime);

    }

    private void VerticalTurn()
    {

        float turnAngle = transform.rotation.eulerAngles.x;

        if (turnAngle < 330 && turnAngle > 50)
        {
            m_CannonVerticalInputValue = Mathf.Max(m_CannonVerticalInputValue, 0);
        }

        if (turnAngle > 0 && turnAngle < 300)
        {
            m_CannonVerticalInputValue = Mathf.Min(m_CannonVerticalInputValue, 0);
        }

        m_VerticalRelativeAngle += (m_CannonVerticalInputValue * m_CannonTurnSpeed * Time.deltaTime);

    }

    private void KeepUpWithShip()
    {
        float angle = ship.eulerAngles.y;

        //transform.position = ship.position + new  Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),1f,Mathf.Cos(angle * Mathf.Deg2Rad));
        transform.rotation = Quaternion.Euler(0f, m_HorizontalRelativeAngle, 0f) * ship.rotation;
        transform.Rotate(m_VerticalRelativeAngle, 0f, 0f, Space.Self);
    }
}