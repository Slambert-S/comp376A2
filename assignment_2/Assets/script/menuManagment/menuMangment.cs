using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMangment : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadFirstLevel(string input)
    {
        stateLevelController.nbPlayer = input;
        stateLevelController.loadedLvl = 1;
        SceneManager.LoadScene("lvlOne");
        
    }

    public void loadSecondLevel()
    {
        stateLevelController.loadedLvl = 2;
        SceneManager.LoadScene("lvlTwo");
    }

    public void goToMenu()
    {
        stateLevelController.nbPlayer = "nada";
        stateLevelController.loadedLvl = 0;
        Time.timeScale = 1;
        stateLevelController.playerOneScore = 0;
        stateLevelController.playerTwoScore = 0;
        SceneManager.LoadScene("menu");

    }


    public void leaveGame()
    {
        Application.Quit();
    }

}
