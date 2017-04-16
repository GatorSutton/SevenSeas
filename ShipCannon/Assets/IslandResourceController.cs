using UnityEngine;
using System.Collections;

public class IslandResourceController : MonoBehaviour {

    private bool hasTreasure = true;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "player" && hasTreasure)
        {
            ShipTreasure ST = collider.GetComponent<ShipTreasure>();
                if(!ST.hasTreasure)
            {
                ST.GainTreasure();
            }
        }
    }

}
