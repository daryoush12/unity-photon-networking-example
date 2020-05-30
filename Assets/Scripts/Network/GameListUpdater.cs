using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameListUpdater : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    [SerializeField] GameObject _listView;
    [SerializeField] GameObject _rowFab;

    private void Start()
    {
        PhotonNetwork.NetworkingClient.AddCallbackTarget(this);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //Clear View
        //Update rooms to UI
        foreach(RoomInfo room in roomList)
        {
            GameObject inst = Instantiate(_rowFab);
            inst.transform.parent = _listView.transform;
            inst.GetComponent<RoomHandler>().SetInformation(room);
        }
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }
}
