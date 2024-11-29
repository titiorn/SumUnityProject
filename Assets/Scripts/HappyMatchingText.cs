using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class HappyMatchingText : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [System.Serializable]
    public class DraggableText
    {
        public TextMeshProUGUI textObj; //Text to be dragged
        [HideInInspector] public RectTransform rectTransform;
        [HideInInspector] public CanvasGroup canvasGroup;

        public GameObject placer; //Placer for each text
        [HideInInspector] public bool isPlacedCorrectly; //Status of Placement
    }

    public List<DraggableText> draggableTexts; //List of draggable texts
    //public Animator sceneAnimator; //Animator for the scene Animation
    public VideoPlayer videoPlayer;
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
            draggable.isPlacedCorrectly = false; //Initializa placement status
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

            //Check if the text is placed in the correct spot
            if(RectTransformUtility.RectangleContainsScreenPoint(currentDraggableText.placer.GetComponent<RectTransform>(), eventData.position, canvas.worldCamera))
            {
                currentDraggableText.rectTransform.localPosition = currentDraggableText.placer.GetComponent<RectTransform>().localPosition;
                currentDraggableText.isPlacedCorrectly = true;
            }
            else
            {
                currentDraggableText.isPlacedCorrectly = false;
            }

            currentDraggableText = null;

            //Check if all texts are correctly placed
            /*if(AllTextsPlacedCorrectly())
            {
                PlayAnimation();
            }*/

            if(AllTextsPlacedCorrectly())
            {
                PlayVideo();
            }

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

    private bool AllTextsPlacedCorrectly()
    {
        foreach(var draggable in draggableTexts)
        {
            if(!draggable.isPlacedCorrectly)
            {
                return false; //If any text is not correctly placed, return false
            }
        }
        return true; //All texts are correctly placed
    }

    /*private void PlayAnimation()
    {
        //Trigger the scene animation
        if(sceneAnimator != null)
        {
            sceneAnimator.SetTrigger("PlayAnimation");
        }
        else
        {
            Debug.LogError("Animator component is not assigned!");
        }
    }*/

    private void PlayVideo()
    {
        if(videoPlayer != null)
        {
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("VideoPlayer component is not assigned!");
        }
    }
}
