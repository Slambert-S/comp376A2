using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    //initialising all player stat except bullet (managed in shooting script)
    public int maxhp = 100;
    private int playerhp = 100;
    public int maxLive = 3;
    private int playerLive = 3;
    public int playerScoor = 0;
    private int specialMode = 0; // tree way indicator , 0  = special mode available , 1 = special mode active, 2 = special mode used for this life. 

    public uiUpdate playerUi;
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // true = adition , false = substraction
    public void setHp(int change, bool operation)
    {
        if (operation)
        {
            playerhp = playerhp + change;
            if (playerhp > maxhp)    //check to make sure the amount of hp can not go over the maxHp
            {
                playerhp = 100;
            }
        }
        else
        {
            if(playerhp > 0)
            {
                animator.SetTrigger("popUp");
                playerhp = playerhp - change;
                Debug.Log("life : " + this.playerLive + "   HP : " + this.playerhp);
                if (playerhp <= 0)
                {

                    this.removelife();

                }
            }
            
        }

        this.updateUI();
    }

    public void removelife()
    {
        this.playerLive = this.playerLive - 1;
        if (playerLive <= 0)
        {
            //to-do: call function to kill player
            this.killPlayer();
        }
        else
        {
            this.playerhp = this.maxhp;
            Debug.Log("Player x lost a life");
        }

        updateUI();

    }

    public void addLife()
    {
        if (this.playerLive != this.maxLive)
        {
            this.playerLive = this.playerLive + 1;
        }
        updateUI();
    }

    private void killPlayer()
    {
        this.gameObject.SetActive(false);
        // to-do : call the required function for game over or multiplayer equivalent 
    }

    //function to increase the score
    public void increaseScore(int point)
    {
        this.playerScoor = this.playerScoor + point;
        updateUI();

    }

    private void updateUI()
    {
        playerUi.updateUi(this.playerhp, this.playerLive, this.playerScoor);
    }

    public int getHelth()
    {
        return this.playerhp;
    }
    public int getLive()
    {
        return this.playerLive;
    }
    public int getScore()
    {
        return this.playerScoor;
    }
    public void SetSpecialMode(int value)
    {
        this.specialMode = value;
            
    }
    public int GetSpecialMode()
    {
        return this.specialMode;
    }

    public void continueGame(){
        this.playerLive = this.maxLive;
        this.playerhp = this.maxhp;
        this.gameObject.SetActive(true);
        this.SetSpecialMode(0);
        this.updateUI();
    }

    public void startLevelSetting(int player)
    {

        if(player == 1)
        {

            this.playerScoor = stateLevelController.playerOneScore;
        }
        if(player == 2)
        {
            this.playerScoor = stateLevelController.playerTwoScore;
        }
        this.updateUI();
    }
}
