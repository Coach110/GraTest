using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{

    private Vector2 direction;
    [SerializeField] private InputController input = null;
    // Start is called before the first frame update
    void Update()
    {
        direction.x = input.RetreiveMoveInput();
        if (direction.x > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
