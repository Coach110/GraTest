using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControlls", menuName = "InputController/PlayerControlls")]
public class PlayerControlls : InputController
{
    public override bool RetreiveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float RetreiveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}
