using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialMode : MonoBehaviour
{
    private playerStatus refPLayerStatus;
    private int playerController;

    // Start is called before the first frame update
    void Start()
    {
        refPLayerStatus = this.GetComponent<playerStatus>();
        playerController = this.GetComponent<playerMouvment>().playerNumber;
    }

    // Update is called once per frame
    void Update()
    {


        keySpecialMode();



    }

    private void keySpecialMode()
    {
        if(refPLayerStatus.GetSpecialMode() == 0)
        {

            if(playerController== 1)
            {
                if (Input.GetKeyDown("z"))
                {

                    refPLayerStatus.SetSpecialMode(1);
                    StartCoroutine(timeSpecialMode());
                }
            } 
            else if(playerController == 2)
            {
                if (Input.GetKeyDown("n"))
                {

                    refPLayerStatus.SetSpecialMode(1);
                    StartCoroutine(timeSpecialMode());
                }
            }

        }
    }

    private void setSpecialMode(int val)
    {
        refPLayerStatus.SetSpecialMode(val);
    }

    IEnumerator timeSpecialMode() // time the special mode for 3 second 
    {
        yield return new WaitForSeconds(3.0f);
        refPLayerStatus.SetSpecialMode(-1);

    }
}
