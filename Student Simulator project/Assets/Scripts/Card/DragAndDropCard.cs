using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragAndDropCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool dragOnSurfaces = true;
    public Vector3 startingPosition;
    
    private RectTransform m_DraggingPlane;
    private CanvasGroup canvasGroup;
    private GameObject boardPanel;
    private Card card;
    private CardSlot parentSlot;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        boardPanel = GameObject.Find("BoardPanel");
        card = GetComponent<CardDisplay>().card;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        // We have clicked something that can be dragged.
        if(transform.parent.name != "BoardPanel") 
        {      
            parentSlot = transform.parent.GetComponent<CardSlot>();
            parentSlot.CardDragged();
        }

        eventData.pointerDrag.transform.SetParent(boardPanel.transform);

        canvasGroup.blocksRaycasts = false;

        if (dragOnSurfaces)
            m_DraggingPlane = transform as RectTransform;
        else
            m_DraggingPlane = canvas.transform as RectTransform;

        startingPosition = transform.position;

        SetDraggedPosition(eventData);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData data)
    {
        SetDraggedPosition(data);
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlane.rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        transform.SetAsFirstSibling();
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
}