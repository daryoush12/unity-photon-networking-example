using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoomPreview : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _state;
    [SerializeField] private TextMeshProUGUI _Players;
    [SerializeField] private TextMeshProUGUI _roomName;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private Image _levelPreview;
    [SerializeField] private GameLevels gl;

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        GameState state = (GameState)propertiesThatChanged["GameState"];

        _state.text = ProcessState(state.ToString());
        ScriptableLevel level = gl._levels[(int)PhotonNetwork.CurrentRoom.CustomProperties["level"]];
        _levelName.text = level._name;
        _levelPreview.sprite = level._levelBanner;

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
        Debug.Log("Room Int " + (int)PhotonNetwork.CurrentRoom.CustomProperties["level"]);
        ScriptableLevel level = gl._levels[(int)PhotonNetwork.CurrentRoom.CustomProperties["level"]];
        _levelName.text = level._name;
        _levelPreview.sprite = level._levelBanner;
    }

    public override void OnJoinedRoom()
    {
        _Players.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " +
        PhotonNetwork.CurrentRoom.MaxPlayers;
        _roomName.text = PhotonNetwork.CurrentRoom.Name;
        ScriptableLevel level = gl._levels[(int)PhotonNetwork.CurrentRoom.CustomProperties["level"]];
        _levelName.text = level._name;
        _levelPreview.sprite = level._levelBanner;
    }


    private string ProcessState(string value) {
        return value.Replace("_", " ");
    }
}
