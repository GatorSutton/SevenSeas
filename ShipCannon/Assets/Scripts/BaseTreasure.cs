using UnityEngine;
using System.Collections;

public class BaseTreasure : MonoBehaviour {

    private int treasureCount = 2;
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
            ShipTreasure ST = collider.GetComponent<ShipTreasure>();
                if(ST.hasTreasure)
            {
                ST.DropTreasure();
                treasureCount++;
            }
        }
    }
}
