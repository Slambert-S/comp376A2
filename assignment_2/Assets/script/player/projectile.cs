using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update

    public int direction = 0;
    public int bulletSpeed = 5;
    public int lostHpValue = 2;

    private GameObject belongTo;
    private playerStatus playerStatus;

    public AudioSource splash;

    void Start()
    {
        lostHpValue = 50;
        splash = GameObject.Find("splash").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletMove();
    }

    void bulletMove()
    {
        this.transform.position = this.transform.position + new Vector3(direction, 1, 0) * bulletSpeed * Time.deltaTime;
    } 

    //Called by player to give the direction of the bullet 
     public void setDirection(int givenDirection)
    {
        this.direction = givenDirection;
    }

    public void setBelongTo(GameObject owner)
    {
        this.belongTo = owner; // set the object who handle projectile
        this.playerStatus = this.belongTo.transform.parent.gameObject.GetComponent<playerStatus>(); // Get the player status  affiliated to the projectile
    }

    void OnTriggerEnter2D(Collider2D theCollision)
    {
        if (theCollision.gameObject.tag == "border")
        {
            //To-do 
            //all function to refresh player shot animation
            this.removeAmo();
            //check if the player special mode is active
            if(playerStatus.GetSpecialMode() == 1)
            {
                this.playerStatus.setHp((lostHpValue / 2), false);
            }
            else
            {
                this.playerStatus.setHp((lostHpValue), false);
            }
            //Debug.Log("bullet reach the border");

        }
        else if(theCollision.gameObject.tag == "enemy")
        {
            splash.Play();
            int point = theCollision.GetComponent<enemy_stat>().getRow();

            //Handeling the ray-cast to detect if multiple enemy overlaps 
            //First disable self Box collider to not triger the raycast, 
            // check for a collision of raycast
            //Re-activate the collider
            theCollision.GetComponent<BoxCollider2D>().enabled = false;
            bool enemyCollsion = theCollision.GetComponent<goonRaycast>().checkforEnemy();
            theCollision.GetComponent<BoxCollider2D>().enabled = true;
            
            //Debug.Log(enemyCollsion);
            if (enemyCollsion)
            {
                if(playerStatus.GetSpecialMode() == 1)
                {
                    this.playerStatus.increaseScore(1 + 5);
                }
                else
                {
                    this.playerStatus.increaseScore(point + 5);
                }
            }
            else
            {
                if(playerStatus.GetSpecialMode()== 1)
                {
                    this.playerStatus.increaseScore(1);
                }
                this.playerStatus.increaseScore(point);
            }
            Destroy(theCollision.gameObject);
            this.removeAmo();

            

        }
        else if (theCollision.gameObject.tag == "witch")
        {
            splash.Play();
            theCollision.gameObject.GetComponent<witchStatTraking>().hitOnWitch(playerStatus);
            this.removeAmo();

        }
        else if (theCollision.gameObject.tag == "mj")
        {
            
            splash.Play();
            theCollision.gameObject.GetComponent<mJ>().hitBoss(belongTo);
            this.removeAmo();

        }
        else if (theCollision.gameObject.tag == "turnip")
        {
            splash.Play();
            theCollision.gameObject.GetComponent<turnip>().hitBoss(belongTo);
            this.removeAmo();

        }




    }

    private void removeAmo()
    {
        Destroy(this.gameObject);
        this.belongTo.GetComponent<shooting>().reloadProjectile();

    }

}
