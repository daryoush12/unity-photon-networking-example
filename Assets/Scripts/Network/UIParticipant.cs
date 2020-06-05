using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIParticipant : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Player _player;


    public void SetUI(Player player)
    {
        if (player.CustomProperties.Keys.Count > 0)
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log(player.NickName);
            _player = player;
            _text.text = player.NickName + " - " + ((State)player.CustomProperties["state"]);
        }
        else
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log(player.NickName);
            _player = player;
            _text.text = player.NickName;
        }

    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (targetPlayer == _player)
        {
            _text.text = _player.NickName + " - " +
                ((State)_player.CustomProperties["state"]);
        }
    }

}
