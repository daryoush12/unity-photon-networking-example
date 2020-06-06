using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerStateManager : MonoBehaviourPun
{
    public void SetReady()
    {
        Hashtable hash = new Hashtable();
        hash.Add("state", State.Ready);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public void SetUnready()
    {
        Hashtable hash = new Hashtable();
        hash.Add("state", State.Unprepared);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

}


