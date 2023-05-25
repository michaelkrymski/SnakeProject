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
        if((int)PlayerPrefs.GetFloat("multiplier") != 0)
        {
            value *= (int)PlayerPrefs.GetFloat("multiplier");
            maxScore *= (int)PlayerPrefs.GetFloat("multiplier");
        }
        currentScore += value;
        scoreText.text = "Score: " + currentScore;

        if(currentScore == (maxScore))
        {
            PlayerPrefs.SetFloat("balance", currentScore + PlayerPrefs.GetFloat("balance"));
            SceneManager.LoadScene(0);
        }
    }
}
