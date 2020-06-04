using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Participant : MonoBehaviourPun
{
   
    public void SetReady()
    {
        Hashtable hash = new Hashtable();
        hash.Add("state", State.Ready);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}