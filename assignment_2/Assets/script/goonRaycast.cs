using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goonRaycast : MonoBehaviour
{

    private enemy_stat enemyMove;
    private int layerMask = 1 << 11;
    // Start is called before the first frame update
    void Start()
    {
        enemyMove = this.GetComponent<enemy_stat>();
    }


    // Update is called once per frame
    void Update()
    {


     
    }

    public bool checkforEnemy()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 0.5f, Color.red);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 0.5f, layerMask);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 0.5f, Color.red);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 0.5f, layerMask);
        if (hitLeft )
        {
            if(hitLeft.collider.tag== "enemy")
            {
                Destroy(hitLeft.collider.gameObject);
                return true;
            }
            Debug.Log("Debug : "+hitLeft.collider.tag);
           // Destroy(hitLeft.collider.gameObject);

        }
        else
        if (hitRight)
        {
            if (hitRight.collider.tag == "enemy")
            {
                Destroy(hitRight.collider.gameObject);
                return true;
            }
            Debug.Log("Debug : "+hitRight.collider.tag);
            //Destroy(hitRight.collider.gameObject);
        }

        return false;

    }
}
