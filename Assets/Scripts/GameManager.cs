using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent QuizEvent;

    void OnEnable()
    {
        if (QuizEvent != null)
        {
            QuizEvent = new UnityEvent();
        }
    }
}
