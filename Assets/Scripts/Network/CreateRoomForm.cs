using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomForm : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _name;

    public void SubmitForm()
    {
        PhotonNetwork.CreateRoom(_name.text);
        
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
