using Unity.Cinemachine;
using UnityEngine;
/// <summary>
/// CinemachineOrbital 카메라 제어
/// </summary>
public class OrbitalCameraController
{
    private CinemachineOrbitalFollow orbitalFollow;
    private float hSensitivity, vSensitivity;

    public OrbitalCameraController(CinemachineOrbitalFollow follow, float hSens, float vSens)
    {
        orbitalFollow = follow;
        hSensitivity = hSens;
        vSensitivity = vSens;
    }

    public void ApplyLookDelta(Vector2 delta)
    {
        orbitalFollow.HorizontalAxis.Value += delta.x * hSensitivity;
        orbitalFollow.VerticalAxis.Value -= delta.y * vSensitivity;
    }
}