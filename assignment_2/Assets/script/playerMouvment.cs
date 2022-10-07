using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMouvment : MonoBehaviour
{
    private Rigidbody2D rb2D;
  

    private int xDirection = 0; // -1 left is pressed, 1 right is pressed
    private bool isGrounded = true;
    public float moveSpeed = 5;
    public int jumpForce = 3;

    //Boolean for sprite animation
    private bool mMoving;
    private bool mGrounded;
    private bool mFalling;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    
    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name == "ground")
        {
            isGrounded = true;
            
        }
       
    }

    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name == "ground")
        {
            isGrounded = false;

          
        }
        
    }


    private void MoveCharacter()
    {

        if (Input.GetKey("a"))
        {
            xDirection = -1;
        }
        else if (Input.GetKey("d"))
        {
            xDirection = 1;
        }

        if(xDirection != 0)
        {
            transform.Translate(xDirection * moveSpeed * Time.deltaTime, 0, 0);
        }
        xDirection = 0;

        //if (mGrounded && Input.GetButtonDown("Jump"))
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            int i = 10;
            int y =  5;

            Debug.Log(i + y);


        }

    }
}
