using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despownAfterTime : MonoBehaviour
{
    public int lifeTime = 10;
    void Start()
    {
        StartCoroutine(lifeSpan());
    }

    // Update is called once per frame
    IEnumerator lifeSpan()
    {
      
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
