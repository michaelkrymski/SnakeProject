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
            SceneManager.LoadScene(0);
        }
    }
}
