using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnswerUI : MonoBehaviour
{
  public Image CorrectImage;

  public Image IncorrectImage; 

  public int AnswerIndex;

  private bool _canBeClicked = true;

  private void OnEnable()
  {
    QuestionsManager.OnNewQuestionLoaded += ResetValues;
    QuestionsManager.OnAnswerProvided += AnswerProvided;
  }

  private void OnDisable()
  {
    QuestionsManager.OnNewQuestionLoaded -= ResetValues;
    QuestionsManager.OnAnswerProvided -= AnswerProvided;  
  }


  public void OnAnswerClicked()
  {
    if(_canBeClicked)
    {
      bool result = QuestionsManager.Instance.AnswerQuestion(AnswerIndex);
      if(result)
      {
        CorrectImage.DOFade(1, .5f);
      }
      else
      {
        IncorrectImage.DOFade(1, .5f);
      }

    }

     
  }

  void AnswerProvided()
  {
    _canBeClicked = false;
  }

  void ResetValues()
  {
    CorrectImage.DOFade(0, .2f);
    IncorrectImage.DOFade(0, .2f);
    _canBeClicked = true;

  }

}
