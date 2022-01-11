using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerUI : MonoBehaviour
{
    public int AnswerIndex;


  public void OnAnswerClicked()
  {
    bool result = QuestionsManager.Instance.AnswerQuestion(AnswerIndex);
    Debug.Log(result);
     
  }
}
