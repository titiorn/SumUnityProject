using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageRenderTextureOnClick : MonoBehaviour
{
    [SerializeField]
    private RawImage myImagePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        myImagePanel.texture = transform.GetChild(0).GetComponent<Camera>().targetTexture;
    }

}
