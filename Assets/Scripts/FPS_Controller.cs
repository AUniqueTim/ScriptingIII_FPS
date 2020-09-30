using System.Collections;
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
    public bool grounded;

    Quaternion originalRotation;
    public Transform playerTransform;



    private void Awake()
    {
        jumpAllowed = true;

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerManager.playerSpeed = PlayerManager.runSpeed;
        }
       
    }
    private void FixedUpdate()
    {

        

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
        jumpAllowed = true;
        if (Input.GetKeyDown(KeyCode.Space) && jumpAllowed) { { Jump(); } }

        
        if (grounded = false && Time.time > Time.time + 1.5)
            {
                CancelJump();
            }

    }


    public void Jump()
    {
        playerRB.transform.position += Vector3.up * PlayerManager.jumpHeight * PlayerManager.instance.jumpSpeed  * -gravity * Time.deltaTime;
        isJumping = true;
        if (isJumping) { jumpAllowed = false; }
        
        Debug.Log("Jumped.");
            

    }
    public void CancelJump()
    {
        playerRB.transform.position += Vector3.down * PlayerManager.jumpHeight * PlayerManager.instance.fallSpeed * gravity * Time.deltaTime;
        isJumping = false;
        
        Debug.Log("Jump cancelled");
        
    }
    public void OnTriggerEnter(Collider other)
    {
        grounded = true;
        
    }




}
