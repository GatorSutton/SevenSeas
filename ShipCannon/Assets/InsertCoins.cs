using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InsertCoins : MonoBehaviour {

    private int credits = 0;
    private int coinsNeeded = 4;

    public Text Credits;
    public Text CoinsNeeded;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Coin1"))
        {
            addCoin();
        }

        if (Input.GetButtonDown("Coin2"))
        {
            addCoin();
        }

        if (Input.GetButtonDown("PortFire1") && credits != 0)
        {
            startGame();
        }

        if (Input.GetButtonDown("StarboardFire1") && credits != 0)
        {
            startGame();
        }

        if (Input.GetButtonDown("Anchor1") && credits != 0)
        {
            startGame();
        }

        if (Input.GetButtonDown("Sail1") && credits != 0)
        {
            startGame();
        }

        if (Input.GetButtonDown("PortFire2") && credits != 0)
        {
            startGame();
        }

        if (Input.GetButtonDown("StarboardFire2") && credits != 0)
        {
            startGame();
        }

        if (Input.GetButtonDown("Anchor2") && credits != 0)
        {
            startGame();
        }

        if (Input.GetButtonDown("Sail2") && credits != 0)
        {
            startGame();
        }

        updateCredits();
        updateUI();
    }

    void addCoin()
    {
        coinsNeeded--;
    }

    void updateCredits()
    {
        if (coinsNeeded < 1)
        {
            coinsNeeded = coinsNeeded + 4;
            credits++;
        }
    }

    void startGame()
    {
        SceneManager.LoadScene("miniGame", LoadSceneMode.Single);

    }

    void updateUI()
    {
        Credits.text = "Credits: " + credits;
        CoinsNeeded.text = "Insert " + coinsNeeded + " coins";
    }
}
