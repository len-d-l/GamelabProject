using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using Fusion;
//using Fusion.Addons.Physics;

public class PlayerMovement : MonoBehaviour /*NetworkBehaviour*/
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    [Header("References")]
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    private Rigidbody rb;

    private bool isAudioPlaying;

    public bool dashing;

    public Animator animBee;
    public Animator animBeetle;
    public Animator animAnt;

    private Animator currentAnimator;

    //private NetworkRigidbody3D nrb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //nrb = GetComponent<NetworkRigidbody3D>();
        rb.freezeRotation = true;

        // Determine which animator to use based on the character
        if (gameObject.name == "PlayerA(Clone)")
        {
            currentAnimator = animBee;
        }
        else if (gameObject.name == "PlayerB(Clone)")
        {
            currentAnimator = animBeetle;
        }
        else if (gameObject.name == "PlayerC(Clone)")
        {
            currentAnimator = animAnt;
        }
    }

    private void Update()
    {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInputs();
        SpeedControl();

        // Handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        HandleAudio();
        HandleAnimation();
    }

    private void FixedUpdate()
    {
        if (!dashing)
        {
            MovePlayer();
        }
    }

    //public override void FixedUpdateNetwork()
    //{
    //    if (GetInput(out NetworkInputData data))
    //    {
    //        data.direction.Normalize();
    //        nrb.ResetRigidbody();
    //    }

    //    if (HasInputAuthority)
    //    {
    //        MovePlayer();

    //        // Ground check
    //        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

    //        MyInputs();
    //        SpeedControl();

    //        // Handle drag
    //        if (grounded)
    //            rb.drag = groundDrag;
    //        else
    //            rb.drag = 0;
    //    }

    //}

    private void MyInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void HandleAudio()
    {
        bool isMoving = moveDirection.magnitude > 0.1f;
        string soundToPlay = "";

        if (gameObject.name == "PlayerA(Clone)")
        {
            soundToPlay = "BeeWalk";
        }
        else if (gameObject.name == "PlayerB(Clone)")
        {
            soundToPlay = "BeetleWalk";
        }
        else if (gameObject.name == "PlayerC(Clone)")
        {
            soundToPlay = "AntWalk";
        }

        if (isMoving && !isAudioPlaying && !string.IsNullOrEmpty(soundToPlay))
        {
            FindObjectOfType<AudioManager>().PlayAudio(soundToPlay);
            isAudioPlaying = true;
        }
        else if (!isMoving && isAudioPlaying)
        {
            FindObjectOfType<AudioManager>().StopAudio(soundToPlay);
            isAudioPlaying = false;
        }
    }

    private void HandleAnimation()
    {
        bool isMoving = moveDirection.magnitude > 0.1f;

        if (currentAnimator != null)
        {
            if (isMoving)
            {
                currentAnimator.SetBool("isWalking", true);
            }
            else
            {
                currentAnimator.SetBool("isWalking", false);
            }
        }
    }
}