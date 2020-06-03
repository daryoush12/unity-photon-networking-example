using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviourPun, IPunObservable
{

    [SerializeField] private Text _username;
    [SerializeField] private Canvas _usernameHolder;
    [SerializeField] private Camera _cam;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(_username);
        }
        else
        {
            // Network player, receive data
            this._username = (Text)stream.ReceiveNext();
        }
    }

    private void Awake()
    {
        if (!photonView.IsMine)
        {
            _username.text = photonView.name;
        }
        else
        {
            _username.text = "";
        }
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        _username.transform.LookAt(_cam.transform.position);
    }
}
