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

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master with username "+ PhotonNetwork.AuthValues.UserId);
        Debug.Log("In lobby: " + PhotonNetwork.InLobby);
        onConnected?.Invoke();
        PhotonNetwork.JoinLobby();
    }


    public void Connect(string username)
    {
        Debug.Log(username);
        AuthenticationValues authValues = new AuthenticationValues();
        // do not set authValues.Token or authentication will fail
        authValues.AuthType = CustomAuthenticationType.Custom;
        //authValues.AddAuthParameter("nickname", username);
        authValues.UserId = username; // this is required when you set UserId directly from client and not from web service
        PhotonNetwork.AuthValues = authValues;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Room");
    }


}
