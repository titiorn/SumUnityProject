using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageQuiz : MonoBehaviour
{
    public int maxQuestionIndex = 3;

    public int myQuestionIndex = 0;

    public List<GameObject> questionList;

    //[SerializeField]
    //private GameObject finalPanel;

    [SerializeField]
    private GameObject finalPanelCorrect;

    [SerializeField]
    private GameObject finalPanelIncorrect;
   
    //[SerializeField]
    //private GameObject scoreIndicator;
    
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //OnClickNext();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Score " + score);
        //FinalScore();
        //OnClickNext();
    }

    public void OnClickNext()
    {
        if (myQuestionIndex < maxQuestionIndex)
        {

            int index = Random.Range(0,3);

            //retrieve Question from the List& Set Question to visible
            questionList[index].SetActive(true);

            //Remove Question from List
            questionList.RemoveAt(index);

            //increase myQuestion Index value
            myQuestionIndex +=1;
            FinalScore();
        }
        else
        {
            //Show the Score panel
            //finalPanel.SetActive(true);

            //scoreIndicator.GetComponent<TextMeshProUGUI>().text = scoreIndicator.GetComponent<TextMeshProUGUI>().text + score;

            Debug.Log("Score " + score);

            //FinalScore();
        }
    }

    //Create A New Method that 

    public void FinalScore()
    {
        if(score == 3)
        {
            finalPanelCorrect.SetActive(true);
            Debug.Log("Correct" + score);
        }

        if(score != 3)
        {
            finalPanelIncorrect.SetActive(true);
            Debug.Log("Incorrect" + score);
        }

    }

}



