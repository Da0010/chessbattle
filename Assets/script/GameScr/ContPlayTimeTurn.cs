using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContPlayTimeTurn : MonoBehaviour
{
    [SerializeField] GameObject LongGameContObj;
    [SerializeField] GameObject ShortGameContObj;

    [SerializeField] GameObject KomaClassObj;

    [SerializeField] GameObject LongObjCollection;
    [SerializeField] GameObject ShortObjCollection;
    [SerializeField] GameObject SoundObj;



    //
    public LongBoard Longtemp;
    public float time = 1F;
    public LongBoard face;//show possible masu

    public int turn = -1;
    public int gt = 9;




    [SerializeField] TextMeshProUGUI timerTextP1;
    [SerializeField] TextMeshProUGUI timerTextP2;
    [SerializeField] TextMeshProUGUI winResult;
    public bool stoptime = false;

    [SerializeField] GameObject backButton;
    [SerializeField] GameObject stopButton;
    [SerializeField] GameObject nextButton;

    public float totalTimeP1 = 0;
    public float totalTimeP2 = 0;

    int seconds;

    [SerializeField] GameObject p1plyingBg;
    [SerializeField] GameObject p2plyingBg;
    [SerializeField] Sprite playingBg;


    //Color
    Color noColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    Color whiteGray = new Color(0.9f, 0.9f, 0.9f, 1.0f);
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTimeP1 > 3600) { timerTextP1.text = "∞"; timerTextP2.text = "∞"; }
        else if (!stoptime)
        {
            
                if (LongGameContObj.GetComponent<LongGameCont>().player == 1)
                {
                    totalTimeP1 -= Time.deltaTime;
                    seconds = (int)totalTimeP1;
                    string fu = "";
                    if (seconds == 0) {SoundObj.GetComponent<MakeSE>().shotTimeOverSound();}
                    if (seconds < 0) { fu = "-"; timerTextP1.color = Color.red; }
                    else { fu = ""; timerTextP1.color = Color.white; }
                    string tempM = Math.Abs(seconds / 60).ToString("D2");
                    string tempS = Math.Abs(seconds % 60).ToString("D2");
                    timerTextP1.text = fu + tempM + ":" + tempS;
                }
                else if (LongGameContObj.GetComponent<LongGameCont>().player == -1)
                {
                    totalTimeP2 -= Time.deltaTime;
                    seconds = (int)totalTimeP2;
                    string fu = "";
                    if (seconds == 0) {SoundObj.GetComponent<MakeSE>().shotTimeOverSound();}
                    if (seconds < 0) { fu = "-"; timerTextP2.color = Color.red; }
                    else { fu = ""; timerTextP2.color = Color.white; }
                    string tempM = Math.Abs(seconds / 60).ToString("D2");
                    string tempS = Math.Abs(seconds % 60).ToString("D2");
                    timerTextP2.text = fu + tempM + ":" + tempS;
                }
        }
        
    }
    public void changePlayerBg() 
    {
        int tempPlayer = 0;
        if (gt == 9)
        {
            tempPlayer = LongGameContObj.GetComponent<LongGameCont>().player;
        }
        else if (gt == 6)
        {
            tempPlayer = ShortGameContObj.GetComponent<ShortGameCont>().player;
        }

        if (tempPlayer == 1)
        {
            p1plyingBg.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f) ;
            p2plyingBg.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
        else if (tempPlayer == -1)
        {
            p2plyingBg.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            p1plyingBg.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }


    public void startGame(int p1Deck, int p2Deck, int ptime, int Fplayer,int gametype)
    {

        totalTimeP1 = ptime;
        totalTimeP2 = ptime;
        gt = gametype;
        seconds = (int)ptime;
        string tempM = Math.Abs(seconds / 60).ToString("D2");
        string tempS = Math.Abs(seconds % 60).ToString("D2");
        timerTextP2.text = tempM + ":" + tempS;
        if (gt == 9)
        {
            LongGameContObj.SetActive(true); LongGameContObj.GetComponent<LongGameCont>().startMainGame(p1Deck, p2Deck, Fplayer, gt);
        }
        else if (gt == 6)
        {
            ShortGameContObj.SetActive(true); ShortGameContObj.GetComponent<ShortGameCont>().startMainGame(p1Deck, p2Deck, Fplayer, gt);
        }
    }


    public void showBeforeRecord()
    {
        if (turn != 0)
        {   
            turn--; 
            showRecord();
        }
    }

    public void showNextRecord()
    {
        int totalTurn = 0;
        if (gt == 9)
        {
            totalTurn = LongGameContObj.GetComponent<LongGameCont>().recordplaying.recordKomaBoard.Count;
        }
        else if (gt == 6)
        {
             totalTurn = ShortGameContObj.GetComponent<ShortGameCont>().recordplaying.recordKomaBoard.Count;
        }
        if (turn + 1 != totalTurn)
        {
            turn++ ;
            showRecord();
        }


    }
    public void stoptimer()
    {
        stoptime = true;
        stopButton.GetComponent<Button>().image.color = Color.gray;
    }

    public void starttimer()
    {
        stoptime = false;
        stopButton.GetComponent<Button>().image.color = Color.white;
    }

    public void clickStopButton()
    {
        if (stoptime) { stoptime = false; stopButton.GetComponent<Button>().image.color = Color.white; }
        else { stoptime = true; stopButton.GetComponent<Button>().image.color = Color.gray; }

    }

    public void checkBeforeNext()
    {
        int totalTurn = 0;
        if (gt == 9)
        {
            totalTurn = LongGameContObj.GetComponent<LongGameCont>().recordplaying.recordKomaBoard.Count;
        }
        else if (gt == 6)
        {
            totalTurn = ShortGameContObj.GetComponent<ShortGameCont>().recordplaying.recordKomaBoard.Count;
        }
        if (turn == 0) { backButton.GetComponent<Button>().image.color = Color.grey; } else { backButton.GetComponent<Button>().image.color = Color.white; }
        if (turn + 1 == totalTurn){ nextButton.GetComponent<Button>().image.color = Color.grey; } else { nextButton.GetComponent<Button>().image.color = Color.white; }
    }

    public void loadRecord(int num)
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/jsonfiles/record" + num.ToString() + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();
        BoardOnJsonRecord tempJson = new BoardOnJsonRecord();
        tempJson = JsonUtility.FromJson<BoardOnJsonRecord>(datastr);

        

        if (tempJson.gameType == 9)
        {
            LongGameContObj.SetActive(true);
            gt = 9;
            LongGameContObj.GetComponent<LongGameCont>().startSetUp();
            turn = tempJson.recordKomaBoard.Count- 1;
            LongObjCollection.SetActive(true);
            LongGameContObj.GetComponent<LongGameCont>().recordplaying = JsonUtility.FromJson<BoardOnJsonRecord>(datastr);
            
            showRecord();
        }
        else if (tempJson.gameType == 6)
        {
            ShortGameContObj.SetActive(true);
            gt = 6;
            ShortGameContObj.GetComponent<ShortGameCont>().startSetUp();
            turn = tempJson.recordKomaBoard.Count - 1;
            ShortObjCollection.SetActive(true);
            ShortGameContObj.GetComponent<ShortGameCont>().recordplaying = JsonUtility.FromJson<BoardOnJsonRecord>(datastr);

            showRecord();
        }
    }

    void showRecord() 
    {


        if (gt == 9)
        {
            LongGameCont tempLongClass = LongGameContObj.GetComponent<LongGameCont>();

            tempLongClass.changeTurn = true;
            tempLongClass.cleanBoardFace();
            
            string strtemp1 = tempLongClass.recordplaying.recordKomaBoard[turn];
            string strtemp2 = tempLongClass.recordplaying.recordPlayerBoard[turn];
            tempLongClass.player = tempLongClass.recordplaying.Fplayer[turn];
            tempLongClass.player1KingMove = tempLongClass.recordplaying.P1kingMove[turn];
            tempLongClass.player1RookRightMove = tempLongClass.recordplaying.P1RightRookMove[turn];
            tempLongClass.player1RookLeftMove = tempLongClass.recordplaying.P1LeftRookMove[turn];
            tempLongClass.player2KingMove = tempLongClass.recordplaying.P2kingMove[turn];
            tempLongClass.player2RookRightMove = tempLongClass.recordplaying.P2RightRookMove[turn];
            tempLongClass.player2RookLeftMove = tempLongClass.recordplaying.P2LeftRookMove[turn];
            tempLongClass.p1ShougiKinshi = tempLongClass.recordplaying.p1ShougiKinshi[turn];
            tempLongClass.p2ShougiKinshi = tempLongClass.recordplaying.p2ShougiKinshi[turn];
            tempLongClass.updateKinshi(1);
            tempLongClass.updateKinshi(-1);
            tempLongClass.Player1Type = tempLongClass.recordplaying.player1Type;
            tempLongClass.Player2Type = tempLongClass.recordplaying.player2Type;

            tempLongClass.player = tempLongClass.recordplaying.Fplayer[turn];
            changePlayerBg();
            if (tempLongClass.player1sideHaveObj != null) { Destroy(tempLongClass.player1sideHaveObj); }
            tempLongClass.player1sideHave = tempLongClass.recordplaying.P1sideHave[turn];
            if (tempLongClass.recordplaying.P1sideHave[turn] != 0)
            {
                GameObject a = KomaClassObj.GetComponent<komaClass>().getObjByNum(tempLongClass.recordplaying.P1sideHave[turn]);
                tempLongClass.player1sideHaveObj = Instantiate(a, new Vector3(-0.64f, 1.1f, 0.414f), Quaternion.identity);

            }
            if (tempLongClass.player2sideHaveObj != null) { Destroy(tempLongClass.player2sideHaveObj); }
            tempLongClass.player2sideHave = tempLongClass.recordplaying.P2sideHave[turn];
            if (tempLongClass.recordplaying.P2sideHave[turn] != 0)
            {
                GameObject a = KomaClassObj.GetComponent<komaClass>().getObjByNum(tempLongClass.recordplaying.P2sideHave[turn]);
                tempLongClass.player2sideHaveObj = Instantiate(a, new Vector3(0.64f, 1.1f, -0.414f), Quaternion.Euler(0, 180, 0));
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    tempLongClass.temp.ban[i, j] = int.Parse(strtemp1.Substring((i * 9 + j) * 2, 2));
                    if (strtemp2.Substring((i * 9 + j), 1) == "2") { tempLongClass.temp.ban[i, j] *= -1; }
                    tempLongClass.putKoma(tempLongClass.temp.ban[i, j], i, j);

                }
            }
            checkBeforeNext();
            stoptimer();
        }
        else 
        {
            ShortGameCont tempShortClass = ShortGameContObj.GetComponent<ShortGameCont>();

            tempShortClass.changeTurn = true;
            tempShortClass.cleanBoardFace();




            string strtemp1 = tempShortClass.recordplaying.recordKomaBoard[turn];
            string strtemp2 = tempShortClass.recordplaying.recordPlayerBoard[turn];
            tempShortClass.player = tempShortClass.recordplaying.Fplayer[turn];
            tempShortClass.player1KingMove = tempShortClass.recordplaying.P1kingMove[turn];
            tempShortClass.player1RookRightMove = tempShortClass.recordplaying.P1RightRookMove[turn];
            tempShortClass.player1RookLeftMove = tempShortClass.recordplaying.P1LeftRookMove[turn];
            tempShortClass.player2KingMove = tempShortClass.recordplaying.P2kingMove[turn];
            tempShortClass.player2RookRightMove = tempShortClass.recordplaying.P2RightRookMove[turn];
            tempShortClass.player2RookLeftMove = tempShortClass.recordplaying.P2LeftRookMove[turn];
            tempShortClass.p1ShougiKinshi = tempShortClass.recordplaying.p1ShougiKinshi[turn];
            tempShortClass.p2ShougiKinshi = tempShortClass.recordplaying.p2ShougiKinshi[turn];
            tempShortClass.updateKinshi(1);
            tempShortClass.updateKinshi(-1);

            tempShortClass.player = tempShortClass.recordplaying.Fplayer[turn];
            changePlayerBg();
            if (tempShortClass.player1sideHaveObj != null) { Destroy(tempShortClass.player1sideHaveObj); }
            tempShortClass.player1sideHave = tempShortClass.recordplaying.P1sideHave[turn];
            if (tempShortClass.recordplaying.P1sideHave[turn] != 0)
            {
                GameObject a = KomaClassObj.GetComponent<komaClass>().getObjByNum(tempShortClass.recordplaying.P1sideHave[turn]);
                tempShortClass.player1sideHaveObj = Instantiate(a, new Vector3(-0.47f, 1.1f, 0.3f), Quaternion.identity);

            }
            if (tempShortClass.player2sideHaveObj != null) { Destroy(tempShortClass.player2sideHaveObj); }
            tempShortClass.player2sideHave = tempShortClass.recordplaying.P2sideHave[turn];
            if (tempShortClass.recordplaying.P2sideHave[turn] != 0)
            {
                GameObject a = KomaClassObj.GetComponent<komaClass>().getObjByNum(tempShortClass.recordplaying.P2sideHave[turn]);
                tempShortClass.player2sideHaveObj = Instantiate(a, new Vector3(0.47f, 1.1f, -0.3f), Quaternion.Euler(0, 180, 0));
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    tempShortClass.temp.ban[i, j] = int.Parse(strtemp1.Substring((i * 6 + j) * 2, 2));
                    if (strtemp2.Substring((i * 6 + j), 1) == "2") { tempShortClass.temp.ban[i, j] *= -1; }
                    tempShortClass.putKoma(tempShortClass.temp.ban[i, j], i, j);

                }
            }
            checkBeforeNext();
            stoptimer();
        }
    }

}
