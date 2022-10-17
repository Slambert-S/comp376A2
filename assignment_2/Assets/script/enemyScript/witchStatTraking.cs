using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchStatTraking : MonoBehaviour
{
    // Start is called before the first frame update
    public int life = 5;
    public int scoreValue = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitOnWitch(playerStatus refPlayer)
    {
        this.life--;
        if(this.life == 0)
        {
            refPlayer.increaseScore(scoreValue);
            Destroy(this.gameObject);
        }
    }
}
