using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLHL_GameManager : MonoBehaviour
{
    public static FLHL_GameManager singleton;

    public int score;
    public GameObject hooray;
    public GameObject sadFace;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void OnClickSubmit()
    {
        
            Debug.Log("score " + score);
            if(score == 2)
            {
                Debug.Log("success");
                hooray.SetActive(true);
                sadFace.SetActive(false);
            }
            else
            {
                Debug.Log("failure");
                hooray.SetActive(false);
                sadFace.SetActive(true);
            }
    }
}
