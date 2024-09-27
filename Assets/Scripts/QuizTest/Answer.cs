using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answer
{
    public string answerText;
    public bool isCorrect;
}

[CreateAssetMenu(fileName = "NewQuizQuestion", menuName = "Quiz/Question")]
public class QuizQuestion : ScriptableObject
{
    public string questionText;
    public List<Answer> answers;
}