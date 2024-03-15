using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{

    private static void SendTCPData(Packet packet)
    {
        packet.WriteLength();
        Client.Instance.tcp.SendData(packet);
    }

    #region

    public static void WelcomeReceived()
    {
        using (Packet packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            packet.Write(Client.Instance.myId);
            packet.Write(UIManager.Instance.usernameField.text);

            SendTCPData(packet);
        }
    }

    public static void SendMessageToServer() 
    {
        using (Packet packet = new Packet((int)ClientPackets.sendMessageToServer))
        {
            var message = UIManager.Instance.messageField.text;
            packet.Write(Client.Instance.myId);
            packet.Write(message);

            SendTCPData(packet);
        }
    }

    public static void RegisterNewUser()
    {
        using (Packet packet = new Packet((int)ClientPackets.registerNewUser))
        {
            var message = UIManager.Instance.usernameField.text;
            packet.Write(Client.Instance.myId);
            packet.Write(message);

            SendTCPData(packet);
        }
    }

    public static void ConnectUser()
    {
        using (Packet packet = new Packet((int)ClientPackets.connectUser))
        {
            
            var message = UIManager.Instance.usernameField.text;
            packet.Write(Client.Instance.myId);
            packet.Write(message);

            SendTCPData(packet);
        }
    }

    #endregion

}
