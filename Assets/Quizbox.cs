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
    private GameObject buttonGO;
    string[] questions;
    public void OnEnable()
    {
        if (CAQ)
        {
            questions = CAQ.GetQuiz();
            CreateButtons(questions.Length);
        }
    }
    private void CreateButtons(int index)
    {
        for (int i = 0; i < index; i++)
        {
            Instantiate(buttonGO,transform);
            buttonGO.GetComponentInChildren<TMP_Text>().text = questions[i];
        }
    }
}
