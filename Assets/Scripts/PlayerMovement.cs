using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    // Update is called once per frame
    public float playerSpeed = 7f;

    public float jumpHeight = 4f;
    public float jumpCooldown = 0.25f;
    public float airMultiplayer = 0.4f;
    bool isReadyToJump = true;

    public float groundDrag = 5f;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.W;

    [Header("Ground Check")]
    public float playerHeight = 1f;
    public LayerMask isGround;
    bool grounded;

    public Transform orientation;
    Vector3 moveDirection;
    Rigidbody rb;

    float horizontalInput;
    float verticalInput;

    //public float worldSpeed = -2f;

    //public float coinSpin;
    //public float platformMovement;

    private void Start()
    {
        //coinSpin = GetComponent<CoinSpin>().coinSpeed;
        //platformMovement = GetComponent<PlatformMovement>().levelSpeed;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isReadyToJump = true;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();
        
        //Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, isGround);

        //Drag handler
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MoverPlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(runKey))
        {
            Time.timeScale = 2f;
        }

        if (Input.GetKeyUp(runKey))
        {
            Time.timeScale = 1f;
        }

        //Possible sprint chunk ?
        //if(Input.GetKey(runKey) && isReadyToJump && grounded)
        //{
        //    platformMovement += 0.2f;
        //    coinSpin += 0.2f;
        //}

        if (Input.GetKey(jumpKey) && isReadyToJump && grounded)
        {
            isReadyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MoverPlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * playerSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * playerSpeed * 10f * airMultiplayer, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);  
        
        if(flatVel.magnitude > playerSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * playerSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        isReadyToJump = false;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        isReadyToJump = true;
    }
}
