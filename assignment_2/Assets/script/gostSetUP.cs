using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gostSetUP : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        this.transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
