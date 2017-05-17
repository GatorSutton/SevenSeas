using UnityEngine;
using System.Collections;

public class ShipTreasure : MonoBehaviour {

    public bool hasTreasure = false;
    public GameObject Treasure;

	// Use this for initialization
	void Start () {
        Treasure.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GainTreasure()
    {
        hasTreasure = true;
        Treasure.SetActive(true);
    }

    public void DropTreasure()
    {
        hasTreasure = false;
        Treasure.SetActive(false);
    }
}
