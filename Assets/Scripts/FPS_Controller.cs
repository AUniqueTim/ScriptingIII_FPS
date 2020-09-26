﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRB;
    private float gravity = -9.87f;

    private bool moveRight;
    private bool moveLeft;
    private bool moveUp;
    private bool moveDown;

    public bool jumpAllowed;
    public bool isJumping;
    public bool jumpComplete;

    public float xRotation = 0;
    public float xRotationSpeed;
    public float yRotation = 0;
    public float yRotationSpeed;
    Quaternion originalRotation;
    public Transform playerTransform;



    private void Awake()
    {
        jumpAllowed = true;

    }
    private void Update()
    {
        
        //playerRB.rotation = transform.rotation;
    }
    private void FixedUpdate()
    {

        //transform.LookAt(playerTransform);

        //Player Rigidbody movement.

        if (Input.GetAxisRaw("Horizontal") > 0) { transform.Translate(Vector3.right * PlayerManager.playerSpeed * Time.deltaTime ) ; moveRight = true; }
        if (Input.GetAxisRaw("Horizontal") < 0) { transform.Translate(Vector3.left * PlayerManager.playerSpeed * Time.deltaTime); moveLeft = true; }
        if (Input.GetAxisRaw("Vertical") > 0) { transform.Translate(Vector3.up * PlayerManager.playerSpeed * Time.deltaTime); moveUp = true; }
        if (Input.GetAxisRaw("Vertical") < 0) { transform.Translate(Vector3.down * PlayerManager.playerSpeed * Time.deltaTime); moveDown = true; }
        if (Input.GetKey(KeyCode.W)) { transform.Translate(Vector3.forward * PlayerManager.playerSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(Vector3.back * PlayerManager.playerSpeed * Time.deltaTime); }

        //Crouch

        if (Input.GetKey(KeyCode.LeftControl)) {/*disable standing collider and enable crouch collider*/playerRB.transform.position += Vector3.down * PlayerManager.crouchHeight * Time.deltaTime; }

        //Jump

        if (Input.GetKeyDown(KeyCode.Space) && jumpAllowed) { { Jump(); } }

        //Rotation
        //if (moveRight) { { RotateRight(); } }
        //if (moveLeft) { { RotateLeft(); } }
        
    }
    //public void RotateRight()
    //{
    //    if (Input.GetAxis("Rotate Right") > 0) { xRotation++; }
    //    else if (Input.GetAxis("Rotate Left") < 0) { xRotation--; }
    //    playerTransform.Rotate(Vector3.up, xRotation * xRotationSpeed);
    //    Debug.Log("Rotating Right.");

    //}
    //public void RotateLeft()
    //{
    //    if (Input.GetAxis("Horizontal") < 0) { xRotation++; }
    //    else if (Input.GetAxis("Horizontal") > 0) { xRotation--; }
    //    playerTransform.Rotate(-Vector3.up, xRotation * xRotationSpeed);
    //    Debug.Log("Rotating Left.");
    //}

    public void Jump()
    {
        playerRB.transform.position += Vector3.up * PlayerManager.jumpHeight * Time.deltaTime;
        isJumping = true;
        if (isJumping) { jumpAllowed = false; }
            
            CancelJump();

    }
    public void CancelJump()
    {
        playerRB.transform.position += Vector3.down * PlayerManager.jumpHeight * PlayerManager.fallSpeed * gravity * Time.deltaTime;
        isJumping = false;
        jumpAllowed = true;
    }

    


}