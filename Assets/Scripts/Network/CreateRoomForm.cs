using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CreateRoomForm : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _name = null;
    [SerializeField] private Slider _maxPlayers = null;
    [SerializeField] private HorizontalSelector _selector = null;
    [SerializeField] private GameLevels _levels;

    public void SubmitForm()
    {
     
        RoomOptions options = new RoomOptions();
        byte maxplayers = (byte)Convert.ToInt32(_maxPlayers.value);
        Debug.Log(maxplayers);
        options.MaxPlayers = maxplayers;
        Debug.Log(_levels._levels[_selector.index].name);

        Hashtable hash = new Hashtable();
        hash.Add("level", _selector.index);
        options.CustomRoomProperties = hash;


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
        Hashtable hash = new Hashtable();
        hash.Add("level", _selector.index);
        PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
    }
}
