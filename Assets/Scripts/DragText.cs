using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragText : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum TextType
    {
        LMandi,
        RMandi,
        LMedRetro,
        RMedRetro,
        LSupCer,
        RSupCer,
    }


    [System.Serializable]
    public class DraggableText
    {
        public RectTransform textObj; //Text to be dragged
        //public RectTransform finalPos;
        [HideInInspector] public CanvasGroup canvasGroup;
    }
  
    public List<DraggableText> draggableTexts; //List of draggable texts
    private Canvas canvas;
    private DraggableText currentDraggableText;

    //public Button submitButton;
    //public GameObject hoorayPopup;
    //public GameObject sadPopup;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();

        //cache RectTransform and CanvasGroup for each draggable text
        foreach(var draggable in draggableTexts)
        {
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
            currentDraggableText.textObj.localPosition = localPoint;
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
            if(RectTransformUtility.RectangleContainsScreenPoint(draggable.textObj,eventData.position, canvas.worldCamera))
            {
                return draggable;
            }
        }
        return null;
    }
}

