using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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

}