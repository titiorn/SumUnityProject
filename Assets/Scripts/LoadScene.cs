using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    //this script will load the next scene by name which can be edited in the inspector in Unity

    public void PanelLoad()


    {
        SceneManager.LoadScene(5);

    }
}
