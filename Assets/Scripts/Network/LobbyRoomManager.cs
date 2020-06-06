using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class LobbyRoomManager : MonoBehaviourPunCallbacks
{

    public UnityEvent onGameStarted;

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if((GameState)PhotonNetwork.CurrentRoom.
            CustomProperties["GameState"] == GameState.Ready_To_Start)
        {
            Hashtable hash = new Hashtable();
            hash.Add("GameState", GameState.Waiting_On_Players);
            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
       

        if (isAllReady())
        {
            Hashtable hash = new Hashtable();
            hash.Add("GameState", GameState.Ready_To_Start);
            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
        }else
        {
            Hashtable hash = new Hashtable();
            hash.Add("GameState", GameState.Waiting_On_Players);
            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
        }

       
    }

    public void StartGame()
    {
        if((GameState)PhotonNetwork.CurrentRoom.CustomProperties["GameState"] == GameState.Ready_To_Start)
        {
            //Start
            Hashtable hash = new Hashtable();
            hash.Add("GameState", GameState.In_Game);
            PhotonNetwork.CurrentRoom.SetCustomProperties(hash);

            PhotonNetwork.LoadLevel("Room");
        }
    }

    public bool isAllReady()
    {
        int currentPlayers = PhotonNetwork.CurrentRoom.Players.Count;
        int result = 0;
        foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            if ((State)player.CustomProperties["state"] == State.Ready)
            {
                result += 1;
            }
        }
        return (result == currentPlayers);
    }
}
