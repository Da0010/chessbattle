using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameBasisScr : MonoBehaviour
{
    public int p1DEType;
    public int p2DEType;
    public float p1DEColor;
    public float p2DEColor;

    [SerializeField] GameObject DEObj;

    [SerializeField] GameObject TTObj;
    [SerializeField] GameObject LGObj;
    [SerializeField] GameObject SGObj;
    [SerializeField] GameObject SoundObj;


    public GameObject getObjByNum(int n)
    {
        GameObject obj = null;

        if (n == 1) { obj = (GameObject)Resources.Load("PawnLight"); }
        else if (n == -1) { obj = (GameObject)Resources.Load("PawnDark"); }
        else if (n == 2) { obj = (GameObject)Resources.Load("RookLight"); }
        else if (n == -2) { obj = (GameObject)Resources.Load("RookDark"); }
        else if (n == 3) { obj = (GameObject)Resources.Load("KnightLight"); }
        else if (n == -3) { obj = (GameObject)Resources.Load("KnightDark"); }
        else if (n == 4) { obj = (GameObject)Resources.Load("BishopLight"); }
        else if (n == -4) { obj = (GameObject)Resources.Load("BishopDark"); }
        else if (n == 5) { obj = (GameObject)Resources.Load("QueenLight"); }
        else if (n == -5) { obj = (GameObject)Resources.Load("QueenDark"); }
        else if (n == 6) { obj = (GameObject)Resources.Load("KingLight"); }
        else if (n == -6) { obj = (GameObject)Resources.Load("KingDark"); }

        else if (n == 11) { obj = (GameObject)Resources.Load("shougiho"); }
        else if (n == -11) { obj = (GameObject)Resources.Load("shougiho"); }
        else if (n == 12) { obj = (GameObject)Resources.Load("shougikaku"); }
        else if (n == -12) { obj = (GameObject)Resources.Load("shougikaku"); }
        else if (n == 13) { obj = (GameObject)Resources.Load("shougihisha"); }
        else if (n == -13) { obj = (GameObject)Resources.Load("shougihisha"); }
        else if (n == 14) { obj = (GameObject)Resources.Load("shougikuruma"); }
        else if (n == -14) { obj = (GameObject)Resources.Load("shougikuruma"); }
        else if (n == 15) { obj = (GameObject)Resources.Load("shougiuma"); }
        else if (n == -15) { obj = (GameObject)Resources.Load("shougiuma"); }
        else if (n == 16) { obj = (GameObject)Resources.Load("shougigin"); }
        else if (n == -16) { obj = (GameObject)Resources.Load("shougigin"); }
        else if (n == 17) { obj = (GameObject)Resources.Load("shougikin"); }
        else if (n == -17) { obj = (GameObject)Resources.Load("shougikin"); }
        else if (n == 18) { obj = (GameObject)Resources.Load("shougiou2"); }
        else if (n == -18) { obj = (GameObject)Resources.Load("shougiou"); }

        else if (n == 21) { obj = (GameObject)Resources.Load("akahei"); }
        else if (n == -21) { obj = (GameObject)Resources.Load("kurohei"); }
        else if (n == 22) { obj = (GameObject)Resources.Load("akahou"); }
        else if (n == -22) { obj = (GameObject)Resources.Load("kurohou"); }
        else if (n == 23) { obj = (GameObject)Resources.Load("akakuruma"); }
        else if (n == -23) { obj = (GameObject)Resources.Load("kurokuruma"); }
        else if (n == 24) { obj = (GameObject)Resources.Load("akauma"); }
        else if (n == -24) { obj = (GameObject)Resources.Load("kurouma"); }
        else if (n == 25) { obj = (GameObject)Resources.Load("akasou"); }
        else if (n == -25) { obj = (GameObject)Resources.Load("kurosou"); }
        else if (n == 26) { obj = (GameObject)Resources.Load("akasi"); }
        else if (n == -26) { obj = (GameObject)Resources.Load("kurosi"); }
        else if (n == 27) { obj = (GameObject)Resources.Load("akashou"); }
        else if (n == -27) { obj = (GameObject)Resources.Load("kuroshou"); }

        else if (n == 31) { obj = (GameObject)Resources.Load("shougiho"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == -31) { obj = (GameObject)Resources.Load("shougiho"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == 32) { obj = (GameObject)Resources.Load("shougikaku"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == -32) { obj = (GameObject)Resources.Load("shougikaku"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == 33) { obj = (GameObject)Resources.Load("shougihisha"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == -33) { obj = (GameObject)Resources.Load("shougihisha"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == 34) { obj = (GameObject)Resources.Load("shougikuruma"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == -34) { obj = (GameObject)Resources.Load("shougikuruma"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == 35) { obj = (GameObject)Resources.Load("shougiuma"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == -35) { obj = (GameObject)Resources.Load("shougiuma"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == 36) { obj = (GameObject)Resources.Load("shougigin"); obj.transform.Rotate(0, 0, 180, Space.World); }
        else if (n == -36) { obj = (GameObject)Resources.Load("shougigin"); obj.transform.Rotate(0, 0, 180, Space.World); }

        return obj;
    }

    public void doEnd() 
    {
        if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 9) { LGObj.GetComponent<LongGameCont>().doEnd(); }
        else if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 6) { SGObj.GetComponent<ShortGameCont>().doEnd(); }
    }

    public void promoteShougiKoma() 
    {
        if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 9) { LGObj.GetComponent<LongGameCont>().promoteShougiKoma(); }
        else if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 6) { SGObj.GetComponent<ShortGameCont>().promoteShougiKoma(); }
    }

    public void pawnToKnight()
    {
        if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 9) { LGObj.GetComponent<LongGameCont>().PawnToKnight(); }
        else if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 6) { SGObj.GetComponent<ShortGameCont>().PawnToKnight(); }
    }
    public void pawnToBishop()
    {
        if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 9) { LGObj.GetComponent<LongGameCont>().PawnToBishop(); }
        else if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 6) { SGObj.GetComponent<ShortGameCont>().PawnToBishop(); }
    }

    public void pawnToRook()
    {
        if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 9) { LGObj.GetComponent<LongGameCont>().PawnToRook(); }
        else if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 6) { SGObj.GetComponent<ShortGameCont>().PawnToRook(); }
    }
    public void pawnToQueen()
    {
        if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 9) { LGObj.GetComponent<LongGameCont>().PawnToQueen(); }
        else if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 6) { SGObj.GetComponent<ShortGameCont>().PawnToQueen(); }
    }

    public void shougiNotKeepKoma()
    {
        if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 9) { LGObj.GetComponent<LongGameCont>().shougiNotKeepKoma(); }
        else if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 6) { SGObj.GetComponent<ShortGameCont>().shougiNotKeepKoma(); }
    }
    public void shougiKeepKoma()
    {
        if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 9) { LGObj.GetComponent<LongGameCont>().shougiKeepKoma(); }
        else if (TTObj.GetComponent<ContPlayTimeTurn>().gt == 6) { SGObj.GetComponent<ShortGameCont>().shougiKeepKoma(); }
    }



    public void ShowDE(GameObject DO,float timeInvoke,int pside) 
    {
        float tempColor = 0;
        int tempType = 0;
        if (pside == 1) { tempColor = p2DEColor; tempType = p2DEType; }
        else if (pside == -1) { tempColor = p1DEColor; tempType = p1DEType; }
        StartCoroutine(DelayMethod(timeInvoke, () =>
        {
            DEObj.GetComponent<DestroyEffect>().showDEByObj(DO, tempType, tempColor);
            //SoundObj.GetComponent<MakeSE>().shotKilledSound();
        }));
    }
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }


}
