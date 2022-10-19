using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMouvment : MonoBehaviour
{
    private Rigidbody2D rb2D;
  

    private int xDirection = 0; // -1 left is pressed, 1 right is pressed
    private bool isGrounded = true;
    public float moveSpeed = 5;
    public int jumpForce = 1;
    public int playerNumber;
    public Animator animator;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


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

        if(playerNumber == 1)
        {

            if (Input.GetKey("a"))
            {
                xDirection = -1;
            }
            else if (Input.GetKey("d"))
            {
                xDirection = 1;
            }
            else if (Input.GetKey("c") && canDash)
            {
                StartCoroutine(Dash(-1));
            }
            else if (Input.GetKey("v") && canDash)
            {
                StartCoroutine(Dash(1));
            }


            if (xDirection != 0)
            {
                transform.Translate(xDirection * moveSpeed * Time.deltaTime, 0, 0);
            }
            xDirection = 0;
        }
        else if(playerNumber == 2)
        {

            if (Input.GetKey("j"))
            {
                xDirection = -1;
            }
            else if (Input.GetKey("l"))
            {
                xDirection = 1;

            }
            else if (Input.GetKey("y") && canDash)
            {
                StartCoroutine(Dash(-1));
            }
            else if (Input.GetKey("p") && canDash)
            {
                StartCoroutine(Dash(1));
            }

            if (xDirection != 0)
            {
                transform.Translate(xDirection * moveSpeed * Time.deltaTime, 0, 0);
            }
            xDirection = 0;

        }

        //if (mGrounded && Input.GetButtonDown("Jump"))
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        }

    }

    private IEnumerator Dash(int direction)
    {
        canDash = false;
        isDashing = true;
        rb2D.velocity = new Vector2(transform.localScale.x * direction * dashingPower, 0f);
        animator.SetTrigger("dash");
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
