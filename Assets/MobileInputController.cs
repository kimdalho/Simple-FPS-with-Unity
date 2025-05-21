using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MobileInputController : MonoBehaviour , IInputEventProvider
{
    [Header("UI References")]
    public RectTransform joystickBG;
    public RectTransform joystickHandle;

    private bool isDragging = false;

    [Header("Raycast Settings")]
    public GraphicRaycaster uiRaycaster;
    public EventSystem eventSystem;

    [Header("Raycast")]
    public Camera mainCamera;

    public Vector2 moveInputDirection => inputVector;
    protected Vector2 inputVector;
    public Vector2 lookInputDirection => inputVector2;
    protected Vector2 inputVector2;
    public InputAction pointerAction { get; set; }

    private void OnEnable()
    {
        pointerAction.Enable();
    }

    private void OnDisable()
    {
        pointerAction.Disable();
    }

    private void Update()
    {
        if (Touchscreen.current != null)
        {
            isDragging = Touchscreen.current.primaryTouch.press.isPressed;
        }
        else
        {
            isDragging = Mouse.current.leftButton.isPressed;
        }

        Vector2 screenPos = pointerAction.ReadValue<Vector2>();

        if (isDragging)
        {
            if (IsPointerOverJoystick(screenPos))
            {
                UpdateJoystick(screenPos);
            }
            else
            {
                ResetJoystick();
            }
        }
        else
        {
            ResetJoystick();
        }
    }

    void UpdateJoystick(Vector2 screenPosition)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBG, screenPosition, null, out localPoint))
        {
            Vector2 normalized = new Vector2(
                (localPoint.x / joystickBG.sizeDelta.x) * 2,
                (localPoint.y / joystickBG.sizeDelta.y) * 2);

            inputVector = normalized.magnitude > 1 ? normalized.normalized : normalized;


            joystickHandle.anchoredPosition = new Vector2(
                inputVector.x * joystickBG.sizeDelta.x / 2,
                inputVector.y * joystickBG.sizeDelta.y / 2);
        }
    }

    void ResetJoystick()
    {
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    bool IsPointerOverJoystick(Vector2 screenPosition)
    {
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = screenPosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        uiRaycaster.Raycast(pointerData, results);

        foreach (var result in results)
        {
            if (result.gameObject == joystickBG.gameObject || result.gameObject.transform.IsChildOf(joystickBG))
                return true;
        }
        return false;
    }
}