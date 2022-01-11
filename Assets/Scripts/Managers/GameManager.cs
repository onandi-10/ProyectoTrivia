using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameModel Configuration;

    public QuestionModel GetQuestionForCategory(string categoryName)
    {
        CategoryModel categoryModel = Configuration.Categories.FirstOrDefault( predicate: category => category.CategoryName == categoryName);
        if(categoryModel != null)
        {
            return categoryModel.Questions[0];
        }

        //if we reached here, no category was found with that name
        return null;
    }
}
