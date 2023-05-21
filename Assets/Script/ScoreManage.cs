using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{
    public float pointPerSecond;

    public Text scoreText;
    public Text hiScoreText;

    public float score;
    private float hiScore;

    public bool isScoreIncreasing; 
    void Start()
    {
        isScoreIncreasing = true;

        if (PlayerPrefs.HasKey("HiScore"))
            hiScore = PlayerPrefs.GetFloat("HiScore");
        
    }

    void Update()
    {
        if(isScoreIncreasing)
            score += pointPerSecond * Time.deltaTime;

        if(score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }

        scoreText.text = Mathf.Round(score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();


    }
}
