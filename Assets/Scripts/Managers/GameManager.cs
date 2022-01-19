using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameModel Configuration;

    private string _currentCategory;

    private List<int> _askedQuestionIndex = new List<int>();

    public QuestionModel GetQuestionForCategory(string categoryName)
    {
        CategoryModel categoryModel = Configuration.Categories.FirstOrDefault( predicate: category => category.CategoryName == categoryName);
        Debug.Log(categoryModel);
        Debug.Log(categoryName);

        if(categoryModel != null)
        {

            int randomIndex = Random.Range(0, categoryModel.Questions.Count);
            while(categoryModel.Questions.Count > _askedQuestionIndex.Count && _askedQuestionIndex.Contains(randomIndex))
               randomIndex = Random.Range(0, categoryModel.Questions.Count);

            _askedQuestionIndex.Add(randomIndex);

            return categoryModel.Questions[randomIndex];
        }

        //if we reached here, no category was found with that name
        return null;
    }

    public void SetCurrentCategory(string categoryName)
    {
        _currentCategory = categoryName;

        _askedQuestionIndex.Clear();
    }

    public string GetCurrentCategory()
    {
        return _currentCategory;
    }
}
