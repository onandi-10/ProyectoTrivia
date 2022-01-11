using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public static Action OnNewQuestionLoaded;

    public static Action OnAnswerProvided;

    public Transform CorrectImage;

    public Transform IncorrectImage;

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

        OnNewQuestionLoaded?.Invoke();
    }

    public bool AnswerQuestion(int answerIndex)
    {

        OnAnswerProvided?.Invoke();
        
        bool isCorrect = _currentQuestion.CorrectAnswerIndex == answerIndex;

        if(isCorrect)
        {
            TweenResult(CorrectImage);
        }
        else
        {
            TweenResult(IncorrectImage);
        }

        return isCorrect;

    }

    void TweenResult(Transform resultTransform)
    {
        Sequence result = DOTween.Sequence();
        result.Append(resultTransform.DOScale(1, .5f).SetEase(Ease.OutBack));
        result.AppendInterval(1f);
        result.Append(resultTransform.DOScale(0, .2f).SetEase(Ease.Linear));
        result.AppendCallback(LoadNextQuestion);
    }
}
