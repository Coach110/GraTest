using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cel;
    public Vector3 offsetKamery;
    private Vector3 pozycjaCelu;
    private Vector3 smoothCel;

    [Range(1f, 10f)]
    public float smoothness;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        pozycjaCelu = cel.position + offsetKamery;
        smoothCel = Vector3.Lerp(transform.position, pozycjaCelu, smoothness * Time.fixedDeltaTime);
        transform.position = smoothCel;
    }
}
