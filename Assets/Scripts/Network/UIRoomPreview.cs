using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRoomPreview : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _state;
    [SerializeField] private TextMeshProUGUI _Players;
    [SerializeField] private TextMeshProUGUI _roomName;

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        GameState state = (GameState)propertiesThatChanged["GameState"];

        _state.text = ProcessState(state.ToString());

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        _Players.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " + 
            PhotonNetwork.CurrentRoom.MaxPlayers;
    }

    public override void OnCreatedRoom()
    {
        _Players.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " +
       PhotonNetwork.CurrentRoom.MaxPlayers;
        _roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnJoinedRoom()
    {
        _Players.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " +
        PhotonNetwork.CurrentRoom.MaxPlayers;
        _roomName.text = PhotonNetwork.CurrentRoom.Name;
    }


    private string ProcessState(string value) {
        return value.Replace("_", " ");
    }
}
