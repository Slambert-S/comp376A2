using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public GameObject refProjectile;
    private int maxAmo = 1;
    private int currentAmo = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //testing if the player have an amo avilable to shoot
        if (currentAmo > 0)
        {

            
            // Calling the function to create an amo an the required dirrection
            if (Input.GetKeyDown("w"))
            {
                createProjectile(0);
            }
            if (Input.GetKeyDown("q"))
            {
                createProjectile(-1);
            }
            if (Input.GetKeyDown("e"))
            {
                createProjectile(1);
            }
        }
    }

    void createProjectile(int projectileDirection)
    {
        currentAmo = currentAmo - 1;
        GameObject curentProjectile = Instantiate(refProjectile);
        curentProjectile.GetComponent<projectile>().setDirection(projectileDirection);
        curentProjectile.GetComponent<projectile>().setBelongTo(this.gameObject);
        curentProjectile.transform.position = this.transform.position;
        Debug.Log("Pepiou");
    }

    public void reloadProjectile()
    {
        if(currentAmo < maxAmo)
        {
        this.currentAmo = this.currentAmo+1;
        }
    }
}
