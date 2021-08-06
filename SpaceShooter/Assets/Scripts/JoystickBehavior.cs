using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickBehavior : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float DeltaXDrag
    {
        get
        {
            var temp = deltaXDrag;
            deltaXDrag = 0.0f;
            return temp;
        }
    }
    private float deltaXDrag;
    private Vector2 beginDragPosition;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        deltaXDrag = eventData.position.x - beginDragPosition.x;
        beginDragPosition = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginDragPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        deltaXDrag = 0.0f;
    }
}
