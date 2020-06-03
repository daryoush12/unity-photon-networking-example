using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIParticipant : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetUI()
    {
        if (photonView.IsMine)
            photonView.GetComponentInChildren<TextMeshProUGUI>().text = photonView.Owner.NickName + " - " + 
                ((State)photonView.Owner.CustomProperties["state"]);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (photonView.Owner == targetPlayer)
        {
            photonView.GetComponentInChildren<TextMeshProUGUI>().text = photonView.Owner.NickName + " - " + 
                ((State)photonView.Owner.CustomProperties["state"]);
        }
    }
}
