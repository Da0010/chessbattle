using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class komaClass : MonoBehaviour
{
    [SerializeField] Sprite huGazou;
    [SerializeField] Sprite koushaGazou;
    [SerializeField] Sprite toGazou;
    [SerializeField] Sprite keiGazou;
    [SerializeField] Sprite ginGazou;
    [SerializeField] Sprite kinGazou;
    [SerializeField] Sprite kakuGazou;
    [SerializeField] Sprite hishaGazou;
    [SerializeField] Sprite ryuGazou;
    [SerializeField] Sprite tatuGazou;
    [SerializeField] Sprite ouGazou;

    [SerializeField] Sprite akaheiGazou;
    [SerializeField] Sprite kuroheiGazou;
    [SerializeField] Sprite akaumaGazou;
    [SerializeField] Sprite kuroumaGazou;
    [SerializeField] Sprite akakurumaGazou;
    [SerializeField] Sprite kurokurumaGazou;
    [SerializeField] Sprite akahouGazou;
    [SerializeField] Sprite kurohouGazou;
    [SerializeField] Sprite akasouGazou;
    [SerializeField] Sprite kurosouGazou;
    [SerializeField] Sprite akasiGazou;
    [SerializeField] Sprite kurosiGazou;
    [SerializeField] Sprite akashouGazou;
    [SerializeField] Sprite kuroshouGazou;

    [SerializeField] Sprite pawnGazou;
    [SerializeField] Sprite rookGazou;
    [SerializeField] Sprite knightGazou;
    [SerializeField] Sprite bishopGazou;
    [SerializeField] Sprite kingGazou;
    [SerializeField] Sprite queenGazou;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Sprite GetGazouByNum(int a)
    {
        Sprite result = null;

        if (a == 1 || a == -1) { result = pawnGazou; }
        else if (a == 2 || a == -2) { result = rookGazou; }
        else if (a == 3 || a == -3) { result = knightGazou; }
        else if (a == 4 || a == -4) { result = bishopGazou; }
        else if (a == 5 || a == -5) { result = queenGazou; }
        else if (a == 6 || a == -6) { result = kingGazou; }
        else if (a == 11 || a == -11) { result = huGazou; }
        else if (a == 12 || a == -12) { result = kakuGazou; }
        else if (a == 13 || a == -13) { result = hishaGazou; }
        else if (a == 14 || a == -14) { result = koushaGazou; }
        else if (a == 15 || a == -15) { result = keiGazou; }
        else if (a == 16 || a == -16) { result = ginGazou; }
        else if (a == 17 || a == -17) { result = kinGazou; }
        else if (a == 18 || a == -18) { result = ouGazou; }
        else if (a == 21) { result = akaheiGazou; }
        else if (a == 22) { result = akahouGazou; }
        else if (a == 23) { result = akakurumaGazou; }
        else if (a == 24) { result = akaumaGazou; }
        else if (a == 25) { result = akasouGazou; }
        else if (a == 26) { result = akasiGazou; }
        else if (a == 27) { result = akashouGazou; }
        else if (a == -21) { result = kuroheiGazou; }
        else if (a == -22) { result = kurohouGazou; }
        else if (a == -23) { result = kurokurumaGazou; }
        else if (a == -24) { result = kuroumaGazou; }
        else if (a == -25) { result = kurosouGazou; }
        else if (a == -26) { result = kurosiGazou; }
        else if (a == -27) { result = kuroshouGazou; }
        else if (a == 31 || a == -31) { result = toGazou; }
        else if (a == 32 || a == -32) { result = tatuGazou; }
        else if (a == 33 || a == -33) { result = ryuGazou; }
        else if (a == 34 || a == -34) { result = kinGazou; }
        else if (a == 35 || a == -35) { result = kinGazou; }
        else if (a == 36 || a == -36) { result = kinGazou; }
        else if (a == 37 || a == -37) { result = kinGazou; }
        else if (a == 38 || a == -38) { result = ouGazou; }
        return result;
    }
    [SerializeField]
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

    
}
[SerializeField]
public class LongBoard
{
    public int[,] ban = new int[9,9];
    public string TransferKomaString() {
        string result ="";
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++) {
                result = result + (Math.Abs(ban[i, j])).ToString("D2");
            }
        }
        return result;
    }
    public string TransferPlayerString()
    {
        string result = "";
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                string temp = "0";
                if (ban[i, j] > 0) { temp = "1"; }
                else if (ban[i, j] < 0) { temp = "2"; }
                result = result + temp;
            }
        }
        return result;
    }


}
[SerializeField]
public class LongBoardOnJson
{
    public int[] ban = new int[81];

    public LongBoard JsonToBoard() 
        {
        int count = 0;
        LongBoard temp = new LongBoard();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                temp.ban[i, j] = ban[count];
                count++;
            } 
        }
        return temp;
    }
}

[SerializeField]
public class BoardOnJsonRecord
{
    public List<string> recordKomaBoard = new List<string>();
    public List<string> recordPlayerBoard = new List<string>();
    public List<int> Fplayer =  new List<int>();
    public List<int> P1sideHave = new List<int>();
    public List<int> P2sideHave = new List<int>();
    public List<int> P1sideTime = new List<int>();
    public List<int> P2sideTime = new List<int>();
    public List<bool> P1kingMove = new List<bool>();
    public List<bool> P1RightRookMove = new List<bool>();
    public List<bool> P1LeftRookMove = new List<bool>();
    public List<bool> P2kingMove = new List<bool>();
    public List<bool> P2RightRookMove = new List<bool>();
    public List<bool> P2LeftRookMove = new List<bool>();
    
    public List<int> p1ShougiKinshi = new List<int>();
    public List<int> p2ShougiKinshi = new List<int>();

    public int player1Type;
    public int player2Type;

    public int p1DEType;
    public float p1DEColor;
    public int p2DEType;
    public float p2DEColor;
    public int gameType;
}
[SerializeField]
public class ShortBoard
{
    public int[,] ban = new int[6, 6];
    public string TransferKomaString()
    {
        string result = "";
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                result = result + (Math.Abs(ban[i, j])).ToString("D2");
            }
        }
        return result;
    }
    public string TransferPlayerString()
    {
        string result = "";
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                string temp = "0";
                if (ban[i, j] > 0) { temp = "1"; }
                else if (ban[i, j] < 0) { temp = "2"; }
                result = result + temp;
            }
        }
        return result;
    }


}
[SerializeField]
public class ShortBoardOnJson
{
    public int[] ban = new int[36];

    public ShortBoard JsonToBoard()
    {
        int count = 0;
        ShortBoard temp = new ShortBoard();
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                temp.ban[i, j] = ban[count];
                count++;
            }
        }
        return temp;
    }
}



