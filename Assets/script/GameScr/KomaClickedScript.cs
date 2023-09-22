using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaClickedScript : MonoBehaviour
{
    GameObject LongGameContObj;
    GameObject ShortGameContObj;
    GameObject TTContObj;


    GameObject KomaClassObj;
    // Start is called before the first frame update
    void Start()
    {
        TTContObj = GameObject.Find("ContPlayTimeObj");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void komaClicked()
    {
        if (TTContObj.GetComponent<ContPlayTimeTurn>().gt == 9)
        {
            LongGameContObj = GameObject.Find("LongGameContObj");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (LongGameContObj.GetComponent<LongGameCont>().tempGameObj[i, j] == this.gameObject) { LongGameContObj.GetComponent<LongGameCont>().findKoma(i, j); return; }
                }
            }
            if (LongGameContObj.GetComponent<LongGameCont>().player1sideHaveObj == this.gameObject) { LongGameContObj.GetComponent<LongGameCont>().shougiPutKoma(1000); }
            else if (LongGameContObj.GetComponent<LongGameCont>().player2sideHaveObj == this.gameObject) { LongGameContObj.GetComponent<LongGameCont>().shougiPutKoma(-1000); }
        }
        else if (TTContObj.GetComponent<ContPlayTimeTurn>().gt == 6)
        {
            ShortGameContObj = GameObject.Find("ShortGameContObj");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (ShortGameContObj.GetComponent<ShortGameCont>().tempGameObj[i, j] == this.gameObject) { ShortGameContObj.GetComponent<ShortGameCont>().findKoma(i, j); return; }
                }
            }
            if (ShortGameContObj.GetComponent<ShortGameCont>().player1sideHaveObj == this.gameObject) { ShortGameContObj.GetComponent<ShortGameCont>().shougiPutKoma(1000); }
            else if (ShortGameContObj.GetComponent<ShortGameCont>().player2sideHaveObj == this.gameObject) { ShortGameContObj.GetComponent<ShortGameCont>().shougiPutKoma(-1000); }
        }


    }
}
