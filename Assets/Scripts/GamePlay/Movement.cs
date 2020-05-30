using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviourPun
{
    [SerializeField] private float _movementSpeed = 3F;
    [SerializeField] private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor control should be moved if this project is continued:
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && PhotonNetwork.IsConnected == true)
        {
            // float xInput = Input.GetAxis("Vertical");
            float xInput = Input.GetAxis("Vertical");
            _rb.AddForce(transform.forward * (_movementSpeed * xInput));

        }return;
    }
}
