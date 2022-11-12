using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool onGround;
    public float friction;
    public bool onWall;

    private PhysicsMaterial2D material;
    public Vector2 normal { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        friction = 0.0f;
        onWall = false;
    }

    public void EvaluateCollision(Collision2D collision)
    {
        for(int i=0 ; i < collision.contactCount; i++)
        {
            normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
            onWall = Mathf.Abs(normal.x) >= 0.9f;
        }
    }

    private void RetrieveFriction(Collision2D collision)
    {
        material = collision.rigidbody.sharedMaterial;

        friction = 0;
        
        if(material != null)
        {
            friction = material.friction;
        }
    }


    public bool GetOnGround()
    {
        return onGround;
    }

    public float GetFriction()
    {
        return friction;
    }

}
