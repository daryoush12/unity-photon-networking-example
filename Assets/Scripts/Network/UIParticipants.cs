using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIParticipants : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject _participantFab;
    [SerializeField] private RectTransform _ListHolder;
    [SerializeField] private TextMeshProUGUI _AllReady;


    public void RenderParticipants(Player[] players)
    {
        Debug.Log(players.Length);

        Clean(_ListHolder);
        /*we are checking against currentroom player count 
         * due  to player array being instantiated as size of maxplayers.*/
        foreach(Player player in players)
        {
            Debug.Log("Render "+player.NickName);
            GameObject ob = Instantiate(_participantFab);
            ob.transform.SetParent(_ListHolder);
            ob.transform.localScale = new Vector3(1.0F, 1.0F, 1.0F);
            ob.GetComponent<UIParticipant>().SetUI(player);
        }
    }

    public override void OnJoinedRoom()
    {
        List<Player> players = PhotonNetwork.CurrentRoom.Players.Values.ToList();
        Clean(_ListHolder);
        foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            Debug.Log("Render " + player.NickName);
            GameObject ob = Instantiate(_participantFab);
            ob.transform.SetParent(_ListHolder);
            ob.transform.localScale = new Vector3(1.0F, 1.0F, 1.0F);
            ob.GetComponent<UIParticipant>().SetUI(player);
        }
    }

    private void Clean(RectTransform parent)
    {
        foreach (Transform child in parent)
            Destroy(child.gameObject);

    }

}
