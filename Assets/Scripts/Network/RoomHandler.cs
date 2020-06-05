using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using ScriptableObjectArchitecture;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] private Text _name = null;
    [SerializeField] private Text _players = null;
    [SerializeField] private GameEvent onJoin;

    private RoomInfo _room;

    public void SetInformation(RoomInfo info)
    {
        _name.text = info.Name;
      //  _status.text = info.IsOpen.ToString();
        _players.text = info.PlayerCount + " / " + info.MaxPlayers;
        _room = info;
    }

    public void Join()
    {
        PhotonNetwork.JoinRoom(_room.Name);
        onJoin?.Raise();
    }

   
}
