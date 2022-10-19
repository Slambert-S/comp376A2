using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlManager : MonoBehaviour
{
    // Containe the parent object to refer to all the  spown point 
    public GameObject frontSpownPoint;
    public GameObject backSpownPoint;
    public GameObject middleSpownPoint;
    public int rateFront;
    public int rateMidle;
    public int rateBack;
    private List<int> spownLuck = new List<int>();

    public GameObject enemyRef;
    public GameObject witchRef;

    //variable related to the goon
    private int lifeTime = 6;
    private int enemySpeed = 3;
    private float spownSpeed = 4.0f;
    public AudioSource goonSound;
    //variable related to the game life time
    public int gameLenght = 300;
    private int nbGoon = 20;

    //variable related to the boss
    public GameObject bossRef;
    private bool bossSpownTraker = false;

    // Variable related to the witch
    private int nbWitch =0;
    private float firstWitchTime =0;
    private float secondaryWitchTime = 0;
    public AudioSource witchSound;


    private atomicParameter AtomPar;


    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void begingLevel()
    {
        //set the atomic parameter for the level  and multiPLayer mode
        AtomPar = this.gameObject.GetComponent<atomicParameter>();
        this.enemySpeed = AtomPar.goonSpeed;
        this.spownSpeed = AtomPar.spownSpeed;
        this.nbGoon = AtomPar.nbGoon;
        this.lifeTime = AtomPar.lifespan;

        // Fill the list that will handle the spown rate for the 3 section
        for (int i = 0; i <= rateFront; i++)
        {
            spownLuck.Add(1);
        }
        for (int i = 0; i <= rateMidle; i++)
        {
            spownLuck.Add(2);
        }

        for (int i = 0; i <= rateBack; i++)
        {
            spownLuck.Add(3);
        }


        //invoke goon
        
        if (stateLevelController.nbPlayer == "double") 
        {
            InvokeRepeating("createEnemy", 1.0f, spownSpeed);
            InvokeRepeating("createEnemy", 1.0f, spownSpeed);

        }
        else
        {
            InvokeRepeating("createEnemy", 1.0f, spownSpeed);

        }
        //get the first witch time spown
        firstWitchTime = Random.Range(15.0f, 45.0f);

        //Second witch time
        secondaryWitchTime = Random.Range(15.0f, 30.0f);
        //handle the creation of the witch
        InvokeRepeating("createWitch", firstWitchTime, secondaryWitchTime);
    }

    private void createEnemy()
    {

        if(nbGoon > 0)
        {
            int spownRow = Random.Range(1, spownLuck.Count); //selectc from all the possible row
            GameObject newSpown = selectSpownPoint(spownRow); //get a random spown point from the selected row
            GameObject newEnemy = Instantiate(enemyRef);

            float newScale = setNewScale(spownRow); //find the scale of the object

            newEnemy.GetComponent<enemy_stat>().row = spownRow;
            newEnemy.GetComponent<enemy_stat>().speed = this.enemySpeed;

            newEnemy.GetComponent<despownAfterTime>().setLifeTime(this.lifeTime); //set the lifeTime of the goon
            newEnemy.GetComponent<despownAfterTime>().startLifeSpan(); //start the life span of the goon


            Vector3 newZpos = setNewZPos(spownRow); // find the apropriate positions Z for the sprite
            newEnemy.transform.position = new Vector3(newSpown.transform.position.x, newSpown.transform.position.y, newZpos.z);
            newEnemy.transform.localScale = new Vector3(newScale, newScale, newScale);
            goonSound.Play();

            nbGoon--;
        }
        if(nbGoon <= 10 && bossSpownTraker == false)
        {
            bossRef.SetActive(true);
            createWitch();
            bossSpownTraker = true;
        }

    }

    private void createWitch()
    {

        int spownRow = Random.Range(1, spownLuck.Count);
        GameObject newSpown = selectSpownPoint(spownRow);
        GameObject newEnemy = Instantiate(witchRef);
        newEnemy.GetComponent<despownAfterTime>().startLifeSpan();
        Vector3 newZpos = setNewZPos(spownRow); // find the apropriate positions Z for the sprite
        newEnemy.transform.position = new Vector3(newSpown.transform.position.x, newSpown.transform.position.y, newZpos.z);

        nbWitch++;
        witchSound.Play();
        Debug.Log("Witch spown");
    }

    //return a random spown point from the row selected , the object is used as a reference to place the new enemy
    private GameObject selectSpownPoint(int row)
    {
        if(row == 1)
        {
            int childNUmber = frontSpownPoint.transform.childCount;
            int randomSelect = Random.Range(0, childNUmber);
            return frontSpownPoint.transform.GetChild(randomSelect).gameObject;
        }
        else if (row == 2)
        {
            int childNUmber = middleSpownPoint.transform.childCount;
            int randomSelect = Random.Range(0, childNUmber);
            return middleSpownPoint.transform.GetChild(randomSelect).gameObject;
        }
        else if (row == 3)
        {
            int childNUmber = backSpownPoint.transform.childCount;
            int randomSelect = Random.Range(0, childNUmber);
            return backSpownPoint.transform.GetChild(randomSelect).gameObject;
        }
        return frontSpownPoint.transform.GetChild(0).gameObject;
    }

    private float setNewScale(int row)
    {
        float newScale = 1.0f;
        if (row == 1)
        {
           newScale = 1.0f;
        }
        else if (row == 2)
        {
            newScale = 0.75f;
        }
        else if (row == 3)
        {
            newScale = 0.5f;
        }
        return newScale;
    }

    private Vector3 setNewZPos(int row)
    {
        Vector3 newZPoss = new Vector3(0,0,-7);
        if (row == 1)
        {
            newZPoss.z = -7;
        }
        else if (row == 2)
        {
            newZPoss.z = -5;
        }
        else if (row == 3)
        {
            newZPoss.z = -3;
        }
        return newZPoss;
    }
}
