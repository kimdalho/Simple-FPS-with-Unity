using Unity.Cinemachine;
using UnityEngine;
/// <summary>
/// OrbitalCameraController,LookZone�� ��ǥ��(P)�� ���� ����
/// </summary>
public class LookInputBinder : MonoBehaviour
{
    public LookZone lookZone;
    public CinemachineOrbitalFollow orbitalFollow;
    /// <summary>
    /// Start���� �� �ѹ��� �����ȴ�.
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