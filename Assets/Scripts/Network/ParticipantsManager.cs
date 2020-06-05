using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class ParticipantsManager : MonoBehaviourPunCallbacks
{
    public RoomParticipantEvent onUpdate;

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Hashtable hash = new Hashtable();
        hash.Add("state", State.Unprepared);
        newPlayer.SetCustomProperties(hash);
        onUpdate?.Invoke(PhotonNetwork.CurrentRoom.Players.Values.ToArray());
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        onUpdate?.Invoke(PhotonNetwork.CurrentRoom.Players.Values.ToArray());
    }

    public override void OnCreatedRoom()
    {
        Hashtable hash = new Hashtable();
        hash.Add("state", State.Unprepared);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        onUpdate?.Invoke(PhotonNetwork.CurrentRoom.Players.Values.ToArray());

    }

    public override void OnJoinedRoom()
    {
        onUpdate?.Invoke(PhotonNetwork.CurrentRoom.Players.Values.ToArray());
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        onUpdate?.Invoke(PhotonNetwork.CurrentRoom.Players.Values.ToArray());
    }

 

}

public enum State {Ready, Unprepared}
public enum GameState { Ready_To_Start, Waiting_On_Players, In_Game }


[System.Serializable]
public class RoomParticipantEvent : UnityEvent<Player[]> { }