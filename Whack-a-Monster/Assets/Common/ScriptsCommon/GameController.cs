using System.IO;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public TMP_Text displayText;
    //public TMP_Text displayText1;
    //public Button whackMonsterButton;
    //public Button shipyardButton;
    //public Button logOutButton;
    //public Button nextSceneButton;

    private string userDataPath;

    private void Awake()
    {
        userDataPath = Path.Combine(Application.persistentDataPath, "Users", UserSession.Instance.CurrentUser);
    }

    private void Start()
    {

        // Add listeners to the buttons
        //whackMonsterButton.onClick.AddListener(OnWhackMonsterButtonPressed);
        //shipyardButton.onClick.AddListener(OnShipyardButtonPressed);
        //logOutButton.onClick.AddListener(OnLogOutButtonPressed);
        //nextSceneButton.onClick.AddListener(OnNextSceneButtonPressed);
    }

/*    public void OnShipyardButtonPressed()
    {
        string csvFilePath = Path.Combine(userDataPath, "Shipyard.csv");

        bool isNewFile = !File.Exists(csvFilePath);
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            if (isNewFile)
            {
                writer.WriteLine("Timestamp,Sessionscore,Memory,Processing");
            }

            int sessionscore = Scoring.score;
            float memory = Scoring.memoryScore;
            float processing = Scoring.accuracy;
            writer.WriteLine($"{DateTime.UtcNow},{sessionscore},{memory},{processing}");

            //displayText1.text = $"Game 1 - Sessionscore: {sessionscore}, Memory: {memory}, Processing: {processing}";
        }
    }*/

    public void OnWhackMonsterButtonPressed()
    {
        string csvFilePath = Path.Combine(userDataPath, "WhackMonster.csv");

        bool isNewFile = !File.Exists(csvFilePath);
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            if (isNewFile)
            {
                writer.WriteLine("Timestamp,Sessionscore,Attention");
            }

            int sessionscore = GameControl.score;
            float attention = GameControl.accuracy;
            writer.WriteLine($"{DateTime.UtcNow},{sessionscore},{attention}");

            //displayText.text = $"Game 2 - Sessionscore: {sessionscore}, Attention: {attention}";
        }
    }

/*    public void OnMeditationButtonPressed()
    {
        string csvFilePath = Path.Combine(userDataPath, "Meditation.csv");

        bool isNewFile = !File.Exists(csvFilePath);
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            if (isNewFile)
            {
                writer.WriteLine("Timestamp,Angry,Upset,Sad,Good,Happy,Spectacular");
            }

            int angry= MedFeedback.angryCount;
            int upset = MedFeedback.upsetCount;
            int sad = MedFeedback.sadCount;
            int good = MedFeedback.goodCount;
            int happy = MedFeedback.happyCount;
            int spectacular = MedFeedback.spectacularCount;
            writer.WriteLine($"{DateTime.UtcNow},{angry},{upset},{sad},{good},{happy},{spectacular}");

            //displayText.text = $"Game 2 - Sessionscore: {sessionscore}, Attention: {attention}";
        }
    }*/

/*    public void OnEndSessionBtnPressed()
    {
        string csvFilePath = Path.Combine(userDataPath, "MeetingGPT.csv");

        bool isNewFile = !File.Exists(csvFilePath);
        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            if (isNewFile)
            {
                writer.WriteLine("Timestamp,Relevance,Coherence,Engagement,TechnicalAccuracy,AverageWPM");
            }

            int relevance = OpenAI.AIManager.relevanceRating;
            int coherence = OpenAI.AIManager.coherenceRating;
            int engagement = OpenAI.AIManager.engagementRating;
            int techAcc = OpenAI.AIManager.technicalAccuracyRating;
            float avgWPM = OpenAI.AIManager.averageWPM;
            writer.WriteLine($"{DateTime.UtcNow},{relevance},{coherence},{engagement},{techAcc},{avgWPM}");

            //displayText.text = $"Game 2 - Sessionscore: {sessionscore}, Attention: {attention}";
        }

    }*/

    public void OnLogOutButtonPressed()
    {
        UserSession.Instance.LogoutUser();
        //SceneManager.LoadScene("UserAuth");
    }

    //public void OnNextSceneButtonPressed()
    //{
    //    SceneManager.LoadScene("DataViz");
    //}

    private void OnDestroy()
    {
        // Remove listeners when the GameObject is destroyed
        //whackMonsterButton.onClick.RemoveListener(OnWhackMonsterButtonPressed);
        //shipyardButton.onClick.RemoveListener(OnShipyardButtonPressed   );
        ////logOutButton.onClick.RemoveListener(OnLogOutButtonPressed);
        //nextSceneButton.onClick.RemoveListener(OnNextSceneButtonPressed);
    }
}
