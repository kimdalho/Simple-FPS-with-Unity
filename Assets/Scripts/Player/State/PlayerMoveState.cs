using UnityEngine;

public class PlayerMoveState : State
{
    private readonly PlayerStateMachine player;
    private float turnVelocity;

    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        player = stateMachine;
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Tick(float deltaTime)
    {
        
        Vector2 input = player.inputController.GetMoveInput();
        Vector3 moveDir = new Vector3(input.x, 0, input.y).normalized;

        if (moveDir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + player.cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y, targetAngle, ref turnVelocity, 0.1f);

            player.transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 move = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            player.controller.Move(move * player.moveSpeed * deltaTime);
            player.animatorController.animator?.SetFloat("Speed", moveDir.magnitude);
        }
        else
        {
            player.animatorController.animator?.SetFloat("Speed", 0f);
        }
    }
}
