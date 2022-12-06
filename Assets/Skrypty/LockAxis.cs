using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that locks the camera's Z co-ordinate
/// </summary>
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class LockCamera : CinemachineExtension
{

    public static bool blockX = false;
    public static float wartoscX = 0.0f;
    public static bool blockY = false;
    public static float wartoscY = 0.0f;
    public static bool blockZ = false;
    public static float wartoscZ = 0.0f;


    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (blockX)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.x = wartoscX;
                state.RawPosition = pos;
            }
        }
        else if (blockY)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.y = wartoscY;
                state.RawPosition = pos;
            }
        }
        else if (blockZ)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.z = wartoscZ;
                state.RawPosition = pos;
            }
        }
    
    }
}

