using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject m_Player;
    public Transform m_SpawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnPlayer()
    {
        Instantiate(m_Player, m_SpawnPoint);
    }
}
