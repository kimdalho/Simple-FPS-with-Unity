
using UnityEngine;
using UnityEngine.InputSystem;


public class MobileInputController : MonoBehaviour , IInputEventProvider
{
    [Header("InputActionAsset (����׿�)")]
    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction lookAction;

    [Header("���̽�ƽ")]
    public MinimalJoystick moveJoystick;

    [Header("�Է� ����")]
    public Vector2 moveInput;
    public Vector2 lookInput;
    public bool isShooting;
    public bool isAiming;
    public bool isSprinting;

    void Awake()
    {
        moveAction = inputActions.FindAction(GlobalInputAction.PlayerMove);
        lookAction = inputActions.FindAction(GlobalInputAction.PlayerLook);

        moveAction.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => moveInput = Vector2.zero;

        lookAction.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        lookAction.canceled += ctx => lookInput = Vector2.zero;
    }

    void OnEnable() => inputActions.Enable();
    void OnDisable() => inputActions.Disable();

    void Update()
    {        
        moveInput = moveJoystick.Direction;
    }


    // UI ��ư ����
    public void OnJumpButton() => Debug.Log("Jump");
    public void OnFireDown() => isShooting = true;
    public void OnFireUp() => isShooting = false;
    public void OnAimDown() => isAiming = true;
    public void OnAimUp() => isAiming = false;
    public void OnSprintDown() => isSprinting = true;
    public void OnSprintUp() => isSprinting = false;
    public void OnReloadButton() => Debug.Log("Reload");
    public void OnMeleeButton() => Debug.Log("Melee");

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }

    public Vector2 GetLookInput()
    {
        return lookInput;  
    }
}