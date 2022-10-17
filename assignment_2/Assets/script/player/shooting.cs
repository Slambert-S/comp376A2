using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public GameObject refProjectile;
    private int maxAmo = 1;
    private int currentAmo = 1;

    private int playerController;
    private playerStatus refPlayerStatus;
    // Start is called before the first frame update

    public Animator animator ;
    private GameObject amoSprite;

    void Start()
    {
        this.playerController =this.transform.GetComponentInParent<playerMouvment>().playerNumber;
        animator = this.transform.GetComponentInParent<Animator>();
        amoSprite = this.transform.parent.GetChild(0).gameObject;
        refPlayerStatus = this.transform.GetComponentInParent<playerStatus>();

    }

    // Update is called once per frame
    void Update()
    {
        //testing if the player have an amo avilable to shoot
        if (currentAmo > 0)
        {

            if(playerController == 1)
            {
                // Calling the function to create an amo an the required dirrection
                if (Input.GetKeyDown("w"))
                {
                    createProjectile(0);
                    changeAnimation(false);
                    
                }
                if (Input.GetKeyDown("q"))
                {
                    createProjectile(-1);
                    changeAnimation(false);
                }
                if (Input.GetKeyDown("e"))
                {
                    createProjectile(1);
                    changeAnimation(false);
                }
                
            }
            else if (playerController ==2)
            {
                // Calling the function to create an amo an the required dirrection
                if (Input.GetKeyDown("i"))
                {
                    createProjectile(0);
                    changeAnimation(false);
                }
                if (Input.GetKeyDown("u"))
                {
                    createProjectile(-1);
                    changeAnimation(false);
                }
                if (Input.GetKeyDown("o"))
                {
                    createProjectile(1);
                    changeAnimation(false);
                }
            }

            

        }
    }

    void createProjectile(int projectileDirection)
    {
        //if the player is NOT in the special mode remove the amo from the player
        
        if(refPlayerStatus.GetSpecialMode() != 1)
        {
            currentAmo = currentAmo - 1;

        }
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
            this.changeAnimation(true);
        }
    }

    private void changeAnimation(bool val)
    {
        
        amoSprite.SetActive(val);
        
        this.animator.SetBool("loaded", val);

        if(currentAmo > 0)
        {
            amoSprite.SetActive(true);

            this.animator.SetBool("loaded", true);

        }
    }
}
