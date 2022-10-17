using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPossition : MonoBehaviour
{
    //link to the spown possition
    public GameObject frontSpownPoint;
    public GameObject backSpownPoint;
    public GameObject middleSpownPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changePosition(GameObject refObject)
    {
        int row = GetRandomRow();
        GameObject newPoint = selectSpownPoint(row);
        
        float newScale = 1.0f;
        float newZposs = -7.0f;
        if (row == 1)
        {
            newScale = 1.0f;
            newZposs = -7.0f;
        }
        else if (row == 2)
        {
            newScale = 0.75f;
            newZposs = -5.0f;
        }
        else if (row == 3)
        {
            newScale = 0.5f;
            newZposs = -3.0f;
        }
        refObject.transform.position = new Vector3(newPoint.transform.position.x, newPoint.transform.position.y,newZposs);
        refObject.transform.localScale = new Vector3(newScale, newScale, newScale);

    }
    //Return an int corresponding to a specific row
    private int GetRandomRow()
    {
        return Random.Range(1, 3);
    }

    private GameObject selectSpownPoint(int row)
    {
        if (row == 1)
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
}
