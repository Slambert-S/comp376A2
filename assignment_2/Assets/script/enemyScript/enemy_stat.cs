using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_stat : MonoBehaviour
{
    public int row = 1; // use row to determine the point value of basic enemy 
    public int speed = 3;
    private int direction = 0;

    private SpriteRenderer spriteHandler;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("setNewDirection", 1.0f, 3.0f);
        spriteHandler = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();
    }

    public int getRow()
    {
        return this.row;
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

    public void swapX()
    {
        direction = (direction * -1);
        updateSpriteOrientation();
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
}
