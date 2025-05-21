using UnityEngine;
using UnityEngine.EventSystems;

public class MinimalJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    private Vector2 input;
    public float radius = 100f;

    public Vector2 Direction => input;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos);

        pos = Vector2.ClampMagnitude(pos, radius);
        handle.anchoredPosition = pos;
        input = pos / radius;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
        input = Vector2.zero;
    }
}