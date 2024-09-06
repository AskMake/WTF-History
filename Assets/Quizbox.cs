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
    ScrollRect rect;
    public void Start()
    {
        rect = GetComponent<ScrollRect>();
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
            GameObject go = Instantiate(buttonGO,rect.content.transform);
            RectTransform rectGO = go.GetComponent<RectTransform>();
            rectGO.anchoredPosition = new Vector3(0,i*50-20,0);
            go.GetComponentInChildren<TMP_Text>().text = questions[i];

        }
    }
}
