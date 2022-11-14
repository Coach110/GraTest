using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float DashForce = 20f;
    [SerializeField, Range(0, 5)] private int maxDashes = 0;
    [SerializeField, Range(0f, 5f)] private float DashCooldown = 2f;
    //[SerializeField] private TrailRenderer tr;

    private Rigidbody2D body;
    private float direction;
    private float dashTime;
    private bool isDashing;
    public Vector2 velocity;
    private bool canDash = true;
    private bool WantsDash;
    float ogGravity;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (isDashing)
        {
            return;
        }

        WantsDash |= input.RetreiveJumpInput();
    }

    private void FixedUpdate()
    {

        if (canDash && WantsDash)
        {
            StartCoroutine(Dashing());
        }
    }

    private IEnumerator Dashing()
    {
        isDashing = true;
        canDash = false;
        ogGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(body.velocity.x, 0f);
        direction = (int)direction;
        body.AddForce(new Vector2(DashForce * direction,0f),ForceMode2D.Impulse);
        //tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        //tr.emitting = false;
        body.gravityScale = ogGravity;
        isDashing = false;
        yield return new WaitForSeconds(DashCooldown);
        canDash = true;
    }
}
