using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeLeft;
    public Text displayTimer;
    public GameObject gameHandler;
    void Start()
    {
        timeLeft = GameObject.Find("GameHandler").GetComponent<lvlManager>().gameLenght;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            
        }
        double b = System.Math.Round(timeLeft, 0);
        displayTimer.text = b.ToString();
        if(timeLeft <= 0)
        {
            // call action
            Debug.Log("End of game");
            //Game over screen
            gameHandler.GetComponent<gameOver>().timedGameOver();
        }
    }
}
