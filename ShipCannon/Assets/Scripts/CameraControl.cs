using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject m_Player;
    public Transform m_PlayerFollow;
    public Transform m_SkyCam;
    public Transform m_RespawnPoint;
    public Transform m_PlayerLeft;

   

    private Transform m_Target;
    private Transform m_PreviousTarget;
    private Camera m_Camera;
    private float t = 0;

	// Use this for initialization
	void Start () {
        m_Camera = GetComponent<Camera>();
        // m_Target = m_PlayerFollow;
        m_Target = m_SkyCam;
        m_PreviousTarget = m_SkyCam;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        SetTime();
        Move();
      
	}

    private void Move()
    {
        /*
        transform.position = Vector3.Lerp(m_PlayerFollow.position, m_SkyCam.position, t);
        transform.rotation = Quaternion.Lerp(m_PlayerFollow.rotation, m_SkyCam.rotation, t);
        */
        
        transform.position = Vector3.Lerp(m_PreviousTarget.position, m_Target.position, t);
        transform.rotation = Quaternion.Lerp(m_PreviousTarget.rotation, m_Target.rotation, t);

    }

    private void SetTime()
    {
        /*
        if (m_Player.activeSelf == false)
        {
            if(t < 1)
            {
                t += Time.deltaTime/4;
            }
        }
        else
        {
            if(t > 0)
            {
                t -= Time.deltaTime/4;
            }
        }
        */
        
        if(t < 1)
        {
            t += Time.deltaTime / 2;
        }
        
    }

    public void CameraToShip()
    {
        t = 0;
        Transform holderTransform = m_Target;
        m_Target = m_PlayerFollow;
        m_PreviousTarget = holderTransform;
    }

    public void CameraToSky()
    {
        t = 0;
        Transform holderTransform = m_Target;
        m_Target = m_SkyCam;
        m_PreviousTarget = holderTransform;
    }

    public void CameraToLeft()
    {
        t = 0;
        Transform holderTransform = m_Target;
        m_Target = m_PlayerLeft;
        m_PreviousTarget = holderTransform;
    }
    
        
}
