using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuizQuestion", menuName = "Quiz/Question")]
public class QuizQuestion : ScriptableObject
{
    public string questionText;
    public List<Answer> answers;
}