using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiUpdate : MonoBehaviour
{

    public GameObject health;
    public GameObject live;
    public GameObject Score;

    public playerStatus playerStat;

    // Start is called before the first frame update
    void Start()
    {
        this.updateUi(playerStat.getHelth(), playerStat.getLive(), playerStat.getScore());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateUi( int health, int live, int Score)
    {
        this.health.GetComponent<Text>().text = "Health : " + health;
        this.live.GetComponent<Text>().text = "Lives : " + live;
        this.Score.GetComponent<Text>().text = "Score : " + Score;

    }
}
