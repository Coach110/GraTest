using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 20f)] private float jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 1.7f;
    [SerializeField, Range(0f, 3f)] private float ledgeJump = 0.2f;
    [SerializeField, Range(0f, 3f)] private float jumpBufferTime = 0.2f;

    private Rigidbody2D body;
    private Ground ground;
    private Vector2 velocity;

    private int jumpPhase;
    private float defaultGravityScale;
    private float jumpSpeed;
    private float ledgeJumpCounter;
    private float jumpBufferCounter;

    private bool desiredJump;
    private bool onGround;
    private bool isJumping;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();

        defaultGravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= input.RetreiveJumpInput();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        if (onGround && body.velocity.y == 0)
        {
            jumpPhase = 0;
            ledgeJumpCounter = ledgeJump;
            isJumping = false;
        }
        else
        {
            ledgeJumpCounter -= Time.deltaTime;
        }

        if (desiredJump)
        {
            desiredJump = false;
            jumpBufferCounter = jumpBufferTime;
        }
        else if(!desiredJump && jumpBufferCounter > 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if(jumpBufferCounter > 0)
        {
            JumpAction();
        }

        if(input.RetreiveJumpHoldInput() && body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if (!input.RetreiveJumpHoldInput() || body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }
        else if (body.velocity.y == 0)
        {
            body.gravityScale = defaultGravityScale;
        }

        body.velocity = velocity;
    }

    private void JumpAction()
    {
        if(ledgeJumpCounter > 0f || (jumpPhase < maxAirJumps && isJumping))
        {
            if (isJumping)
            {
                jumpPhase += 1;
            }

            jumpBufferCounter = 0f;
            ledgeJumpCounter = 0f;
            jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            isJumping=true;

            if(velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f) ;
            }
            velocity.y +=jumpSpeed;
        }
        //Debug.Log("Jump!");

    }
}
