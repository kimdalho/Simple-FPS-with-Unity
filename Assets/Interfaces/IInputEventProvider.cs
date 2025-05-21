using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 입력 시스템을 받는 클래스의 공급 타입을 의미
/// </summary>
public interface IInputEventProvider
{
    //인풋액션    
    InputAction pointerAction { get; set; }
    public Vector2 moveInputDirection { get; }
    public Vector2 lookInputDirection { get; }
}