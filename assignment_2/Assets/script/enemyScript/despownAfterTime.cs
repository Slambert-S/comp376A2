using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despownAfterTime : MonoBehaviour
{
    public int lifeTime ;
    void Start()
    {
        
    }

    public void setLifeTime(int time)
    {
        this.lifeTime = time;
    }

    public void startLifeSpan()
    {
        StartCoroutine(lifeSpan());
    }

    // Update is called once per frame
    IEnumerator lifeSpan()
    {
      
        yield return new WaitForSeconds(lifeTime);
        List<GameObject> listPLayer =  GameObject.Find("GameHandler").GetComponent<multiPlayerSetUp>().getPlayerList();
        foreach(GameObject player in listPLayer)
        {
            player.GetComponent<playerStatus>().setHp(10, false);
        }
        Destroy(gameObject);
    }
}
