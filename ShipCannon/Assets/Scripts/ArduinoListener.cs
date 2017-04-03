using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoListener : MonoBehaviour
{
   
    public int turnData
    {
        get { return m_turnData; }
        set { m_turnData = value; }
    }
    private int m_turnData;
    private ShipControl SC;



    SerialPort sp = new SerialPort("COM3", 9600);

    void Start()
    {
        SC = GetComponent<ShipControl>();

        sp.Open();
        sp.ReadTimeout = 1;
    }

    void Update()
    {
        try
        {
            m_turnData = Int32.Parse(sp.ReadLine());
        }
        catch (System.Exception)
        {
        }

        SC.RutterValue += m_turnData;
        m_turnData = 0;
    }
}