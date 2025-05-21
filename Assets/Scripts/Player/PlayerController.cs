using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Look ����")]
    public LookZone lookZone;

    [Header("Ÿ�� ������Ʈ")]
    public Transform playerBody;      // �¿� ȸ�� (Y��)
    public Transform cameraPivot;     // ���� ȸ�� (X��)

    [Header("���� / ����")]
    public float verticalClamp = 80f;
    private float cameraPitch = 0f;
    [Header("��Ʈ�ѷ�")]
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

        // Y�� ȸ�� (�¿�): ĳ���� ��ü
        playerBody.Rotate(Vector3.up * delta.x);

        // X�� ȸ�� (����): ī�޶�
        cameraPitch -= delta.y;
        cameraPitch = Mathf.Clamp(cameraPitch, -verticalClamp, verticalClamp);

        cameraPivot.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
    }
}