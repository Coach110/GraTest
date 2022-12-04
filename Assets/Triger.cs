using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    private GameObject camera;
    [SerializeField] private bool blockX = false;
    [SerializeField] private float wartoscX = 0.0f;
    [SerializeField] private bool blockY = false;
    [SerializeField] private float wartoscY = 0.0f;
    [SerializeField] private bool blockZ = false;
    [SerializeField] private float wartoscZ = 0.0f;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (blockX)
            {
                LockCamera.blockX = true;
                LockCamera.wartoscX = wartoscX;
            }
            else if (blockY)
            {
                LockCamera.blockY = true;
                LockCamera.wartoscY = wartoscY;
            }
            else if (blockZ)
            {
                LockCamera.blockZ = true;
                LockCamera.wartoscZ = wartoscZ;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
             LockCamera.blockX = false;
             LockCamera.blockY = false;
             LockCamera.blockZ = false;

        }
    }
}
