using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "InputController/AIController")]

public class AIController : InputController
{
    public override bool RetreiveJumpInput()
    {
        return true;
    }

    public override float RetreiveMoveInput()
    {
        return 1f;
    }

    public override bool RetreiveJumpHoldInput()
    {
        return false;
    }
}
