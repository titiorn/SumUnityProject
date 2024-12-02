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
        canvas = GetComponentInParent<Canvas>();

        //Cache RectTransform and CanvasGroup for each draggable text
        foreach(var draggable in draggableTexts)
        {
            draggable.isPlacedCorrectly = false; //Initializa placement status
        }

        submitButton.onClick.AddListener(OnSubmit);
        hoorayPopup.SetActive(false); //Ensure pop-ups are initially inactive
        sadPopup.SetActive(false);

    }


    public void OnEndDrag(PointerEventData eventData)
    {
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
    }
    

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
