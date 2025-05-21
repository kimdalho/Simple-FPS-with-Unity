using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Look 연동")]
    public LookZone lookZone;

    [Header("타겟 오브젝트")]
    public Transform playerBody;      // 좌우 회전 (Y축)
    public Transform cameraPivot;     // 상하 회전 (X축)

    [Header("감도 / 제한")]
    public float verticalClamp = 80f;
    private float cameraPitch = 0f;
    [Header("컨트롤러")]
    private IInputEventProvider inputEventProvider;
    [SerializeField]
    private MonoBehaviour _inputEventProvider;

    private void Awake()
    {
        inputEventProvider = _inputEventProvider.GetComponent<IInputEventProvider>();
    }



    void Update()
    {
        Vector2 delta = lookZone.lookDelta;

        // Y축 회전 (좌우): 캐릭터 전체
        playerBody.Rotate(Vector3.up * delta.x);

        // X축 회전 (상하): 카메라만
        cameraPitch -= delta.y;
        cameraPitch = Mathf.Clamp(cameraPitch, -verticalClamp, verticalClamp);

        cameraPivot.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
    }
}