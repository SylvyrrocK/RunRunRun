using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

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

    [Header("Ground Check")]
    public float playerHeight = 1f;
    public LayerMask isGround;
    bool grounded;

    public Transform orientation;
    Vector3 moveDirection;
    Rigidbody rb;

    float horizontalInput;
    float verticalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isReadyToJump = true;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();
        
        //Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.05f, isGround);

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

        if(Input.GetKey(jumpKey) && isReadyToJump && grounded)
        {
            isReadyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MoverPlayer()
    {
        moveDirection = orientation.forward * verticalInput+ orientation.right * horizontalInput;

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * playerSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * playerSpeed * 10f * airMultiplayer, ForceMode.Force);
        }

        //if(Input.GetKey(KeyCode.D))
        //{
        //    rb.velocity = transform.right * playerSpeed * 5f * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.velocity = -transform.right * playerSpeed * 5f * Time.deltaTime;
        //}

        //if(Input.GetKey(KeyCode.Space))
        //{
        //    rb.velocity = transform.up * jumpHeight * 10f * Time.deltaTime;
        //}
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