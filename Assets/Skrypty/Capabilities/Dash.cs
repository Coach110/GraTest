using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float DashForce = 20f;
    [SerializeField, Range(0, 5)] private int maxDashes = 0;
    [SerializeField, Range(0f, 5f)] private float DashCooldown = 1f;
    //[SerializeField] private TrailRenderer tr;

    private Rigidbody2D body;
    private float inputX;

    private float dashTime= 0.2f;
    private float startDashTime;

    private bool isDashing;
    public Vector2 velocity;
    private Vector2 direction;
    private bool canDash = true;
    private bool WantsDash;
    float ogGravity;
    private int kierunek;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {

        inputX = Input.GetAxis("Horizontal");
        //Debug.Log(inputX);
        if (inputX > 0f)
        {
            kierunek = 1;
        }
        if (inputX < 0)
        {
            kierunek = -1;
        }


        WantsDash = input.RetreiveDashInput();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        if (canDash && WantsDash && !isDashing)
        {
            StartCoroutine(Dashing());
        }
    }

    //private void KierunekDasha()
    //{
    //    direction.x = input.RetreiveMoveInput();
    //    if (direction.x > 0f)
    //    {
    //        kierunek = 1;
    //    }
    //    if (direction.x < 0)
    //    {
    //        kierunek = -1;
    //    }
    //}

    private IEnumerator Dashing()
    {
        canDash = false;
        isDashing = true;
        ogGravity = body.gravityScale;
        body.gravityScale = 0f;
        //body.velocity = new Vector2(body.velocity.x, 0f);
        //inputX = (int)inputX;
        //body.AddForce(new Vector2(DashForce * inputX,0f),ForceMode2D.Impulse);
        inputX = (int)inputX;
        body.velocity = new Vector2(transform.localScale.x * DashForce * kierunek, 0f);
        //tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        //tr.emitting = false;
        body.gravityScale = ogGravity;
        isDashing = false;
        yield return new WaitForSeconds(DashCooldown);
        
        canDash = true;
        Debug.Log("dash");
    }
}
