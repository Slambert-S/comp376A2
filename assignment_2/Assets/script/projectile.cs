using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update

    public int direction = 0;
    public int bulletSpeed = 5;

    private GameObject belongTo;
    private playerStatus playerStatus;

    void Start()
    {
        
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
            this.playerStatus.setHp(50, false);
            Debug.Log("bullet reach the border");

        }
        else if(theCollision.gameObject.tag == "enemy")
        {
            int point = theCollision.GetComponent<enemy_stat>().getRow();
            this.playerStatus.increaseScore(point);
            Destroy(theCollision.gameObject);
            this.removeAmo();

        }
        else if (theCollision.gameObject.tag == "witch")
        {
            theCollision.gameObject.GetComponent<witchStatTraking>().hitOnWitch(playerStatus);
            this.removeAmo();

        }

        Debug.Log("collisions");


    }

    private void removeAmo()
    {
        Destroy(this.gameObject);
        this.belongTo.GetComponent<shooting>().reloadProjectile();

    }

}
