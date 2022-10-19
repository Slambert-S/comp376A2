using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atomicParameter : MonoBehaviour
{
    // Start is called before the first frame update
    public int goonSpeed;
    public float spownSpeed;
    public int nbGoon;
    public int lifespan;
    private lvlManager refLvlManager;
    private multiPlayerSetUp refMultiPlayeSetUp;

    void Start()
    {
        refLvlManager = this.GetComponent<lvlManager>();
        refMultiPlayeSetUp = this.GetComponent<multiPlayerSetUp>();
        setStatLvl();
    }

    private void setStatLvl()
    {
        if(stateLevelController.loadedLvl == 1)
        {
            if(stateLevelController.nbPlayer == "single")
            {
                goonSpeed = 3;
                spownSpeed = 2;
                nbGoon = 40;
                lifespan = 10;
                refMultiPlayeSetUp.multiplayerUpdate();
                refLvlManager.begingLevel();
            }
            else if(stateLevelController.nbPlayer == "double")
            {
                goonSpeed = 3;
                spownSpeed = 2;
                nbGoon = 60;
                lifespan = 7;
                refMultiPlayeSetUp.multiplayerUpdate();
                refLvlManager.begingLevel();
            }

        }
        if (stateLevelController.loadedLvl == 2)
        {
            if (stateLevelController.nbPlayer == "single")
            {
                goonSpeed = 4;
                spownSpeed = 2;
                nbGoon = 40;
                lifespan = 4;
                refMultiPlayeSetUp.multiplayerUpdate();
                refLvlManager.begingLevel();
            }
            else if (stateLevelController.nbPlayer == "double")
            {
                goonSpeed = 5;
                spownSpeed = 2;
                nbGoon = 60;
                lifespan = 6;
                refMultiPlayeSetUp.multiplayerUpdate();
                refLvlManager.begingLevel();
            }

        }
    }
}
