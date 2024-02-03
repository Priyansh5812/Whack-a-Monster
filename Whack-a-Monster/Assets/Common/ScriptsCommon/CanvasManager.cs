using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private string canvasName;
    [SerializeField] private GameObject homeCanvas;
    [SerializeField] private GameObject meetingCanvas;
    [SerializeField] private GameObject gamesCanvas;
    [SerializeField] private GameObject meditationCanvas;
   


    private void Awake()
    {
        canvasName = PlayerPrefs.GetString("CanvasName");
        SetCanvasActive(canvasName);
    }

    private void SetCanvasActive(string canvas)
    {
        switch (canvas)
        {
            case "Home":
                {
                    homeCanvas.gameObject.SetActive(true);
                    meetingCanvas.gameObject.SetActive(false);
                    gamesCanvas.gameObject.SetActive(false);
                    meditationCanvas.gameObject.SetActive(false);
                    break;
                }

            case "Meeting":
                {
                    homeCanvas.gameObject.SetActive(false);
                    meetingCanvas.gameObject.SetActive(true);
                    gamesCanvas.gameObject.SetActive(false);
                    meditationCanvas.gameObject.SetActive(false);
                    break;
                }

            case "Game":
                {
                    homeCanvas.gameObject.SetActive(false);
                    meetingCanvas.gameObject.SetActive(false);
                    gamesCanvas.gameObject.SetActive(true);
                    meditationCanvas.gameObject.SetActive(false);
                    break;
                }

            case "Meditation":
                {
                    homeCanvas.gameObject.SetActive(false);
                    meetingCanvas.gameObject.SetActive(false);
                    gamesCanvas.gameObject.SetActive(false);
                    meditationCanvas.gameObject.SetActive(true);
                    break;
                }

           

        }
    }
}
