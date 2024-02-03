using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameControl : MonoBehaviour
{
    public GameObject PlayCanvas;
    public GameObject FinishCanvas;
    public GameObject enemySpawner;
    public TMP_Text scoreText;
    public TMP_Text finalscoreText;
    public TMP_Text timeText;
    public TMP_Text highScoreText;
    public TMP_Text accuracyText;
    public static int score = 0;
    public float numberOfCorrectHits = 0;
    public float numberOfHits = 0;
    public static float accuracy;
    public static int highScore;
    public float timeLeft = 120;
    bool isHit;

    private void Awake()
    {
        score = 0;
        accuracy = 0;

    }
    void Start()
    {
        scoreText.text = score.ToString();
        

    }

    

    void Update()
    {
        if(numberOfHits > 0)
        {
            accuracy = 100 * (numberOfCorrectHits / numberOfHits);
            accuracy = (int)accuracy;
            
        }
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F0");
        scoreText.text = score.ToString();
        if (score > highScore) { highScore = score; }
        if (timeLeft < 0)
        {

            GameOver();
        }


    }

    public void GameOver()
    {

        PlayCanvas.SetActive(false);
        FinishCanvas.SetActive(true);
        finalscoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
        accuracyText.text = accuracy.ToString();
        gameObject.SetActive(false);
        enemySpawner.SetActive(false);
    }


}

