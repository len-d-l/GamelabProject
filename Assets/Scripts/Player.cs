using Fusion;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : NetworkBehaviour
{
    //private Rigidbody rb;

    //public float moveSpeed;

    //public float groundDrag;

    //public float playerHeight;
    //public LayerMask whatIsGround;
    //bool grounded;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody>();

    //}

    //private void Update()
    //{
    //    // Ground check
    //    grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

    //    SpeedControl();

    //    // Handle drag
    //    if (grounded)
    //        rb.drag = groundDrag;
    //    else
    //        rb.drag = 0;
    //}

    private NetworkCharacterController _cc;

    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            _cc.Move(5 * data.direction * Runner.DeltaTime);
        }
    }

    //private void SpeedControl()
    //{
    //    Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    //    // Limit velocity if needed
    //    if (flatVel.magnitude > moveSpeed)
    //    {
    //        Vector3 limitedVel = flatVel.normalized * moveSpeed;
    //        rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
    //    }
    //}
}
