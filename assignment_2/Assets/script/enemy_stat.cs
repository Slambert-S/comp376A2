using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_stat : MonoBehaviour
{
    public int row = 1; // use row to determine the point value of basic enemy 
    public int speed = 3;
    private float  direction = 0;
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
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

    }

    private void setNewDirection()
    {
        direction = Random.Range(-1.0f, 1.0f);
        if(direction > 0)
        {
            this.spriteHandler.flipX = true;
        }else
        {
            this.spriteHandler.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D theCollision)
    {
        //Handeling the enemy hitting the wall
        if (theCollision.gameObject.tag == "border")
        {
            float moveOfset = 0;
            // select the ofset to move the sprite
           if(direction < 0)
           {
                moveOfset = 0.2f;
           }
           else if(direction > 0)
           {
                moveOfset = -0.2f;
           }
           //Move the sprite to remove the collisions with the wall
            transform.position = new Vector3(transform.position.x+(moveOfset), transform.position.y, transform.position.z);
            // Stop the mouvment of the sprite 
            direction = (direction * 0);
            
        }
    }
}
