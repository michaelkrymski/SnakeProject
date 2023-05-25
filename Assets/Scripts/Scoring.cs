using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI boostInfo;
    [SerializeField] GameObject exitInfo;
    private int currentScore;
    private bool canExit = false;
    void Start()
    {
        currentScore = 0;
        if(PlayerPrefs.GetInt("dashTutorialRequired", 1) == 1)
        {
            boostInfo.color = new Color(boostInfo.color.r, boostInfo.color.g, boostInfo.color.b, 1);
            StartCoroutine(Delay(3f));
            PlayerPrefs.SetInt("dashTutorialRequired", 0);
        }
        else
        {
            boostInfo.color = new Color(boostInfo.color.r, boostInfo.color.g, boostInfo.color.b, 0);
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(canExit)
            {
                StartCoroutine(ExitGame(2f));
            }
        }
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

        if(currentScore >= (maxScore))
        {
            canExit = true;
            exitInfo.SetActive(true);
        }
    }

    private IEnumerator ExitGame(float delay)
    {
        SnakeManager.Instance.GetComponent<SnakeManager>().SetSpeed(0);
        Camera.main.transform.GetChild(0).GetComponent<WinLoseAudioManager>().PlayWinSound();
        yield return new WaitForSeconds(delay);
        PlayerPrefs.SetFloat("balance", currentScore + PlayerPrefs.GetFloat("balance"));
        SceneManager.LoadScene(0);
    }

    public IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeTextToZeroAlpha(1.5f, boostInfo));
    }

    public IEnumerator FadeTextToZeroAlpha(float time, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
}
