using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mJ : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 0;
    private int direction = 0;
    public int bossHp = 30;

    //saving the number of hit made by each player
    private int playerOneHit = 0;
    private int playerTwoHit = 0;

    private SpriteRenderer spriteHandler;

    void Start()
    {
        InvokeRepeating("changePosition", 3.0f, 10.0f);
        InvokeRepeating("setNewDirection", 1.0f, 3.0f);
        spriteHandler = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();
    }


    private void enemyMove()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(direction * speed, 0, 0);

    }

    private void setNewDirection()
    {
        direction = Random.Range(-1, 1);
        updateSpriteOrientation();
    }

    void OnTriggerEnter2D(Collider2D theCollision)
    {
        //Handeling the enemy hitting the wall
        if (theCollision.gameObject.tag == "border")
        {

            swapX();

        }
    }

    private void updateSpriteOrientation()
    {
        if (direction > 0)
        {
            this.spriteHandler.flipX = true;
        }
        else
        {
            this.spriteHandler.flipX = false;
        }
    }
    public void swapX()
    {
        direction = (direction * -1);
        updateSpriteOrientation();
    }


    private void changePosition()
    {
        this.gameObject.GetComponent<randomPossition>().changePosition(this.gameObject);
    }

    public void hitBoss(GameObject refObj)
    {
        Debug.Log("Mj was hit");
        string refTag = refObj.transform.parent.tag;
        if (refTag == "playerOne")
        {
            playerOneHit++;
        }
        else if (refTag == "playerTwo")
        {
            playerTwoHit++;
        }
        bossHp--;
        if(bossHp <= 0)
        {
            refObj.transform.parent.GetComponent<playerStatus>().increaseScore(25);
            Destroy(this.gameObject);
            //to-do add code to change level
        }
    }
}
