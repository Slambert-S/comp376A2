using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showFinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scorePlayerOne;
    public Text scorePlayerTwo;
    
    public void updatefinalScore()
    {
        scorePlayerOne.text = "Player One : " + stateLevelController.playerOneScore.ToString();
        if(stateLevelController.nbPlayer == "double")
        {
            scorePlayerTwo.text = "Player Two : " + stateLevelController.playerTwoScore.ToString();

        }
    }
}
