using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public QuestionUI Question;

    public string CategoryName;

    private GameManager _gameManager;


    private void OnEnable()
    {
        //Reference
        _gameManager = GameManager.Instance;

        LoadNextQuestion();
    }
    void LoadNextQuestion()
    {
        var newQuestion = _gameManager.GetQuestionForCategory(CategoryName);
        if(newQuestion != null)
        {
            Question.PopulateQuestion(newQuestion);

        }
    }
}
