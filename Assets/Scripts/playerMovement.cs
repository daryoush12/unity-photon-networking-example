using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviourPun
{
    public float velocity = 10f;
    public Vector3 desiredVelocity { get; private set; }

    public bool isPlayerWalking;



    private Camera cam;
    private Rigidbody rb;
    private const string walkingVar = "IsPlayerWalking";
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && PhotonNetwork.IsConnected == true)
        {
            desiredVelocity = GetInput();
        }return;
    }

    private void FixedUpdate()
    {
        var yVel = rb.velocity.y;
        rb.velocity = new Vector3(desiredVelocity.x, yVel, desiredVelocity.z);
        
    }

    private Vector3 GetInput()
    {

        Vector2 inputVect = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        isPlayerWalking = inputVect != Vector2.zero;
        //animator.SetBool(walkingVar,isPlayerWalking);
        var desiredVel = cam.transform.forward;
        desiredVel.y = 0;
        desiredVel = desiredVel * inputVect.y;
        var sideVel = cam.transform.right;
        sideVel.y = 0;
        desiredVel += sideVel.normalized * inputVect.x;
        desiredVel = desiredVel.normalized;
        return desiredVel * velocity;

    }
}
