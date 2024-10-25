using System.Collections;
using TMPro;
using UnityEngine;
using Utilities;

public class Quiz : Singleton<Quiz>
{
    public QuizQuestion[] currentQuestion;
    public TMP_Text questionText;
    public TMP_Text[] buttonText;
    public TMP_Text resultText;
    private bool isPaused;
    //public float[] waitTime;
    public GameObject quizObject;
    public GameObject rectQuiz;
    [SerializeField]
    private float pauseTime = 5;
    public bool displayQ {get; private set;}

    private int currentQuestionIndex;

    private void Start()
    {
        DisplayQuestion();
        quizObject.SetActive(false);
    }

    public void DisplayQuestion()
    {
        rectQuiz.SetActive(true);
        VideoManager.Instance.PauseVid();
        quizObject.SetActive(true);
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
        resultText.gameObject.SetActive(true);
        resultText.text = "";
        if (currentQuestion[currentQuestionIndex].answers[answerIndex].isCorrect)
        {
            //if player chose correct answer
            resultText.text = "You answered correctly! Congrats!";
        }
        else
        {
            ///if player chose wrong answer
            resultText.text = "Wrong, what a bummer, better luck next time!";
        }

        
        //increases index so that next time next question SO is shown
        currentQuestionIndex += 1;
        StartCoroutine(LookAtAnswerTime(pauseTime));
        //checks if there are more questions SO in the list
        if (currentQuestionIndex < currentQuestion.Length)
        {   
            rectQuiz.SetActive(false);
            // float timeWait = currentQuestion[currentQuestionIndex+1].waitTime + pauseTime;
            // StartCoroutine(WaitTime(timeWait));
        }
        
    }

    //waits the waittime of current questions index, for X amount of seconds
    private IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        DisplayQuestion();
    }
    // public void TimeToWait()
    // {
    //     float timeWait = currentQuestion[currentQuestionIndex].waitTime;
    //     StartCoroutine(WaitTime(timeWait));
    // }
    private IEnumerator LookAtAnswerTime(float time)
    { 
        yield return new WaitForSeconds(time);
        resultText.gameObject.SetActive(false);
        VideoManager.Instance.ContinuePlay();
        displayQ = false;
    }
    public void SetQuestionIndex(int questionIndex)
    {
        currentQuestionIndex = questionIndex;
    }
    public void Pause()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            isPaused = true;
            Time.timeScale= 0;
        }
    }
    void Update()
    {
        if(currentQuestion[currentQuestionIndex].waitTime == VideoManager.Instance.Player.time && !displayQ && VideoManager.Instance.Player.isPlaying)
        {
            displayQ = true;
            DisplayQuestion();
        }
    }
}
