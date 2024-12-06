using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ManageQuestion : MonoBehaviour
{
    public GameObject userResponse;

    public GameObject correctResponse;

    [SerializeField]
    private GameObject positiveFeedback;

    [SerializeField]
    private GameObject negativeFeedback;

    [SerializeField]
    private ToggleGroup myToggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnConfirmClick()
    {
        //Compare user answer vs correct answer
        Toggle selectedToggle = myToggleGroup.ActiveToggles().FirstOrDefault();
        userResponse = selectedToggle.gameObject;

        //Set All toggles as non interactable
        for (int i = 0; i < myToggleGroup.transform.childCount; i++)
        {
            myToggleGroup.transform.GetChild(i).GetComponent<Toggle>().interactable = false;
        }

        if (userResponse == correctResponse)
        {
            //Show Positive Feedback
            positiveFeedback.SetActive(true);

            transform.parent.GetComponent<ManageQuiz>().score += 1;
        }
        else
        {
            //Show Negative Feedback
            negativeFeedback.SetActive(true);
        }
    }
}
