/**
 * SerialCommUnity (Serial Communication for Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.Text;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class Delimiter : MonoBehaviour
{
    public SerialControllerCustomDelimiter serialController;

    private ShipControl SC1;
    private ShipFiringJoystick SF1;
    private ShipFiringJoystick SF2;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialControllerCustomDelimiter>();
    }

    // Executed each frame
    void Update()
    {
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Sending some action");
            // Sends a 65 (ascii for 'A') followed by an space (ascii 32, which 
            // is configured in the controller of our scene as the separator).
            serialController.SendSerialMessage(new byte[] { 65, 32 });
        }


        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        byte[] message = serialController.ReadSerialMessage();

        /*
        if (message == null)                                        //this caused messages to return null instead of just ignoring null messages hmmmm....
            print("nullMessage");
            return;
          */
        
        StringBuilder sb = new StringBuilder();
        foreach (byte b in message)
            sb.AppendFormat("(#{0})    ", b);
        //  Debug.Log("Received some bytes, printing their ascii codes: " + sb);

        if (message.Length == 9)
        {
            if (SC1 != null && SF1 != null && SF2 != null)
            {
                SC1.RutterValue += (float)(message[0] - 128);
               // message[0] = 128;
                SF1.HorizontalCannonInput = message[1] * 256 + message[2];
                SF1.VerticalCannonInput = message[3] * 256 + message[4];
                SF2.HorizontalCannonInput = message[5] * 256 + message[6];
                SF2.VerticalCannonInput = message[7] * 256 + message[8];
                print("done");
            }
        }


    }

    public void initalize()
    {
        SC1 = GameObject.FindGameObjectWithTag("player").GetComponent<ShipControl>();
        SF1 = GameObject.FindGameObjectWithTag("cannon1").GetComponent<ShipFiringJoystick>();
        SF2 = GameObject.FindGameObjectWithTag("cannon2").GetComponent<ShipFiringJoystick>();

    }
}
