using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManageOnMouseEnterLabels : MonoBehaviour
{
    [SerializeField]
    private GameObject myLabel;

    // this script reveals labels upon mouse enter
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        myLabel.SetActive(true);
    }

    void OnMouseExit()
    {
        myLabel.SetActive(false);
    }
}
