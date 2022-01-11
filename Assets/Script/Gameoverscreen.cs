using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameoverscreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score) {
    pointsText.text = score.ToString() + "POINTS";


    }
    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }


    public void ExitButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
