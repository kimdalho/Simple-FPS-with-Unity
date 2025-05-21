using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// �Է� �ý����� �޴� Ŭ������ ���� Ÿ���� �ǹ�
/// </summary>
public interface IInputEventProvider
{
    //��ǲ�׼�    
    InputAction pointerAction { get; set; }
    public Vector2 moveInputDirection { get; }
    public Vector2 lookInputDirection { get; }
}