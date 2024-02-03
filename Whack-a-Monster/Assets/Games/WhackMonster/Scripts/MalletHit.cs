using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MalletHit : MonoBehaviour
{
 
    public GameObject gameController;
    int score = 0;
    bool isHit;
    

    void Start()
    {
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
            Debug.Log(other.gameObject.tag);
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.transform.GetChild(0).transform.SetParent(null);
            Destroy(other.gameObject);
            isHit = true;
       

        if ((other.gameObject.tag == this.gameObject.tag) && (isHit))
        {
            isHit = false;
            GameControl.score += 10;
            gameController.GetComponent<GameControl>().numberOfCorrectHits += 1;
            gameController.GetComponent<GameControl>().numberOfHits += 1;


        }
        else if ((other.gameObject.tag != this.gameObject.tag) && (isHit))
        {
            isHit = false;
            GameControl.score -= 10;
            gameController.GetComponent<GameControl>().numberOfHits += 1;


        }
    }


  

}

