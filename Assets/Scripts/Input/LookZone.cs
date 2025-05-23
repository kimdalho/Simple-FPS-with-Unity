using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookZone : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 lookDelta { get; private set; }
    public bool IsDragging { get; private set; }
    public float sensitivity = 1f;

    public event System.Action<Vector2> OnLookInput;

    public void OnPointerDown(PointerEventData eventData)
    {
        IsDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsDragging = false;
        lookDelta = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsDragging) return;
        lookDelta = eventData.delta * sensitivity;
        OnLookInput?.Invoke(lookDelta);
    }
}