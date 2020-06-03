using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using UnityEngine.Events;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkManager: MonoBehaviourPunCallbacks
{

    public UnityEvent onConnected;
    public UnityEvent onDisconnected;

    public ConnectionEvent onConnectionFailed;

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master with username "+ PhotonNetwork.AuthValues.UserId);
        Debug.Log("In lobby: " + PhotonNetwork.InLobby);
        Debug.Log(PhotonNetwork.GameVersion);

   

        onConnected?.Invoke();
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        if(cause == DisconnectCause.None)
        {
            onDisconnected?.Invoke();
        }
        else
        {
            onConnectionFailed?.Invoke(cause);
        }   
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Room");
    }

    public void Connect(string username)
    {
        if (PhotonNetwork.NetworkingClient.AppVersion == PhotonNetwork.GameVersion)
        {
            Debug.Log(username);
            //AuthenticationValues authValues = new AuthenticationValues();
            // do not set authValues.Token or authentication will fail
            //authValues.AuthType = CustomAuthenticationType.Custom;
            //authValues.AddAuthParameter("nickname", username);
            //authValues.UserId = username; // this is required when you set UserId directly from client and not from web service
            //PhotonNetwork.AuthValues = authValues;
            PhotonNetwork.LocalPlayer.NickName = username;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}

public class ConnectionEvent : UnityEvent <DisconnectCause> { }
