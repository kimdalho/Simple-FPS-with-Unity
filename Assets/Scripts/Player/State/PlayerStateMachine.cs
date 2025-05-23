using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : StateMachine
{
    public float speed;
    public float moveSpeed;

    [HideInInspector] public CharacterController controller;
    public AnimController animatorController;
    public MobileInputController inputController;
    public Transform cameraTransform;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();        
        inputController = GetComponent<MobileInputController>();
        SwitchState(new PlayerMoveState(this));
    }
}