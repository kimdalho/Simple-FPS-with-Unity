using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 입력 시스템을 받는 클래스의 공급 타입을 의미
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