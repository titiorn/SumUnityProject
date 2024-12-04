using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnDScoreSetting : MonoBehaviour
{
    public static DnDScoreSetting singleton;

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

    public void OnClickSubmit(int maxScore)
    {
        
            Debug.Log("score " + score);
            if(score == maxScore)
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
