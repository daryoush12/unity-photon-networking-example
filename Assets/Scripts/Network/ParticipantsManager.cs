using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class ParticipantsManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject _participantFab;
    [SerializeField] private Transform _ListHolder;

    public RoomEvent onNewParticipant;
    public RoomEvent onParticipantLeft;

    private List<Player> _Participants = new List<Player>();

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Hashtable hash = new Hashtable();
        hash.Add("state", State.Unprepared);
        newPlayer.SetCustomProperties(hash);
        _Participants.Add(newPlayer);
        onNewParticipant?.Invoke(newPlayer, _Participants);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnCreatedRoom()
    {
        Hashtable hash = new Hashtable();
        hash.Add("state", State.Unprepared);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        _Participants.Add(PhotonNetwork.LocalPlayer);
        onNewParticipant?.Invoke(PhotonNetwork.LocalPlayer, _Participants);
    }
    
    public bool isAllReady()
    {
        int currentPlayers = PhotonNetwork.CurrentRoom.Players.Count;
        int result = 0;
        foreach(Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            if((State)player.CustomProperties["state"] == State.Ready)
            {
                result += 1;
            }
        }
        return (result == currentPlayers);
    }

  
}

public enum State {Ready, Unprepared}

[System.Serializable]
public class RoomEvent : UnityEvent<Player, List<Player>> {}