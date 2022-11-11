using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int maxTimeSecInt = 5;
    Rigidbody2D rigidbody2D;
    float timeRemaining = 5f;
    System.Random rand= new System.Random(1443);
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(-moveSpeed, 0f);
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            timeRemaining = (float)rand.Next(maxTimeSecInt);
        }


    }

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        timeRemaining = (float)rand.Next(maxTimeSecInt);
    }
}
