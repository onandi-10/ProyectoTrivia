using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public static Action OnNewQuestionLoaded;

    public static Action OnAnswerProvided;

    public Transform CorrectImage;

    public Transform IncorrectImage;

    public QuestionUI Question;

    private GameManager _gameManager;

    private string _currentCategory;

    private QuestionModel _currentQuestion;


    private void Start()
    {
        //Reference
        _gameManager = GameManager.Instance;

        _currentCategory = _gameManager.GetCurrentCategory();

        LoadNextQuestion();
    }
    
    void LoadNextQuestion()
    {
    
        _currentQuestion = _gameManager.GetQuestionForCategory(_currentCategory);
        Debug.Log(_currentQuestion);
        
        if(_currentQuestion != null)
        {
            Question.PopulateQuestion(_currentQuestion);

        }

        OnNewQuestionLoaded?.Invoke();
    }

    public bool AnswerQuestion (int answerIndex)
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
