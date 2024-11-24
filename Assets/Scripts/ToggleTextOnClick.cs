using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTextOnClick : MonoBehaviour
{
    [System.Serializable]
    public class InteractionData
    {
        public GameObject targetOrgan; //Organ to click on
        public GameObject OrganText; // The parent GameObject that contains text and its arrow image
        
        //public Text OrganName; //The UI text element to display Organ name
        public string OrganName; //The name of Organ

        //private Outline Outline;

        
    
        //Initialize and find the outline script
        /*public void Initialize()
        {
            Outline = targetOrgan.GetComponent<Outline>();

        }

        //Toggle the outline on and off
        public void UpdateMaterialProperties()
        {
            if(Outline != null)
            {
                Outline.UpdateMaterialProperties();
            }
        }*/
    
    }


    public InteractionData[] interactionOrgans; //Use array to hold interaction data for multiple objects


    void Start()
    {
        //Ensure all texts and their arrow children are hidden at the start
        foreach(var data in interactionOrgans)
        {
            if(data.OrganText != null)
            {
                data.OrganText.SetActive(false);
            }
            //data.Initialize();
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
                    if(hit.transform.gameObject == data.targetOrgan)
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
        bool isActive = data.OrganText.activeSelf;

        //Toggle the visibility
        data.OrganText.SetActive(!isActive);


        //Show the parent GameObj (Organtext and arrow)
        /*if(data.OrganText != null)
        {
            data.OrganText.SetActive(true);
            //data.OrganText.text = data.LNname;
        }*/

        //Hide other UI elements
        foreach(var otherData in interactionOrgans)
        {
            if(otherData != data && otherData.OrganText != null)
            {
                //otherData.OrganText.SetActive(false);
                //otherData.ToggleOutline(); //Remove outline from other objects

                if(otherData.OrganText != null)
                {
                    //otherData.OrganText.SetActive(false);
                }
            }
        }
    }
}
