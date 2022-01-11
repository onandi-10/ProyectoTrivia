using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public QuestionUI Question;

    public string CategoryName;

    private GameManager _gameManager;

    private QuestionModel _currentQuestion;


    private void Start()
    {
        //Reference
        _gameManager = GameManager.Instance;

        LoadNextQuestion();
    }
    
    void LoadNextQuestion()
    {
        _currentQuestion = _gameManager.GetQuestionForCategory(CategoryName);
        if(_currentQuestion != null)
        {
            Question.PopulateQuestion(_currentQuestion);

        }
    }

    public bool AnswerQuestion(int answerIndex)
    {
        return _currentQuestion.CorrectAnswerIndex == answerIndex;

    }
}
