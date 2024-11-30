using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HappyMatchingText : MonoBehaviour //, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [System.Serializable]
    public class DraggableText
    {
        public TextMeshProUGUI textObj; //Text to be dragged
        [HideInInspector] public RectTransform rectTransform;
        [HideInInspector] public CanvasGroup canvasGroup;
        public Collider2D placer; //Placer for each text
        [HideInInspector] public bool isPlacedCorrectly; //Status of Placement
    }

    public List<DraggableText> draggableTexts; //List of draggable texts
    public Button submitButton;
    public GameObject hoorayPopup;
    public GameObject sadPopup;
    private Canvas canvas;
    private DraggableText currentDraggableText;

    
    private void Awake()
    {
        //canvas = GetComponentInParent<Canvas>();

        //cache RectTransform and CanvasGroup for each draggable text
        foreach(var draggable in draggableTexts)
        {
            //draggable.rectTransform = draggable.textObj.GetComponent<RectTransform>();
            //draggable.canvasGroup = draggable.textObj.gameObject.AddComponent<CanvasGroup>();
            draggable.isPlacedCorrectly = false; //Initializa placement status
        }

        submitButton.onClick.AddListener(OnSubmit);
        hoorayPopup.SetActive(false); //Ensure pop-ups are initially inactive
        sadPopup.SetActive(false);

    }

    /*public void OnBeginDrag(PointerEventData eventData)
    {
        currentDraggableText = GetDraggableTextUnderPointer(eventData);
        if(currentDraggableText != null)
        {
            currentDraggableText.canvasGroup.alpha = 0.6f; //Control the visibility of text while dragging
            currentDraggableText.canvasGroup.blocksRaycasts = false; //Allow text to be dragged through other UI elements
        }

    }*/

    /*public void OnDrag(PointerEventData eventData)
    {
        if(currentDraggableText != null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPoint);
            currentDraggableText.rectTransform.localPosition = localPoint;
        }

    }*/

    public void OnEndDrag(PointerEventData eventData)
    {
        if(currentDraggableText != null)
        {
            //currentDraggableText.canvasGroup.alpha = 1f;
            //currentDraggableText.canvasGroup.blocksRaycasts = true;

            if(currentDraggableText.placer != null)
            {
                //Check if the text is placed in the correct spot
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out localPoint);
                currentDraggableText.isPlacedCorrectly = currentDraggableText.placer.OverlapPoint(Input.mousePosition);
                Debug.Log("Text placed:" + currentDraggableText.textObj.name + "Correctly:" + currentDraggableText.isPlacedCorrectly);
            }
            else
            {
                Debug.LogError("Placer is not assigned for text:" + currentDraggableText.textObj.name);
                currentDraggableText.isPlacedCorrectly = false;
            }

            currentDraggableText = null;

        }
    }
    
    /*private DraggableText GetDraggableTextUnderPointer(PointerEventData eventData)
    {
        foreach(var draggable in draggableTexts)
        {
            if(RectTransformUtility.RectangleContainsScreenPoint(draggable.rectTransform,eventData.position, canvas.worldCamera))
            {
                return draggable;
            }
        }
        return null;
    }*/

    private void OnSubmit()
    {
        bool allCorrect = true;

        foreach(var draggable in draggableTexts)
        {
            if(!draggable.isPlacedCorrectly)
            {
                Debug.Log("Text not placed correctly:" + draggable.textObj.name);
                allCorrect = false;
                break;
            }
        
        }

        if(allCorrect)
        {
            Debug.Log("All texts placed correctly.");
            hoorayPopup.SetActive(true);
            sadPopup.SetActive(false);
        }
        else
        {
            Debug.Log("Not all texts are placed correctly.");
            sadPopup.SetActive(true);
            hoorayPopup.SetActive(false);
        }
    }

  
}
