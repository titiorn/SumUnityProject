using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ManageRenderTextureOnClick : MonoBehaviour
{
    [SerializeField]
    private RawImage myImagePanel;

    public string info_text;
    public GameObject textObject;
    public TextMeshProUGUI infoText;

    private bool isPanelActive = false;

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
        isPanelActive = !isPanelActive;

        textObject.SetActive(isPanelActive);
        infoText.text = info_text;

        //gameObject.GameObject = transform.GetChild(0).GetComponent<GameObject>().targetGameObject;
    }

}
