using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class ParticipantsManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject _participantFab;
    [SerializeField] private Transform _ListHolder;

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Hashtable hash = new Hashtable();
        hash.Add("isReady", false);
        newPlayer.SetCustomProperties(hash);
        GameObject ob = Instantiate(_participantFab);
        _participantFab.transform.parent = _ListHolder;

        
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }


    public void HostJoinedRoom()
    {
        GameObject ob = PhotonNetwork.Instantiate(_participantFab.name, new Vector3(0F, 0F, 0F), Quaternion.identity, 0);
        ob.transform.SetParent(_ListHolder);
        ob.transform.localScale = new Vector3(1F,1F,1F);
        Hashtable hash = new Hashtable();
        hash.Add("state", State.Unprepared);
        ob.GetComponent<PhotonView>().Owner.SetCustomProperties(hash);
        ob.GetComponent<UIParticipant>().SetUI();
    }
}

public enum State {Ready, Unprepared}
