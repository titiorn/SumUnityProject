using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragText : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [System.Serializable]
    public class DraggableText
    {
        public TextMeshProUGUI textObj; //Text to be dragged
        [HideInInspector] public RectTransform rectTransform;
        [HideInInspector] public CanvasGroup canvasGroup;
    }
  
    public List<DraggableText> draggableTexts; //List of draggable texts
    private Canvas canvas;
    private DraggableText currentDraggableText;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();

        //cache RectTransform and CanvasGroup for each draggable text
        foreach(var draggable in draggableTexts)
        {
            draggable.rectTransform = draggable.textObj.GetComponent<RectTransform>();
            draggable.canvasGroup = draggable.textObj.gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentDraggableText = GetDraggableTextUnderPointer(eventData);
        if(currentDraggableText != null)
        {
            currentDraggableText.canvasGroup.alpha = 0.6f; //Control the visibility of text while dragging
            currentDraggableText.canvasGroup.blocksRaycasts = false; //Allow text to be dragged through other UI elements
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if(currentDraggableText != null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPoint);
            currentDraggableText.rectTransform.localPosition = localPoint;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(currentDraggableText != null)
        {
            currentDraggableText.canvasGroup.alpha = 1f;
            currentDraggableText.canvasGroup.blocksRaycasts = true;

            currentDraggableText = null;

        }
    }

    private DraggableText GetDraggableTextUnderPointer(PointerEventData eventData)
    {
        foreach(var draggable in draggableTexts)
        {
            if(RectTransformUtility.RectangleContainsScreenPoint(draggable.rectTransform,eventData.position, canvas.worldCamera))
            {
                return draggable;
            }
        }
        return null;
    }
}

