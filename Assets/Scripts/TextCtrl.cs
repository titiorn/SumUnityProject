using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextCtrl : MonoBehaviour
{
    public DragText.TextType textType;
   
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlacerCtrl placerCtrl = collider.GetComponent<PlacerCtrl>();

        if(placerCtrl.textType == textType)
        {
            DnDScoreSetting.singleton.score +=1;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        PlacerCtrl placerCtrl = collider.GetComponent<PlacerCtrl>();

        if(placerCtrl.textType == textType)
        {
            DnDScoreSetting.singleton.score -=1;
        }
    }

}
