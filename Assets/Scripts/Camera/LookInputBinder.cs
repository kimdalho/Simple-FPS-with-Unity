using Unity.Cinemachine;
using UnityEngine;
/// <summary>
/// OrbitalCameraController,LookZone의 발표자(P)와 같은 역할
/// </summary>
public class LookInputBinder : MonoBehaviour
{
    public LookZone lookZone;
    public CinemachineOrbitalFollow orbitalFollow;
    /// <summary>
    /// Start에서 단 한번만 참조된다.
    /// </summary>
    public float hSensitivity = 0.1f;
    public float vSensitivity = 0.05f;

    private OrbitalCameraController camController;

    void Start()
    {
        camController = new OrbitalCameraController(orbitalFollow, hSensitivity, vSensitivity);
        lookZone.OnLookInput += camController.ApplyLookDelta;
    }
}