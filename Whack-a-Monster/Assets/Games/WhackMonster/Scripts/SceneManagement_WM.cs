using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement_WM : MonoBehaviour
{
    public void SceneChange(int num)
    {
        switch (num)
        {

            case 0:
                {
                    SceneManager.LoadScene("0PlayGame");
                    break;
                }
            case 1:
                {
                    SceneManager.LoadScene("1Game");
                    break;
                }
            
            case 2:
                {
                    Application.Quit();
                    break;
                }



        }
    }
}