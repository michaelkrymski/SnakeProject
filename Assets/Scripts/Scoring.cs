using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int currentScore;
    void Start()
    {
        currentScore = 0;
    }
    // Start is called before the first frame update
    public void UpdateScore(int value, int maxScore)
    {
        currentScore += value;
        scoreText.text = "Score: " + currentScore;
        if(currentScore == maxScore)
        {
            PlayerPrefs.SetInt("balance", currentScore + PlayerPrefs.GetInt("balance"));
            SceneManager.LoadScene(0);
        }
    }
}
