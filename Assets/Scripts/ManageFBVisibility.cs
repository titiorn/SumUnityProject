using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFBVisibility : MonoBehaviour
{

    public GameObject hooray;
    public GameObject sadFace;

    void OnEnable()
    {
        hooray.SetActive(false);
        sadFace.SetActive(false);
    }
    

}
