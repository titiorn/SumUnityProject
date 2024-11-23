using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTextOnClick : MonoBehaviour
{
    [System.Serializable]
    public class InteractionData
    {
        public GameObject targetLN; //LN to click on
        public GameObject LymphNodeText; // The parent GameObject that contains text and its arrow image
        
        //public Text LNnameText; //The UI text element to display LN name
        
        public string LymphNodeName; //The name of lymph node
    }

    public InteractionData[] interactionLymphNodes; //Use array to hold interaction data for multiple objects


    void Start()
    {
        //Ensure all texts and their arrow children are hidden at the start
        foreach(var data in interactionLymphNodes)
        {
            if(data.LymphNodeText != null)
            {
                data.LymphNodeText.SetActive(false);
            }
        }
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                foreach(var data in interactionLymphNodes)
                {
                    if(hit.transform.gameObject == data.targetLN)
                    {
                        ToggleInteraction(data);
                        break;
                    }
                }
            }
        }
    }

    void ToggleInteraction(InteractionData data)
    {
        //Check if the text and arrow are currently active
        bool isActive = data.LymphNodeText.activeSelf;

        //Toggle the visibility
        data.LymphNodeText.SetActive(!isActive);


        //Show the parent GameObj (LNtext and arrow)
        /*if(data.LymphNodeText != null)
        {
            data.LymphNodeText.SetActive(true);
            //data.LNnameText.text = data.LNname;
        }*/

        //Hide other UI elements
        foreach(var otherData in interactionLymphNodes)
        {
            if(otherData != data)
            {
                if(otherData.LymphNodeText != null)
                {
                    //otherData.LymphNodeText.SetActive(false);
                }
            }
        }
    }
}
