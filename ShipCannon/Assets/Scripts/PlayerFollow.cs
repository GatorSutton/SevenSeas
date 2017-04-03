using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

    public Transform m_Player;
    private Camera m_Camera;

	// Use this for initialization
	void Start () {
        m_Camera = GetComponent<Camera>();
        m_Camera.orthographicSize = 10;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        Move();
	}

    private void Move()
    {
        Vector3 playerPosition = m_Player.transform.position;
        transform.position = new Vector3(playerPosition.x, 10f, playerPosition.z - 3);
    }    
}
