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
    public int enemySpeed = 3;
    public float spownSpeed = 4.0f;

    void Start()
    {
        // Fill the list that will handle the spown rate for the 3 section
        for( int i = 0; i <= rateFront; i++)
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

        InvokeRepeating("createEnemy", 1.0f, spownSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createEnemy()
    {
        int spownRow = Random.Range(1, spownLuck.Count);
        GameObject newSpown = selectSpownPoint(spownRow);
        GameObject newEnemy =Instantiate(enemyRef);

        float newScale = setNewScale(spownRow); //find the scale of the object

        newEnemy.GetComponent<enemy_stat>().row = spownRow;
        newEnemy.GetComponent<enemy_stat>().speed = this.enemySpeed;

        Vector3 newZpos = setNewZPos(spownRow); // find the apropriate positions Z for the sprite
        newEnemy.transform.position = new Vector3(newSpown.transform.position.x,newSpown.transform.position.y,newZpos.z);
        newEnemy.transform.localScale = new Vector3(newScale, newScale, newScale);
        

    }

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
