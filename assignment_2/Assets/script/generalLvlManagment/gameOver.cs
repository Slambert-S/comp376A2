using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    private  int nbCOntinue = 3;
    public Text displayTimer;
    public GameObject gameOverScreen; //reference to the Game over UI
    public Button continueButton; //Reference to the continue button on the game over UI
    public Text playerOneScore;
    public Text playerTwoScore;
    private float startTimerTime;
    private float maxTime = 30.0f;
    private bool activeTimer = false;
    public GameObject playerOne;
    public GameObject playerTwo;
    private bool inPause = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(inPause);
        //Debug.Log(activeTimer);
        if (activeTimer)
        {
           
            float currentTime = Time.realtimeSinceStartup;
            currentTime += 0.5f;
            Debug.Log("DEBUG: Current time : "+currentTime.ToString() + "  Time since timer start : "+ startTimerTime.ToString());
            double b = System.Math.Round(currentTime - startTimerTime, 0);
            displayTimer.text = (maxTime - b).ToString();
            if(b>= maxTime)
            {
                //to-do swap continue with main menu button
                activeTimer = false;
                continueButton.gameObject.SetActive(false);
            }
        }
        if(!inPause)
        {
            if (stateLevelController.nbPlayer == "single")
            {
                //check if the single player is dead 
                if (playerOne.GetComponent<playerStatus>().getLive() <= 0)
                {
                    startGameOver();
                    playerOneScore.text = "Player one : " + playerOne.GetComponent<playerStatus>().getScore().ToString();
                }
            }
            else if (stateLevelController.nbPlayer == "double")
            {
                //check if both player are dead
                if (playerOne.GetComponent<playerStatus>().getLive() <= 0 && playerTwo.GetComponent<playerStatus>().getLive() <= 0)
                {
                    startGameOver();
                    playerOneScore.text = "Player One : " + playerOne.GetComponent<playerStatus>().getScore().ToString();
                    playerTwoScore.text = "Player Two : " + playerTwo.GetComponent<playerStatus>().getScore().ToString();
                }
            }

        }

    }

    public void startGameOver()
    {
        gameOverScreen.SetActive(true);
        inPause = true;
        Time.timeScale = 0;
        
        if(nbCOntinue <= 0)
        {
            // To-do add the function to display the main menu timer
            continueButton.gameObject.SetActive(false);


        }
        else
        {
            //Debug.Log("set new start time");
            startTimerTime = Time.realtimeSinceStartup;
            activeTimer = true;
        }
    }

    public void pressContinue()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.tag == "projectile")
            {
                Destroy(gameObj);
            }
        }
        nbCOntinue--;
        if(stateLevelController.nbPlayer == "single")
        {
            playerOne.GetComponent<playerStatus>().continueGame();
        }else if(stateLevelController.nbPlayer == "double")
        {
            playerOne.GetComponent<playerStatus>().continueGame();
            playerTwo.GetComponent<playerStatus>().continueGame();
        }
        Time.timeScale = 1;
        inPause = false;
        activeTimer = false;
        gameOverScreen.SetActive(false);

    }

    
}
