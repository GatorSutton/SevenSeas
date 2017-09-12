using UnityEngine;
using System.Collections;

public class BaseTreasure : MonoBehaviour {

    public int m_playerNumber = 1;
    private int treasureCount = 0;


    public int TreasureCount
    {
        get
        {
            return treasureCount;
        }
    }
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "player")
        {
            if (collider.GetComponent<ShipControl>().m_PlayerNumber == m_playerNumber)
            {
                ShipTreasure ST = collider.GetComponent<ShipTreasure>();
                if (ST.hasTreasure)
                {
                    ST.DropTreasure();
                    treasureCount++;
                }
            }
            
        }
    }
}
