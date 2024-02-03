using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class DataVisualization : MonoBehaviour
{
    // Enum representing the emotions
    public enum Emotion
    {
        Good,
        Happy,
        Spectacular,
        Upset,
        Sad,
        Angry
    }

    // Dictionary to store the emotion counts
    Dictionary<Emotion, int> emotionCounts;

    // Define the weights for each emotion
    Dictionary<Emotion, int> emotionWeights = new Dictionary<Emotion, int>()
    {
        { Emotion.Good, 1 },
        { Emotion.Happy, 2 },
        { Emotion.Spectacular, 3 },
        { Emotion.Upset, -1 },
        { Emotion.Sad, -2 },
        { Emotion.Angry, -3 }
    };

    //GamesText
    //public TMP_Text displayText;
    public TMP_Text WhackMonsterHighscoreValue;
    public TMP_Text ShipyardHighscoreValue;
    public TMP_Text WhackMosterAverageScoreValue;
    public TMP_Text ShipyardAverageScoreValue;
    public TMP_Text memoryAverageValue;
    public TMP_Text processingAverageValue;
    public TMP_Text attentionAverageValue;
    //mediationText
    public TMP_Text angryAverageValue;
    public TMP_Text sadAverageValue;
    public TMP_Text upsetAverageValue;
    public TMP_Text goodAverageValue;
    public TMP_Text happyAverageValue;
    public TMP_Text spectacularAverageValue;

    //MeetingGptText
    public TMP_Text relevanceValue;
    public TMP_Text coherenceValue;
    public TMP_Text engagementValue;
    public TMP_Text techAccValue;
    public TMP_Text WPMValue;

    //OverallScoresText
    public TMP_Text confidenceValue;
    public TMP_Text cogntionValue;
    public TMP_Text wellnessValue;
    public TMP_Text producitivityValue;
    public TMP_Text empowermentValue;

    //GamesImage
    public Image averageProcessingImg;
    public Image averageMemoryImg;
    public Image averageAttentionImg;
    //public Image WmAvgScoreImg;
    //public Image SyAvgScoreImg;

    //MeditationImages
    public Image angryImg;
    public Image sadImg;
    public Image upsetImg;
    public Image goodImg;
    public Image happyImg;
    public Image spectacularImg;

    //MeetingImages
    public Image relevanceImg;
    public Image coherenceImg;
    public Image engagementImg;
    public Image techAccImg;

    //OverallImages
    public Image productivityImg;
    public Image wellnessImg;
    public Image empowermentImg;

    //globalVariables
    private int averageMemory;
    private int averageProcessing;
    private int averageAttention;
    private float averageAngry;
    private float averageUpset;
    private float averageSad;
    private float averageGood;
    private float averageHappy;
    private float averageSpectacular;
    private int averageRelevance;
    private int averageCoherence;
    private int averageEngagement;
    private int averageTechAcc;
    private int confidenceScore;
    private int cognitionScore;
    private int wellnessScore;
    private int productivityScore;
    private int empowermentScore;


    private string userDataPath;


    private void Awake()
    {
        userDataPath = Path.Combine(Application.persistentDataPath, "Users", UserSession.Instance.CurrentUser);
    }

    private void Start()
    {
        CalculateEmotionCounts();
        CalculateWellnessScore();
        
        //game1HighscoreButton.onClick.AddListener(DisplayGame1Highscore);
        //game2HighscoreButton.onClick.AddListener(DisplayGame2Highscore);
        //game1AverageScoreButton.onClick.AddListener(DisplayGame1AverageScore);
        //game2AverageScoreButton.onClick.AddListener(DisplayGame2AverageScore);
        //memoryAverageButton.onClick.AddListener(DisplayMemoryAverage);
        //processingAverageButton.onClick.AddListener(DisplayProcessingAverage);
        //attentionAverageButton.onClick.AddListener(DisplayAttentionAverage);
    }

    public void DisplayWhackMonsterHighscore()
    {
        string csvFilePath = Path.Combine(userDataPath, "WhackMonster.csv");
        int maxScore = GetMaxScore(csvFilePath);
        WhackMonsterHighscoreValue.text = maxScore.ToString();
    }

    public void DisplayShipyardHighscore()
    {
        string csvFilePath = Path.Combine(userDataPath, "Shipyard.csv");
        int maxScore = GetMaxScore(csvFilePath);
        ShipyardHighscoreValue.text = maxScore.ToString();
    }

    private int GetMaxScore(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int maxScore = lines.Skip(1) // Skip header line
                                 .Select(line => int.Parse(line.Split(',')[1])) // Get second column (highscore)
                                 .Max(); // Find maximum score

            return maxScore;
        }
        else
        {
            Debug.LogWarning("File does not exist: " + filePath);
            return 0;
        }
    }

    public void DisplayWhackMonsterAverageScore()
    {
        string csvFilePath = Path.Combine(userDataPath, "WhackMonster.csv");
        double avgScore = GetAverageColumn(csvFilePath, 1); // 1 is the column index for session score
        WhackMosterAverageScoreValue.text = avgScore.ToString();
        

    }

    public void DisplayShipyardAverageScore()
    {
        string csvFilePath = Path.Combine(userDataPath, "Shipyard.csv");
        double avgScore = GetAverageColumn(csvFilePath, 1); // 1 is the column index for session score
        avgScore = Mathf.Round((float)(avgScore * 100)) / 100f;
        ShipyardAverageScoreValue.text = avgScore.ToString();
    }

    public void DisplayMemoryAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "Shipyard.csv"); // Memory is in game 1 data
        double avgMemory = GetAverageColumn(csvFilePath, 2); // 2 is the column index for memory
        avgMemory = (avgMemory / 3) * 100;
        averageMemory = (int)avgMemory;
        memoryAverageValue.text = $"{averageMemory}%";
        averageMemoryImg.fillAmount = (float)avgMemory/100;
    }

    public void DisplayProcessingAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "Shipyard.csv"); // Processing is in game 1 data
        double avgProcessing = GetAverageColumn(csvFilePath, 3); // 3 is the column index for processing
        averageProcessing = (int)avgProcessing;
        processingAverageValue.text = $"{averageProcessing}%";
        averageProcessingImg.fillAmount = (float)avgProcessing / 100;

    }

    public void DisplayAttentionAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "WhackMonster.csv"); // Attention is in game 2 data
        double avgAttention = GetAverageColumn(csvFilePath, 2); // 2 is the column index for attention
        averageAttention = (int)avgAttention;
        attentionAverageValue.text = $"{averageAttention}%";
        averageAttentionImg.fillAmount = (float)avgAttention / 100;
    }


    public void DisplayAngryAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "Meditation.csv");
        double avgAngry = GetAverageColumn(csvFilePath, 1);
        angryImg.fillAmount = (float)avgAngry;
        avgAngry = avgAngry * 100;
        angryAverageValue.text = $"{(int)avgAngry}%";

    }

    public void DisplayUpsetAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "Meditation.csv");
        double avgUpset = GetAverageColumn(csvFilePath, 2);
        upsetImg.fillAmount = (float)avgUpset;
        avgUpset = avgUpset * 100;
        upsetAverageValue.text = $"{(int)avgUpset}%";

    }

    public void DisplaySadAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "Meditation.csv");
        double avgSad = GetAverageColumn(csvFilePath, 3);
        sadImg.fillAmount = (float)avgSad;
        avgSad = avgSad * 100;
        sadAverageValue.text = $"{(int)avgSad}%";

    }

    public void DisplayGoodAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "Meditation.csv");
        double avgGood = GetAverageColumn(csvFilePath, 4);
        goodImg.fillAmount = (float)avgGood;
        avgGood = avgGood * 100;
        goodAverageValue.text = $"{(int)avgGood}%";

    }

    public void DisplayHappyAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "Meditation.csv");
        double avgHappy = GetAverageColumn(csvFilePath, 5);
        happyImg.fillAmount = (float)avgHappy;
        avgHappy = avgHappy * 100;
        happyAverageValue.text = $"{(int)avgHappy}%";

    }

    public void DisplaySpectacularAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "Meditation.csv");
        double avgSpectacular = GetAverageColumn(csvFilePath, 6);
        spectacularImg.fillAmount = (float)avgSpectacular;
        avgSpectacular = avgSpectacular * 100;
        spectacularAverageValue.text = $"{(int)avgSpectacular}%";

    }

    public void DisplayRelevanceAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "MeetingGPT.csv");
        double avgRelevance = GetAverageColumn(csvFilePath, 1);
        averageRelevance = (int)avgRelevance;
        relevanceValue.text = averageRelevance.ToString();
        relevanceImg.fillAmount = (float)avgRelevance / 100;


    }

    public void DisplayCoherenceAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "MeetingGPT.csv");
        double avgCoherence = GetAverageColumn(csvFilePath, 2);
        averageCoherence = (int)avgCoherence;
        coherenceValue.text = averageCoherence.ToString();
        coherenceImg.fillAmount = (float)avgCoherence / 100;

    }

    public void DisplayEngagementAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "MeetingGPT.csv");
        double avgEngagement = GetAverageColumn(csvFilePath, 3);
        averageEngagement = (int)avgEngagement;
        engagementValue.text = averageEngagement.ToString();
        engagementImg.fillAmount = (float)avgEngagement / 100;

    }

    public void DisplayTechAccAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "MeetingGPT.csv");
        double avgTechAcc = GetAverageColumn(csvFilePath, 4);
        averageTechAcc = (int)avgTechAcc;
        techAccValue.text = averageTechAcc.ToString();
        techAccImg.fillAmount = (float)avgTechAcc / 100;

    }

    public void DisplayWPMAverage()
    {
        string csvFilePath = Path.Combine(userDataPath, "MeetingGPT.csv");
        double avgWPM = GetAverageColumn(csvFilePath, 5);
        avgWPM = (int)avgWPM;
        WPMValue.text = avgWPM.ToString();


    }


    public void DisplayOverallScores()
    {
        confidenceScore = (int)((averageRelevance + averageCoherence + averageEngagement + averageTechAcc) / 4);
        confidenceValue.text = $"{confidenceScore}%";

        cognitionScore = (int)((averageAttention + averageProcessing + averageMemory) / 3);
        cogntionValue.text = $"{cognitionScore}%";

        productivityScore = (cognitionScore + confidenceScore) / 2;
        producitivityValue.text = $"{(int)productivityScore}%";
        productivityImg.fillAmount = (float)productivityScore / 100;

        empowermentScore = (productivityScore + wellnessScore)/2;
        empowermentValue.text = $"{(int)empowermentScore}%";
        empowermentImg.fillAmount = (float)empowermentScore / 100;
    }


    private double GetAverageColumn(string filePath, int columnIndex)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            double avgValue = lines.Skip(1) // Skip header line
                                   .Select(line => double.Parse(line.Split(',')[columnIndex])) // Get specified column
                                   .Average(); // Calculate average
            return avgValue;
        }
        else
        {
            Debug.LogWarning("File does not exist: " + filePath);
            return 0;
        }

    }


    

    void CalculateEmotionCounts()
    {
        // Initialize the emotion counts dictionary
        emotionCounts = new Dictionary<Emotion, int>();
        foreach (Emotion emotion in System.Enum.GetValues(typeof(Emotion)))
        {
            emotionCounts.Add(emotion, 0);
        }

        string csvFilePath = Path.Combine(userDataPath, "Meditation.csv");
        // Read the CSV file
        string[] lines = File.ReadAllLines(csvFilePath);

        // Extract the emotion labels from the header row
        string[] header = lines[0].Split(',');
        Emotion[] emotionLabels = new Emotion[header.Length - 1];

        for (int i = 1; i < header.Length; i++)
        {
            Emotion emotionLabel;
            if (System.Enum.TryParse(header[i], out emotionLabel))
            {
                emotionLabels[i - 1] = emotionLabel;
            }
            else
            {
                Debug.LogError("Invalid emotion label: " + header[i]);
                return;
            }
        }

        // Iterate through each line of the CSV file
        for (int i = 1; i < lines.Length; i++) // Start from index 1 to skip the header
        {
            string[] data = lines[i].Split(',');

            // Extract the selected emotion from the remaining columns
            for (int j = 1; j < data.Length; j++)
            {
                int selectedEmotion;
                if (int.TryParse(data[j], out selectedEmotion))
                {
                    // Check if the emotion is selected (value = 1)
                    if (selectedEmotion == 1)
                    {
                        // Increment the count of the emotion
                        Emotion emotionLabel = emotionLabels[j - 1];
                        if (emotionCounts.ContainsKey(emotionLabel))
                        {
                            emotionCounts[emotionLabel]++;
                        }
                    }
                }
            }
        }

        // Display the emotion counts
        foreach (Emotion emotion in emotionCounts.Keys)
        {
            int count = emotionCounts[emotion];
            Debug.Log(emotion.ToString() + " count: " + count);
        }
    }

    void CalculateWellnessScore()
    {
        int cumulativeScore = 0;
        int maxPossibleCumulativeScore = 0;

        // Calculate the cumulative score and maximum possible cumulative score
        foreach (Emotion emotion in emotionCounts.Keys)
        {
            int count = emotionCounts[emotion];
            int weight = emotionWeights[emotion];
            cumulativeScore += (count * weight);
            maxPossibleCumulativeScore += count * 3;
        }

        // Calculate the wellness percentage
        float wellnessPercentage_unScaled = (float)cumulativeScore / maxPossibleCumulativeScore * 100f;
        float wellnessPercentage = (wellnessPercentage_unScaled + 100) / 2f;
        // Display the wellness percentage
        Debug.Log("Wellness Percentage: " + wellnessPercentage);
        wellnessScore = (int)wellnessPercentage;
        wellnessValue.text = $"{wellnessScore}%";
        wellnessImg.fillAmount = (wellnessPercentage / 100);
    }




        //private double GetLastScoreColumn(string filePath, int columnIndex)
        //{
        //    if (File.Exists(filePath))
        //    {
        //        string[] lines = File.ReadAllLines(filePath);
        //        double avgValue = lines.Skip(1) // Skip header line
        //                               .Select(line => double.Parse(line.Split(',')[columnIndex])) // Get specified column
        //                               .Average(); // Calculate average
        //        return avgValue;
        //    }
        //    else
        //    {
        //        Debug.LogWarning("File does not exist: " + filePath);
        //        return 0;
        //    }
        //}

        //private void OnDestroy()
        //{
        //    game1HighscoreButton.onClick.RemoveListener(DisplayGame1Highscore);
        //    game2HighscoreButton.onClick.RemoveListener(DisplayGame2Highscore);
        //    game1AverageScoreButton.onClick.RemoveListener(DisplayGame1AverageScore);
        //    game2AverageScoreButton.onClick.RemoveListener(DisplayGame2AverageScore);
        //    memoryAverageButton.onClick.RemoveListener(DisplayMemoryAverage);
        //    processingAverageButton.onClick.RemoveListener(DisplayProcessingAverage);
        //    attentionAverageButton.onClick.RemoveListener(DisplayAttentionAverage);
        //}
    }
