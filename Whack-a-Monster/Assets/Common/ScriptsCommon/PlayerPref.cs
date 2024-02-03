using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
  public void SetPlayerPrefs(string canvas)
    {
        PlayerPrefs.SetString("CanvasName", canvas);
    }
}
