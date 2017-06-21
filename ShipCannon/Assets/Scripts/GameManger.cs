using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {

    public Delimiter delimiter;
    public CameraControl CC;
    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public Text m_MessageText1;
    public Text m_MessageText2;

    public GameObject m_ShipPrefab;
    public ShipManager[] m_Ships;


    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;
    private ShipManager m_GameWinner;

	// Use this for initialization
	void Start () {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        StartCoroutine(GameLoop());
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(GameStarting());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameEnding());
       
    }

    private IEnumerator GameStarting()
    {
        SpawnAllShips();
        DisableAllShips();
        delimiter.initalize();
       // CC.initialize();
        //CC.CameraToShip();
        m_MessageText1.text = "PLUNDER!";
        m_MessageText2.text = "PLUNDER!";
        yield return m_StartWait;
    }

    private IEnumerator GamePlaying()
    {
        EnableShipControl();

        m_MessageText1.text = string.Empty;
        m_MessageText2.text = string.Empty;


        while (!OneTeamLeft() && !TreasureVictory())              //remove !OneTeamLeft for testing one team
        {
            RespawnShips();
            UpdateShipUI();
            yield return null;
        }
    }

    private IEnumerator GameEnding()
    {
        DisableAllShips();
        m_GameWinner = getGameWinner();
        m_MessageText1.text = gameOverMessage();
        m_MessageText2.text = gameOverMessage();
        print("gg");
        yield return m_EndWait;
    }

    private bool OneTeamLeft()
    {
        int numTeamsLeft = 0;
        for(int i = 0; i < m_Ships.Length; i++)
        {
            if(m_Ships[i].m_Lives > 0)
            {
                numTeamsLeft++;
            }
        }
        return numTeamsLeft <= 1;
    }

    private bool TreasureVictory()
    {
        bool enoughGold = false;
        for(int i = 0; i < m_Ships.Length; i++)
        {
            if(m_Ships[i].m_Treasures > 2)
            {
                enoughGold = true;
            }
        }
        return enoughGold;
    }

    private ShipManager getGameWinner()
    {
        for (int i = 0; i < m_Ships.Length; i++)        //Check for Treasure Winner
        {
            if(m_Ships[i].m_Treasures > 2)
            {
                return m_Ships[i];
            }
        }

        for (int i = 0; i < m_Ships.Length; i++)        //Check for Lives Winner
        {
            if (m_Ships[i].m_Lives > 0)
            {
                return m_Ships[i];
            }
        }

        return null;
    }

    private string gameOverMessage()
    {
        string message = "TIE";

        if(m_GameWinner != null)
        {
            message = "Player Number " + m_GameWinner.m_PlayerNumber + " Wins";
        }

        return message;
    }

    private void SpawnAllShips()
    {
        for (int i = 0; i < m_Ships.Length; i++)
        {
            m_Ships[i].m_Instance = Instantiate(m_ShipPrefab, m_Ships[i].m_SpawnPoint.position, m_Ships[i].m_SpawnPoint.rotation) as GameObject;
            m_Ships[i].m_PlayerNumber = i + 1;
            m_Ships[i].Setup();
        }
    }

    private void DisableAllShips()
    {
        for (int i = 0; i < m_Ships.Length; i++)
        {
            m_Ships[i].DisableControl();
        }
    }

    private void EnableShipControl()
    {
        for (int i = 0; i < m_Ships.Length; i++)
        {
            m_Ships[i].EnableControl();
        }
    }

    private void RespawnShips()
    {
        for (int i = 0; i < m_Ships.Length; i++)
        {
            if(m_Ships[i].m_Instance.activeSelf == false)
            {
                m_Ships[i].Respawn();
            }
        }
    }

    private void UpdateShipUI()
    {
        for (int i = 0; i < m_Ships.Length; i++)
        {
            m_Ships[i].m_Treasures = m_Ships[i].m_BT.TreasureCount;                                                         
            m_Ships[i].m_TreasureText.text = "Treasures: " + m_Ships[i].m_Treasures;
            m_Ships[i].m_LivesText.text = "Lives: " + m_Ships[i].m_Lives;
        }
    }



}
