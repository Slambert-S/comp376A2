using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class witchMouvment : MonoBehaviour
{

    private float xMove = 0;
    private float yMove = 0;
    public float speed = 3;

    // cooldown to prevent constant swap wen detecting the border of the stage
    private bool swapYCoolDown = false;
    private bool swapXCoolDown = false;

    private Vector3 mouvmentVector = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("setNewDirection", 1.0f, 3.0f);
       
    }

    // Update is called once per frame
    void Update()
    {
        mouveWitch();
    }

    private void mouveWitch()
    {
        this.gameObject.transform.Translate(mouvmentVector * speed * Time.deltaTime);
    }

    private void setNewDirection()
    {
        xMove = Random.Range(-1.0f, 1.0f);
        yMove = Random.Range(-1.0f, 1.0f);

        mouvmentVector.x = xMove;
        mouvmentVector.y = yMove;
        newFacingDirection();
        swapYCoolDown = false;
        swapXCoolDown = false; ;
    }

    private void newFacingDirection()
    {
        if (xMove > 0)
        {
            this.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }

    public void swapX()
    {
        if(swapXCoolDown == false)
        {
            mouvmentVector.x = (xMove * -1);
            swapXCoolDown = true;
            newFacingDirection();
            Debug.Log("swapX toggle");

        }
    }

    public void swapY()
    {
       
        if(swapYCoolDown == false)
        {
            mouvmentVector.y = (yMove * -1);
            swapYCoolDown = true;
            Debug.Log("swapY toggle");
        }
        
    }
}
