using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnip : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 0;
    private int direction = 0;
    public int bossHp = 30;

    //saving the number of hit made by each player
    private int playerOneHit = 0;
    private int playerTwoHit = 0;
    public GameObject sceneChanger;
    public GameObject gameHandler;
    public GameObject victoryScreen;
    

    private SpriteRenderer spriteHandler;

    void Start()
    {
        InvokeRepeating("changePosition", 3.0f, 3.0f);
        spriteHandler = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        swapX();
    }

    public void hitBoss(GameObject refObj)
    {
        Debug.Log("Turnip was hit");
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

        if (bossHp <= 0)
        {
            refObj.transform.parent.GetComponent<playerStatus>().increaseScore(25);
            gameHandler.GetComponent<multiPlayerSetUp>().savePlayerScore();
            victoryScreen.SetActive(true);
            victoryScreen.GetComponent<showFinalScore>().updatefinalScore();
            
            Debug.Log("Debug Boss is dead");
            Time.timeScale = 0;
            Destroy(this.gameObject);


        }
    }
}
