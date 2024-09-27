using System.Collections;
using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public QuizQuestion[] currentQuestion;
    public TMP_Text questionText;
    public TMP_Text[] buttonText;
    public TMP_Text resultText;
    public float[] waitTime;
    public GameObject quizObject;

    private int currentQuestionIndex;

    private void Start()
    {
        DisplayQuestion();
    }

    public void DisplayQuestion()
    {
        //displays the question from the current SO to the questionText 
        questionText.text = currentQuestion[currentQuestionIndex].questionText;

        //loops through all the answers from current SO and display them on the button texts
        for (int i = 0; i < currentQuestion[currentQuestionIndex].answers.Count; i++)
        {
            if (buttonText[i] != null)
            {
                buttonText[i].text = currentQuestion[currentQuestionIndex].answers[i].answerText;
            }
        }
    }

    public void CheckAnswer(int answerIndex)
    {
        if (currentQuestion[currentQuestionIndex].answers[answerIndex].isCorrect)
        {
            //if player chose correct answer
            resultText.text = "Correct!";
        }
        else
        {
            ///if player chose wrong answer
            resultText.text = "Wrong!";
        }

        //increases index so that next time next question SO is shown
        currentQuestionIndex += 1;

        //checks if there are more questions SO in the list
        if (currentQuestionIndex < currentQuestion.Length)
        {
            quizObject.SetActive(false);
            StartCoroutine(WaitTime());
        }
    }

    //waits the waittime of current questions index, for X amount of seconds
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime[currentQuestionIndex - 1]);

        quizObject.SetActive(true);
        DisplayQuestion();
    }
}
