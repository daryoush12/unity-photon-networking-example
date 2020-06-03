using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject _playerPrefab = null;

    [SerializeField] private Transform spawnpoint = null;

    private void Start()
    {
        if(_playerPrefab == null)
        {
            Debug.LogError("Missing player prefab!");
        }
        else
        {
            
            PhotonNetwork.Instantiate(_playerPrefab.name, spawnpoint.position * 2, Quaternion.identity, 0);

        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        PhotonNetwork.LoadLevel("Room");
    }

  

}
