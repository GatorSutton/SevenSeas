using UnityEngine;
using System.IO.Ports;
using System.Text;

public class ArduinoListener : MonoBehaviour
{
   
    public int turnData
    {
        get { return m_turnData; }
        set { m_turnData = value; }
    }
    private int m_turnData = 0;
    string messageData;
    byte[] messageDataConverted;
    private ShipControl SC;


    SerialPort sp = new SerialPort("COM4", 9600);

    void Start()
    {
        
        SC = GameObject.FindGameObjectWithTag("player").GetComponent<ShipControl>();

        sp.Open();
        sp.ReadTimeout = 1;
    }

    void Update()
    {
        try
        {
            //m_turnData = Int32.Parse(sp.ReadLine());
            messageData = sp.ReadLine();
            messageDataConverted = Encoding.ASCII.GetBytes(messageData);
        }
        catch (System.Exception)
        {
        }

        if (SC != null)
        {
            SC.RutterValue += m_turnData;
        }
        m_turnData = 0;

        print(messageDataConverted[0]);
    }
}