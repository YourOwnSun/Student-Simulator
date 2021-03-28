using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Vector2 offset;
    public Canvas parentCanvasOfImageToMove;

    public void OnBeginDrag(PointerEventData eventData) 
    {
        offset = new Vector2(transform.position.x - eventData.position.x, transform.position.y - eventData.position.y);
    }

    public void OnDrag(PointerEventData data)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, data.position, parentCanvasOfImageToMove.worldCamera, out pos);
        transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos);
    }

    public void OnEndDrag(PointerEventData eventData) 
    {

    }
}
