using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviourPun
{

    [SerializeField] private TextMeshProUGUI _username;
    [SerializeField] private Canvas _usernameHolder;
    [SerializeField] private Camera _cam;

    /*
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(_username.text);
        }
        else
        {
            // Network player, receive data
            _username.text = (string)stream.ReceiveNext();
        }
    }
    */
    private void Awake()
    {
     
    }

    private void Start()
    {
        _cam = Camera.main;
        if (!photonView.IsMine)
        {
            Debug.Log(photonView.Owner.UserId);
            _usernameHolder = photonView.GetComponentInChildren<Canvas>();
            _username.text = photonView.Owner.NickName;
           
        }
        else
        {
            _username.text = "";
        }

    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            _usernameHolder.transform.LookAt(_cam.transform.position);
            _usernameHolder.transform.rotation = Quaternion.LookRotation(_usernameHolder.transform.position - _cam.transform.position);
        }
    }
}
