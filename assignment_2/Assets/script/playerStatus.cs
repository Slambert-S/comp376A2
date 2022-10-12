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

    public uiUpdate playerUi;

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
            if(playerhp > maxhp)    //check to make sure the amount of hp can not go over the maxHp
            {
                playerhp = 100;
            }
        }
        else
        {
            playerhp = playerhp - change;
            Debug.Log("life : " + this.playerLive + "   HP : " + this.playerhp);
            if(playerhp <= 0)
            {
                //to-do : call function to remove a life
                this.removelife();
                
            }
        }

        this.updateUI();
    }

    public void removelife()
    {
        this.playerLive = this.playerLive - 1;
        if(playerLive<= 0)
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
        if(this.playerLive != this.maxLive)
        {
            this.playerLive = this.playerLive + 1;
        }
        updateUI();
    }

    private void killPlayer()
    {
        Destroy(this.gameObject);
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

}
