using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu]
public class ClipsAndQuiz : ScriptableObject
{
    public string VideoAndQuizName;   
    [SerializeField]
    private VideoClip clip;
    [SerializeField]
    private string[] quiz;
    [SerializeField]
    private double[] quizTime;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (quiz?.Length == 0)
        {
            Debug.LogWarning("Please add quiz questions");
        }
        quiz = quiz?.Where(val => val != "" ).ToArray();
    }
    public string[] GetQuiz()
    {
        if(quiz.Length == 0)
        {
            return null;
        }
        return quiz;
    }
    public double[] GetQuizTime()
    {
        return quizTime;
    }
    public void SetVideoClip()
    {
        if(clip != null)
        {
            VideoManager.Instance.SetClip(clip);
        }
    }
}
