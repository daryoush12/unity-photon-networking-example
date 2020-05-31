using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

public class CreateRoomForm : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private Slider _maxPlayers;

    public void SubmitForm()
    {
        RoomOptions options = new RoomOptions();
        byte maxplayers = (byte)Convert.ToInt32(_maxPlayers.value);
        Debug.Log(maxplayers);
        options.MaxPlayers = maxplayers;
        PhotonNetwork.CreateRoom(_name.text, options);
        
    }

    public override void OnCreatedRoom()
    {
     

            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.LeaveLobby();
            }     
    }

    public override void OnLeftLobby()
    {
        PhotonNetwork.JoinRoom(_name.text);
    }
}
