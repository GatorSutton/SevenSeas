using UnityEngine;
using System.Collections;

public class IslandResourceController : MonoBehaviour {

    public Material[] materials;


    private bool hasTreasure = true;
    private Renderer rend;


	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material = materials[0];
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
                hasTreasure = false;
                rend.material = materials[1];
            }
        }
    }

}
