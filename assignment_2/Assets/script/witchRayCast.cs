using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    private witchMouvment mouvmentScript;
    private int layerMask = 1 << 10;
    void Start()
    {
        mouvmentScript = this.GetComponent<witchMouvment>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) *1f, Color.red);
        RaycastHit2D hitTop = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up) , 1.5f, layerMask);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) *2.5f, Color.red);
        RaycastHit2D hitBottom = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down) , 2.5f, layerMask);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 1.5f, Color.red);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1.5f, layerMask);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 1.5f, Color.red);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1.5f, layerMask);


        if (hitTop)
        {
            mouvmentScript.swapY();
            Debug.Log("Hit : " + hitTop.collider.name);
        }

        if ( hitBottom)
        {
            mouvmentScript.swapY();
            Debug.Log("Hit : "+hitBottom.collider.name);

        }

        if (hitLeft || hitRight)
        {
            mouvmentScript.swapX();

        }

    }
}
