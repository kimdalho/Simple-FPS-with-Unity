using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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

}