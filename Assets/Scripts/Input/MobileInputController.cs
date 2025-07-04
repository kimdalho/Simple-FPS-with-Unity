
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;


public class MobileInputController : MonoBehaviour , IInputEventProvider
{
    [Header("InputActionAsset (디버그용)")]
    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction lookAction;

    [Header("조이스틱")]
    public MinimalJoystick moveJoystick;

    [Header("입력 상태")]
    public Vector2 moveInput;
    public Vector2 lookInput;
    public bool isShooting;
    public bool isAiming;
    public bool isSprinting;

    void Awake()
    {
        moveAction = inputActions.FindAction("Player/Move");
        lookAction = inputActions.FindAction("Player/Look");

        moveAction.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => moveInput = Vector2.zero;

        lookAction.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        lookAction.canceled += ctx => lookInput = Vector2.zero;
    }

    void OnEnable() => inputActions.Enable();
    void OnDisable() => inputActions.Disable();

    void Update()
    {
        //테스트용
        //moveInput = moveJoystick.Direction;
    }


    // UI 버튼 연결
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