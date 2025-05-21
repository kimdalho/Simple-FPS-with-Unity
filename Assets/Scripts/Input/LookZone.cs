using UnityEngine;
using UnityEngine.EventSystems;

public class LookZone : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public float sensitivity = 0.1f;
    public Vector2 lookDelta { get; private set; }
    private bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        lookDelta = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        lookDelta = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
            lookDelta = eventData.delta * sensitivity;
    }

    void Update()
    {
        if (!isDragging)
            lookDelta = Vector2.zero;
    }
}