using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private bool isWallHugging;
    float moveHorizontal;
    float moveVertical;
    float jumpTimeCounter;
    float jumpTime;


    public Rigidbody2D Rigidbody { get; set; }
    public float MoveSpeed { get; set; }
    public bool IsJumping { get; set; }
    public bool IsWallHugging { get; set; }
    public float JumpForce { get; set; }
    public float MoveHorizontal { get; set; }
    public float MoveVertical { get; set; }
    public float JumpTimeCounter { get; set; }
    public float JumpTime { get; set; }




    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        MoveSpeed = 3f;
        JumpForce = 60f;
        IsJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal = Input.GetAxisRaw("Horizontal");
        MoveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (MoveHorizontal > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (MoveHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (MoveHorizontal > 0.1f || MoveHorizontal < 0.1f)
        {
            Rigidbody.AddForce(new Vector2(MoveHorizontal * MoveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!IsJumping && MoveVertical > 0.1f)
        {
            Rigidbody.AddForce(new Vector2(0f, MoveVertical * JumpForce), ForceMode2D.Impulse);
        }

        //if (!IsWallHugging && MoveVertical > 0.1f)
        //{
        //    Rigidbody.AddForce(new Vector2(0f, MoveVertical * JumpForce - 30f), ForceMode2D.Impulse);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Wall")
        {
            IsJumping = false;
        }

        if (collision.gameObject.tag == "Wall")
        {
            IsWallHugging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Wall")
        {
            IsJumping = true;
        }

        if (collision.gameObject.tag == "Wall" )
        {
            IsWallHugging = false;
        }
    }
}
