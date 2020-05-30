using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _status;
    [SerializeField] private Text _players;

    private RoomInfo _room;

    private void Awake()
    {
        
    }

    public void SetInformation(RoomInfo info)
    {
        _name.text = info.Name;
        _status.text = info.IsOpen.ToString();
        _players.text = info.PlayerCount + " / " + info.MaxPlayers;
        _room = info;
    }

    public void Join()
    {
        PhotonNetwork.JoinRoom(_room.Name);
    }

   
}
