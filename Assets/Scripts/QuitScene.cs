using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScene : MonoBehaviour
{
    //this script will quit the game
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game has ended");
    }
}
