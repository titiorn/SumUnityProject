using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTextOnClick : MonoBehaviour
{
    [System.Serializable]
    public class InteractionData
    {
        public string OrganName; //The name of Organ
        public GameObject targetObj; //Organ to click on
        public GameObject ObjText; // The parent GameObject that contains text and its arrow image
    
        public Outline outlineScript; //Link with Outline Script that assign in each obj

        /*public void ToggleOutline()
        {
            if(outlineScript != null)
            {
                outlineScript.enabled = !outlineScript.enabled;
            }
        }*/
    
    }


    public InteractionData[] interactionOrgans; //Use array to hold interaction data for multiple objects


    void Start()
    {
        //Ensure all texts and their arrow children are hidden at the start
        foreach(var data in interactionOrgans)
        {
            if(data.ObjText != null)
            {
                data.ObjText.SetActive(false);
            }

            /*data.outlineScript = data.targetObj.GetComponent<Outline>();
            if(data.outlineScript != null)
            {
                data.outlineScript.enabled = false;
            }*/

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
                foreach(var data in interactionOrgans)
                {
                    if(hit.transform.gameObject == data.targetObj)
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
        //Toggle the outline
        //data.ToggleOutline();

        //Check if the text and arrow are currently active
        bool isActive = data.ObjText.activeSelf;

        //Toggle the visibility
        data.ObjText.SetActive(!isActive);


        //Hide other UI elements
        foreach(var otherData in interactionOrgans)
        {
            if(otherData != data && otherData.ObjText != null)
            {

                if(otherData.outlineScript != null)
                {
                    //otherData.outlineScript.enabled = false;
                }

                if(otherData.ObjText != null)
                {
                    //otherData.ObjText.SetActive(false);
                }
            }
        }
    }
}
