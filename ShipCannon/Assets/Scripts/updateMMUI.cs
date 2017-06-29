using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateMMUI : MonoBehaviour {

    public Text coinsNeeded;
    public Text credits;
    public Text coinsNeeded2;
    public Text credits2;
    public float speed;

    InsertCoins IC;

	// Use this for initialization
	void Start () {
        IC = FindObjectOfType<InsertCoins>();
	}
	
	// Update is called once per frame
	void Update () {
        updateUI();
	}

    void updateUI()
    {
        credits.text = "Credits: " + IC.credits;
        coinsNeeded.text = "Insert " + IC.coinsNeeded + " coins";
        credits2.text = "Credits: " + IC.credits;
        coinsNeeded2.text = "Insert " + IC.coinsNeeded + " coins";

        if (IC.credits > 0)
        {
            coinsNeeded.text = "PRESS ANY BUTTON TO START";
            coinsNeeded2.text = "PRESS ANY BUTTON TO START";
            Color color = credits.color;
            color.a = Mathf.Round(Mathf.PingPong(Time.time * speed, 1f));
            coinsNeeded.color = color;
            coinsNeeded2.color = color;
        }
    }
}
