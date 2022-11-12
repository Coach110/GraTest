using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController", menuName = "InputController/PlayerController")]
public class PlayerController : InputController
{
    public override bool RetreiveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float RetreiveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override bool RetreiveJumpHoldInput()
    {
        return Input.GetButton("Jump");
    }
}
