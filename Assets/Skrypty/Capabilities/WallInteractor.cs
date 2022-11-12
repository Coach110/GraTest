using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInteractor : MonoBehaviour
{
    [SerializeField] private InputController input = null;

    [Header("Wall Slide")]
    [SerializeField]
    [Range(0.1f, 5f)] private float wallSlideMaxSpeed = 2f;

    [Header("Wall Jump")]
    [SerializeField] private Vector2 wallJumpClimb = new Vector2(4f, 12f);
    [SerializeField] private Vector2 wallJumpBounce = new Vector2(10.7f, 10f);

    public bool WallJumping { get; private set; }

    private Ground ground;
    private Rigidbody2D body;

    private Vector2 velocity;
    private bool sciana;
    private bool onGround;
    private bool desiredJump;
    private float wallDirectionX;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(sciana && !onGround)
        {
            desiredJump |= input.RetreiveJumpInput();
        }
    }

    private void FixedUpdate()
    {
        velocity = body.velocity;
        sciana = ground.onWall;
        onGround = ground.onGround;
        wallDirectionX = ground.normal.x;

        //wall Slide
        if (sciana)
        {
            if(velocity.y < -wallSlideMaxSpeed)
            {
                velocity.y = -wallSlideMaxSpeed;
            }
        }

        //Wall Jump
        if((sciana && velocity.x == 0) || onGround)
        {
            WallJumping = false;
        }
        if (desiredJump)
        {
            if(wallDirectionX == input.RetreiveMoveInput())
            {
                velocity = new Vector2(wallJumpClimb.x * wallDirectionX, wallJumpClimb.y);
                WallJumping = true;
                desiredJump = false;
            }
            else if(input.RetreiveMoveInput() == 0)
            {
                velocity = new Vector2(wallJumpBounce.x * wallDirectionX, wallJumpBounce.y);
                WallJumping = true;
                desiredJump = false;
            }
        }


        body.velocity = velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       ground.EvaluateCollision(collision);

        if(ground.onWall && ground.onGround && WallJumping)
        {
            body.velocity = Vector2.zero;
        }
    }
}
