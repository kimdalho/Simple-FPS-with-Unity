using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// �Է� �ý����� �޴� Ŭ������ ���� Ÿ���� �ǹ�
/// </summary>
public interface IInputEventProvider
{


    public Vector2 GetMoveInput();

    public Vector2 GetLookInput();

    public void OnJumpButton();
    public void OnFireDown();
    public void OnFireUp();
    public void OnAimDown();
    public void OnAimUp();
    public void OnSprintDown();
    public void OnSprintUp();
    public void OnReloadButton();
    public void OnMeleeButton();
}