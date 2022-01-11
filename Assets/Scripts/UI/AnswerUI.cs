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


  public void OnAnswerClicked()
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
