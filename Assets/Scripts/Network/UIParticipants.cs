using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParticipants : MonoBehaviourPun
{

    [SerializeField] private GameObject _participantFab;
    [SerializeField] private Transform _ListHolder;


    public void RenderNewParticipant(Player player, List<Player> players)
    {
        GameObject ob = PhotonNetwork.Instantiate(_participantFab.name, new Vector3(0F, 0F, 0F), Quaternion.identity, 0);
        ob.transform.SetParent(_ListHolder);
        ob.transform.localScale = new Vector3(1F, 1F, 1F);
        ob.GetComponent<UIParticipant>().SetUI();
    }
}
