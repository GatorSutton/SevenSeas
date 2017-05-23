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

    private ShipControl SC;
    private ShipFiringJoystick SF;

    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialControllerCustomDelimiter>();

        SC = GameObject.FindGameObjectWithTag("player").GetComponent<ShipControl>();
        SF = GameObject.FindGameObjectWithTag("cannon1").GetComponent<ShipFiringJoystick>();

        Debug.Log("Press the SPACEBAR to execute some action");
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

        if (message == null)
            return;
        
        StringBuilder sb = new StringBuilder();
        foreach (byte b in message)
            sb.AppendFormat("(#{0})    ", b);
        //  Debug.Log("Received some bytes, printing their ascii codes: " + sb);

        if (message.Length == 5)
        {
            SC.RutterValue += message[0] - 128;
            message[0] = 128;
            SF.HorizontalCannonInput = message[1] * 256 + message[2];
            SF.VerticalCannonInput = message[3] * 256 + message[4];
        }


    }
}
