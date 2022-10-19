using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiPlayerSetUp : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerOneUi;
    public GameObject playerTwo;
    public GameObject playerTwoUi;
    // Start is called before the first frame update
    public void multiplayerUpdate()
    {
        //update the player score from the past level
        playerOne.GetComponent<playerStatus>().startLevelSetting(1);
     
        if(stateLevelController.nbPlayer == "double")
        {
            playerTwo.SetActive(true);
            playerTwoUi.SetActive(true);
            playerTwo.GetComponent<playerStatus>().startLevelSetting(2);
        }
        if (stateLevelController.nbPlayer == "single")
        {
            playerTwo.SetActive(false);
            playerTwoUi.SetActive(false);
        }
    }

    public List<GameObject> getPlayerList()
    {
        List<GameObject> listPlayer = new List<GameObject>();
        listPlayer.Add(playerOne);
        
        if (stateLevelController.nbPlayer == "double")
        {
            listPlayer.Add(playerTwo);

        }

        return listPlayer;

    }

    public void savePlayerScore()
    {

        stateLevelController.playerOneScore = playerOne.GetComponent<playerStatus>().getScore();

        if(stateLevelController.nbPlayer == "double")
        {
            stateLevelController.playerTwoScore = playerTwo.GetComponent<playerStatus>().getScore();    
        }

        Debug.Log("DEBUG : player score are saved");
    }
}
