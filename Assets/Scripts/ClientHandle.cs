using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{

    public static void Welcome(Packet packet)
    {
        string message = packet.ReadString();
        int myId = packet.ReadInt();

        Debug.Log($"Message from server: {message}");
        Client.Instance.myId = myId;
       // ClientSend.WelcomeReceived();
        
    }

    public static void SendMessageToServer(Packet packet)
    {
        string message = packet.ReadString();
        int myId = packet.ReadInt();

        Debug.Log($"Message from server: {message}");
        Client.Instance.myId = myId;
        ClientSend.WelcomeReceived();
    }

    public static void RegisteredNewUser(Packet packet)
    {
        string message = packet.ReadString();
        int myId = packet.ReadInt();

        Debug.Log($"Message from server: {message}");
        Client.Instance.myId = myId;
        ClientSend.WelcomeReceived();
    }

    public static void SendIntoApp(Packet packet)
    {
        Client.Instance.IdInDatabase = packet.ReadInt();
        UIManager.Instance.ToAppTrigger();
    }

}
