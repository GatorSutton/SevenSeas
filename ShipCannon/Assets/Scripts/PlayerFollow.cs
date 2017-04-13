using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

    public GameObject m_Player;
    public Transform m_PlayerFollow;
    public Transform m_SkyCam;

    private Transform m_Target;
    private Transform m_PreviousTarget;
    private Camera m_Camera;
    private float t = 0;

	// Use this for initialization
	void Start () {
        m_Camera = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        SetTarget();
        Move();
      
	}

    private void Move()
    {
        transform.position = Vector3.Lerp(m_PlayerFollow.position, m_SkyCam.position, t);
        transform.rotation = Quaternion.Lerp(m_PlayerFollow.rotation, m_SkyCam.rotation, t);

    }

    private void SetTarget()
    {
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
    }
    
        
}
