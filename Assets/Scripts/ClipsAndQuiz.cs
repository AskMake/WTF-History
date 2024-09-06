using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public class ClipsAndQuiz : MonoBehaviour
{
    [SerializeField]
    private VideoClip clip;
    [SerializeField]
    private string[] quiz;
    private double quizTime;
    // Start is called before the first frame update
    void Awake()
    {
        if (quiz.Length == 0)
        {
            Debug.LogWarning("Please add quiz questions");
        }
        else if (quiz.Length > 4)
        {
            Array.Resize(ref quiz, 4);
        }
        quiz = quiz.Where(val => val != "" ).ToArray();
    }
    public string[] GetQuiz()
    {
        if(quiz.Length == 0)
        {
            return null;
        }
        return quiz;
    }
    public void PlayVideoClip()
    {
        if(clip != null)
        {
            VideoManager.Instance.PlayVid(clip);
            VideoManager.Instance.quizManagerTime = quizTime;
        }
    }
}
