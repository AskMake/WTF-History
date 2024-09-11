using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quizbox : MonoBehaviour
{
    [SerializeField]
    private ClipsAndQuiz CAQ;
    [SerializeField]
    private GameObject[] buttons;
    string[] questions;
    public void Start()
    {
        if (CAQ)
        {
            questions = CAQ.GetQuiz();
            if(questions != null){
            SetButtons(questions.Length);}
            VideoManager.Instance.quizManagerTime = CAQ.GetQuizTime();
            CAQ.SetVideoClip();
        }
    }
    private void SetButtons(int index)
    {
        for (int i = 0; i < index; i++)
        {
            GameObject go = buttons[i];
            go.GetComponentInChildren<TMP_Text>().text = questions[i];
        }
    }
}
