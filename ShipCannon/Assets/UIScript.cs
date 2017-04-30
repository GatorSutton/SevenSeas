using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    
    public BaseTreasure BT;

    private Text Score;

	// Use this for initialization
	void Start () {
        Score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Score.text = "Treasures: " + BT.TreasureCount;
	}
}
