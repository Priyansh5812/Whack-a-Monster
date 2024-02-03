using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RandomValue : MonoBehaviour
{
    // text fields
    [SerializeField] private TMP_Text productivityScore;
    [SerializeField] private TMP_Text cognitionScore;
    [SerializeField] private TMP_Text wellnessScore;
    [SerializeField] private TMP_Text empowermentScore;


    //images
    [SerializeField] private Image productivityImg;
    [SerializeField] private Image cognitionImg;
    [SerializeField] private Image wellnessImg;
    [SerializeField] private Image empowermentImg;


    private int prodScore;
    private int wellScore;
    private int cogScore;

    public void DisplayProductivityScore()
    {
        prodScore = RandomNumberGenerator();
        productivityScore.text = $"{prodScore}%";
        productivityImg.fillAmount = (float)prodScore / 100;

    }

    public void DisplayCognitionScore()
    {
        cogScore = RandomNumberGenerator();
        cognitionScore.text = $"{cogScore}%";
        cognitionImg.fillAmount = (float)cogScore / 100;

    }

    public void DisplayWellnessScore()
    {
        wellScore = RandomNumberGenerator();
        wellnessScore.text = $"{wellScore}%";
        wellnessImg.fillAmount = (float)wellScore / 100;

    }

    public void DisplayEmpowermentScore()
    {
        var score = (prodScore + cogScore + wellScore) / 3;
        empowermentScore.text = $"{score}%";
        empowermentImg.fillAmount = (float)score / 100;

    }

    public int RandomNumberGenerator()
    {
        int randomNumber = Random.Range(0, 101);
        return randomNumber;
    }
}
