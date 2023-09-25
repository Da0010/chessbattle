using System.Collections;
using UnityEngine;
using System.IO;
using LitJson;
using UnityEngine.AddressableAssets;
using TMPro;
using System;
using Addler.Runtime.Core;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;

[SerializeField]
public class ShortGameCont : MonoBehaviour
{
    [SerializeField] GameObject ContPlayTimeObj;
    [SerializeField] GameObject GameBasisObj;
    public ShortBoard temp;//now board
    public ShortBoardOnJson tempJson;
    ShortBoard openingBan;
    public BoardOnJsonRecord recordplaying;

    public GameObject[,] tempGameObj = new GameObject[6, 6];
    GameObject movingObj;
    GameObject killedObj;
    Vector3 startPosition, targetPosition;//移動
    private Vector3 velocity = Vector3.zero;
    public float time = 1F;
    public ShortBoard face;//show possible masu
    public int tempx;//put masu
    public int tempy;
    public int prex;//pre masu
    public int prey;

    public int p1ShougiKinshi;
    public int p2ShougiKinshi;
    [SerializeField] int shougiHande = 2;
    [SerializeField] GameObject p1KinshiGazou;
    [SerializeField] GameObject p2KinshiGazou;

    [SerializeField] Sprite komaSelectedBg;

    public int player1sideHave = 0;
    public GameObject player1sideHaveObj = null;

    public int player2sideHave = 0;
    int killedObjNum = 0;
    public GameObject player2sideHaveObj = null;
    bool shougiplayer1clicked = false;
    bool shougiplayer2clicked = false;

    public int Player1Type;
    public int Player2Type;



    public int player = 1;
    public int tempside = 0;


    [SerializeField] TextMeshProUGUI timerTextP1;
    [SerializeField] TextMeshProUGUI timerTextP2;
    [SerializeField] TextMeshProUGUI winResult;
    public bool changeTurn = false;

    [SerializeField] GameObject backButton;
    [SerializeField] GameObject stopButton;
    [SerializeField] GameObject nextButton;

    int seconds;


    int shougiKomaPromoteTo;

    public GameObject promoteShougiFrom;
    public GameObject promoteShougiTo;
    [SerializeField] GameObject checkShougiKeep;

    bool ShougiKeepOrNotPhase = false;
    public int promoteKomaTo;

    public bool player1RookLeftMove = false;
    public bool player1RookRightMove = false;
    public bool player1KingMove = false;
    public bool player2RookLeftMove = false;
    public bool player2RookRightMove = false;
    public bool player2KingMove = false;

    public HowMoveShortKoma ShortKomaClass;

    [SerializeField] GameObject promotePawn;
    [SerializeField] GameObject promoteShougi;
    [SerializeField] GameObject KomaClassObj;
    [SerializeField] GameObject MochigomapreIcon;
    [SerializeField] GameObject MochigomapostIcon;
    [SerializeField] GameObject ShortObjCollection;
    [SerializeField] GameObject SoundObj;


    //playingboard
    [SerializeField] GameObject a00;
    [SerializeField] GameObject a01;
    [SerializeField] GameObject a02;
    [SerializeField] GameObject a03;
    [SerializeField] GameObject a04;
    [SerializeField] GameObject a05;
    [SerializeField] GameObject a10;
    [SerializeField] GameObject a11;
    [SerializeField] GameObject a12;
    [SerializeField] GameObject a13;
    [SerializeField] GameObject a14;
    [SerializeField] GameObject a15;
    [SerializeField] GameObject a20;
    [SerializeField] GameObject a21;
    [SerializeField] GameObject a22;
    [SerializeField] GameObject a23;
    [SerializeField] GameObject a24;
    [SerializeField] GameObject a25;
    [SerializeField] GameObject a30;
    [SerializeField] GameObject a31;
    [SerializeField] GameObject a32;
    [SerializeField] GameObject a33;
    [SerializeField] GameObject a34;
    [SerializeField] GameObject a35;
    [SerializeField] GameObject a40;
    [SerializeField] GameObject a41;
    [SerializeField] GameObject a42;
    [SerializeField] GameObject a43;
    [SerializeField] GameObject a44;
    [SerializeField] GameObject a45;
    [SerializeField] GameObject a50;
    [SerializeField] GameObject a51;
    [SerializeField] GameObject a52;
    [SerializeField] GameObject a53;
    [SerializeField] GameObject a54;
    [SerializeField] GameObject a55;

    [SerializeField] GameObject ap1Have;
    [SerializeField] GameObject ap2Have;

    //Color
    Color noColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    Color whiteGray = new Color(0.9f, 0.9f, 0.9f, 1.0f);
    public void startSetUp() 
    {
        temp = new ShortBoard();
        tempJson = new ShortBoardOnJson();
        recordplaying = new BoardOnJsonRecord();
        ShortKomaClass = new HowMoveShortKoma();
        face = new ShortBoard();
        recordplaying = new BoardOnJsonRecord();
        ShortKomaClass.CallStart();
        GameBasisObj.GetComponent<GameBasisScr>().setDE();
        ShortObjCollection.SetActive(true);
    }

    public void startMainGame(int p1Deck, int p2Deck, int Fplayer, int Gt)
    {

        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().starttimer();
        player = Fplayer;
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().turn = -1;
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().changePlayerBg();
        startSetUp();

        cleanBoard();
        cleanBoardFace();
        updateKinshi(1);
        updateKinshi(-1);
        startSetUp();

        Player1Type = p1Deck;
        Player2Type = p2Deck;

        //0 chess
        //1 shougi
        //2 xiangxi

        string DeckName = "ShortDeck" + p1Deck.ToString();
        Addressables.LoadAssetAsync<TextAsset>(DeckName).Completed += handle =>
        {
            string inputP1Deck = handle.Result.ToString();
            tempJson = JsonUtility.FromJson<ShortBoardOnJson>(inputP1Deck);
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp.ban[i, j] = tempJson.ban[i * 6 + j];
                }
            }
        };

        DeckName = "ShortDeck" + p2Deck.ToString();
        Addressables.LoadAssetAsync<TextAsset>(DeckName).Completed += handle =>
        {
            string inputP2Deck = handle.Result.ToString();
            tempJson = JsonUtility.FromJson<ShortBoardOnJson>(inputP2Deck);
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp.ban[5 - i, 5 - j] = -1 * tempJson.ban[i * 6 + j];
                }
            }

        };


        Invoke(nameof(loadOpening), 1f);
    }



    public void loadOpening()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                putKoma(temp.ban[i, j], i, j);

            }
        }


        saveRecord();

        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().checkBeforeNext();
        stopButton.GetComponent<Button>().image.color = Color.white;
    }

    void saveRecord()
    {
        recordplaying.recordKomaBoard.Add(temp.TransferKomaString());
        recordplaying.recordPlayerBoard.Add(temp.TransferPlayerString());
        recordplaying.Fplayer.Add(player);
        recordplaying.P1sideHave.Add(player1sideHave);
        recordplaying.P2sideHave.Add(player2sideHave);
        recordplaying.P1kingMove.Add(player1KingMove);
        recordplaying.P1LeftRookMove.Add(player1RookLeftMove);
        recordplaying.P1RightRookMove.Add(player1RookRightMove);
        recordplaying.P2kingMove.Add(player2KingMove);
        recordplaying.P2LeftRookMove.Add(player2RookLeftMove);
        recordplaying.P2RightRookMove.Add(player2RookRightMove);
        recordplaying.p1ShougiKinshi.Add(p1ShougiKinshi);
        recordplaying.p2ShougiKinshi.Add(p2ShougiKinshi);
        recordplaying.gameType = 6;
        recordplaying.player1Type = Player1Type;
        recordplaying.player2Type = Player2Type;

        recordplaying.P1sideTime.Add((int)ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().totalTimeP1);
        recordplaying.P2sideTime.Add((int)ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().totalTimeP2);

        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().turn++;
    }








    public void shougiPutKoma(int a)
    {
        if (a > 0 && p1ShougiKinshi == 0 || a < 0 && p2ShougiKinshi == 0)
        {
            tempside = a;
            cleanBoardFace();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (temp.ban[i, j] == 0)
                    {
                        ShortKomaClass.showPossibleMove(i, j, 1);
                    }
                }
            }

            if (tempside > 0) { shougiplayer1clicked = true; ap1Have.GetComponent<SpriteRenderer>().color = whiteGray; }
            else if (tempside < 0) { shougiplayer2clicked = true; ap2Have.GetComponent<SpriteRenderer>().color = Color.black; }
        }
    }

    public void putKoma(int n, int i, int j)
    {

        if (tempGameObj[i, j] != null)
        {
            GameObject tempa = tempGameObj[i, j];
            Destroy(tempa, 0f);
        }
        if (n != 0)
        {
            float x = (float)((2.5 - j) * 0.1);
            float z = (float)((i - 2.5) * 0.1);
            GameObject obj = GameBasisObj.GetComponent<GameBasisScr>().getObjByNum(n); ;

            if (n > 0) { tempGameObj[i, j] = Instantiate(obj, new Vector3(x, 1.1f, z), Quaternion.identity); }
            else if (n < 0) { tempGameObj[i, j] = Instantiate(obj, new Vector3(x, 1.1f, z), Quaternion.Euler(0, 180, 0)); }
        }

    }

    public void findKoma(int num1, int num2)
    {
        tempx = num1;
        tempy = num2;
        tempside = temp.ban[tempx, tempy];
        if (shougiplayer1clicked && face.ban[tempx, tempy] == 1 && player == 1) { checkLast(); moveShougiKoma(); endturn(); }
        else if (shougiplayer2clicked && face.ban[tempx, tempy] == -1 && player == -1) { checkLast(); moveShougiKoma(); endturn(); }
        else
        {
            if (face.ban[tempx, tempy] == 1 && player == 1) { checkLast(); moveKoma(); }
            else if (face.ban[tempx, tempy] == 2 && player == 1) { checkLast(); killKoma(); }
            else if (face.ban[tempx, tempy] == -1 && player == -1) { checkLast(); moveKoma(); }
            else if (face.ban[tempx, tempy] == -2 && player == -1) { checkLast(); killKoma(); }
            else if (face.ban[tempx, tempy] == 3 && player == 1) { checkLast(); doCastling(); }
            else if (face.ban[tempx, tempy] == -3 && player == -1) { checkLast(); doCastling(); }
            else
            {
                prex = tempx; prey = tempy;
                int KomaSelected = temp.ban[tempx, tempy];
                cleanBoardFace();
                
                if (KomaSelected == 0) { return; }
                else if (KomaSelected == 1 || KomaSelected == -1) { setBgSelected(tempx, tempy); ShortKomaClass.findPawnMove(tempx, tempy); }
                else if (KomaSelected == 2 || KomaSelected == -2) { setBgSelected(tempx, tempy); ShortKomaClass.findRookMove(tempx, tempy); }
                else if (KomaSelected == 3 || KomaSelected == -3) { setBgSelected(tempx, tempy); ShortKomaClass.findKnightMove(tempx, tempy); }
                else if (KomaSelected == 4 || KomaSelected == -4) { setBgSelected(tempx, tempy); ShortKomaClass.findBishopMove(tempx, tempy); }
                else if (KomaSelected == 5 || KomaSelected == -5) { setBgSelected(tempx, tempy); ShortKomaClass.findQueenMove(tempx, tempy); }
                else if (KomaSelected == 6 || KomaSelected == -6) { setBgSelected(tempx, tempy); ShortKomaClass.findKingMove(tempx, tempy); }
                else if (KomaSelected == 11 || KomaSelected == -11) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiHoMove(tempx, tempy); }
                else if (KomaSelected == 12 || KomaSelected == -12) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiKakuMove(tempx, tempy); }
                else if (KomaSelected == 13 || KomaSelected == -13) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiHishaMove(tempx, tempy); }
                else if (KomaSelected == 14 || KomaSelected == -14) { setBgSelected(tempx, tempy); ShortKomaClass.findShougikurumaMove(tempx, tempy); }
                else if (KomaSelected == 15 || KomaSelected == -15) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiumaMove(tempx, tempy); }
                else if (KomaSelected == 16 || KomaSelected == -16) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiGinMove(tempx, tempy); }
                else if (KomaSelected == 17 || KomaSelected == -17) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiKinMove(tempx, tempy); }
                else if (KomaSelected == 18 || KomaSelected == -18) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiOuMove(tempx, tempy); }
                else if (KomaSelected == 21 || KomaSelected == -21) { setBgSelected(tempx, tempy); ShortKomaClass.findXiangqiHeiMove(tempx, tempy); }
                else if (KomaSelected == 22 || KomaSelected == -22) { setBgSelected(tempx, tempy); ShortKomaClass.findXinagqiHouMove(tempx, tempy); }
                else if (KomaSelected == 23 || KomaSelected == -23) { setBgSelected(tempx, tempy); ShortKomaClass.findXinagqiKurumakuMove(tempx, tempy); }
                else if (KomaSelected == 24 || KomaSelected == -24) { setBgSelected(tempx, tempy); ShortKomaClass.findXinagqiUmaMove(tempx, tempy); }
                else if (KomaSelected == 25 || KomaSelected == -25) { setBgSelected(tempx, tempy); ShortKomaClass.findXinagqiSouMove(tempx, tempy); }
                else if (KomaSelected == 26 || KomaSelected == -26) { setBgSelected(tempx, tempy); ShortKomaClass.findXinagqiSiMove(tempx, tempy); }
                else if (KomaSelected == 27 || KomaSelected == -27) { setBgSelected(tempx, tempy); ShortKomaClass.findXinagqiShouMove(tempx, tempy); }
                else if (KomaSelected == 31 || KomaSelected == -31) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiKinMove(tempx, tempy); }
                else if (KomaSelected == 32 || KomaSelected == -32) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiTatuMove(tempx, tempy); }
                else if (KomaSelected == 33 || KomaSelected == -33) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiRyuMove(tempx, tempy); }
                else if (KomaSelected == 34 || KomaSelected == -34) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiKinMove(tempx, tempy); }
                else if (KomaSelected == 35 || KomaSelected == -35) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiKinMove(tempx, tempy); }
                else if (KomaSelected == 36 || KomaSelected == -36) { setBgSelected(tempx, tempy); ShortKomaClass.findShougiKinMove(tempx, tempy); }

            }
        }

        shougiplayer1clicked = false;
        shougiplayer2clicked = false;
    }
    void setBgSelected(int a, int b)
    {
        Color tempcolor = whiteGray;
        if (tempside < 0) { tempcolor = Color.black; }
        findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().color = tempcolor;
        findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().sprite = komaSelectedBg;
    }
    void checkLast()
    {
        if (ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().turn + 1 == recordplaying.recordKomaBoard.Count) { }
        else
        {

            for (int i = recordplaying.recordKomaBoard.Count - 1; i > ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().turn; i--)
            {
                recordplaying.recordKomaBoard.RemoveAt(i);
                recordplaying.recordPlayerBoard.RemoveAt(i);
                recordplaying.Fplayer.RemoveAt(i);
                recordplaying.P1sideHave.RemoveAt(i);
                recordplaying.P2sideHave.RemoveAt(i);
                recordplaying.P1sideTime.RemoveAt(i);
                recordplaying.P2sideTime.RemoveAt(i);
            }
        }
    }
    void endturn()
    {
        ShowCheckOrNot();
        if (player == 1) { player = -1; ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().changePlayerBg(); if (p1ShougiKinshi != 0) { if (p1ShougiKinshi != 0) { p1ShougiKinshi--; } updateKinshi(1); } }
        else { player = 1; ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().changePlayerBg(); if (p2ShougiKinshi != 0) { if (p2ShougiKinshi != 0) { p2ShougiKinshi--; } updateKinshi(-1); } }
        cleanBoardFace(); saveRecord(); ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().checkBeforeNext();
        if (changeTurn) { ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().starttimer(); }
    }
    public void moveKoma()
    {
        SoundObj.GetComponent<MakeSE>().shotMoveSound();

        int tempKoma = temp.ban[prex, prey];
        checkCastling(tempKoma);
        temp.ban[tempx, tempy] = tempKoma;
        temp.ban[prex, prey] = 0;
        movingObj = tempGameObj[prex, prey];
        //itwenen

        var moveHash = new Hashtable();
        float x = (float)((2.5 - tempy) * 0.1);
        float z = (float)((tempx - 2.5) * 0.1);
        moveHash.Add("position", new Vector3(x, 1.1f, z));
        moveHash.Add("time", 0.5f);
        iTween.MoveTo(movingObj, moveHash);
        tempGameObj[tempx, tempy] = tempGameObj[prex, prey];
        tempGameObj[prex, prey] = null;
        //check pawn 
        checkPromote();

    }
    void checkCastling(int a)
    {
        if (a == -2 && prex == 0 && prey == 0) { player2RookRightMove = true; }
        else if (a == -2 && prex == 0 && prey == 8) { player2RookLeftMove = true; }
        else if (a == -6 && prex == 0 && prey == 3) { player2KingMove = true; }
        else if (a == 2 && prex == 8 && prey == 8) { player1RookRightMove = true; }
        else if (a == 2 && prex == 8 && prey == 0) { player1RookLeftMove = true; }
        else if (a == 6 && prex == 8 && prey == 5) { player1KingMove = true; }
    }

    void moveShougiKoma()
    {
        
        SoundObj.GetComponent<MakeSE>().shotMoveSound();
        if (player == 1)
        {
            temp.ban[tempx, tempy] = player1sideHave;
            player1sideHave = 0;
            var moveHash = new Hashtable();
            float x = (float)((2.5 - tempy) * 0.1);
            float z = (float)((tempx - 2.5) * 0.1);
            moveHash.Add("position", new Vector3(x, 1.1f, z));
            moveHash.Add("time", 1f);
            iTween.MoveTo(player1sideHaveObj, moveHash);
            tempGameObj[tempx, tempy] = player1sideHaveObj;
            player1sideHaveObj = null;
        }
        else if (player == -1)
        {
            temp.ban[tempx, tempy] = player2sideHave;
            player2sideHave = 0;
            var moveHash = new Hashtable();
            float x = (float)((2.5 - tempy) * 0.1);
            float z = (float)((tempx - 2.5) * 0.1);
            moveHash.Add("position", new Vector3(x, 1.1f, z));
            moveHash.Add("time", 1f);
            iTween.MoveTo(player2sideHaveObj, moveHash);
            tempGameObj[tempx, tempy] = player2sideHaveObj;
            player2sideHaveObj = null;
        }
    }

    public void killKoma()
    {
        
        SoundObj.GetComponent<MakeSE>().shotMoveSound();

        checkCastling(temp.ban[prex, prey]);
        killedObj = tempGameObj[tempx, tempy];
        killedObjNum = temp.ban[tempx, tempy];
        killedObj.GetComponent<Rigidbody>().isKinematic = false;
        movingObj = tempGameObj[prex, prey];
        int movingObjNum = temp.ban[prex, prey];
        //itwenen
        //add angle to here
        killedObj.GetComponent<Rigidbody>().mass = 0.4f * killedObj.GetComponent<Rigidbody>().mass;

        var moveHash = new Hashtable();
        float x = (float)((2.5 - tempy) * 0.1);
        float z = (float)((tempx - 2.5) * 0.1);
        moveHash.Add("position", new Vector3(x, 1.1f, z));
        moveHash.Add("time", 1f);
        iTween.MoveTo(movingObj, moveHash);
        

        if (killedObjNum == 6 || killedObjNum == 18 || killedObjNum == 27) { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 1, player); cleanBoardFace(); GameObject ContPlayCanvasObj = GameObject.Find("ContCanvasObj"); ContPlayCanvasObj.GetComponent<ContPlayCanvas>().openEndModal(); winResult.text = "Player 2 Win"; }
        else if (killedObjNum == -6 || killedObjNum == -18 || killedObjNum == -27) { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 1, player); cleanBoardFace(); GameObject ContPlayCanvasObj = GameObject.Find("ContCanvasObj"); ContPlayCanvasObj.GetComponent<ContPlayCanvas>().openEndModal(); winResult.text = "Player 1 Win"; }
        else
        {

            if (!((Math.Abs(movingObjNum) / 10 == 1 || Math.Abs(movingObjNum) / 10 == 3)) && ((Player1Type == 1 && player == 1) || (Player2Type == 1 && player == -1)))
            {
                GameBasisObj.GetComponent<GameBasisScr>().ShowDE(movingObj, 1, player);
                GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 1, player);
                temp.ban[tempx, tempy] = 0;
                temp.ban[prex, prey] = 0;
                tempGameObj[tempx, tempy] = null;
                tempGameObj[prex, prey] = null;
                doEnd();
            }
            else
            {
                if (player == 1 && ((temp.ban[prex, prey] >= 10 && temp.ban[prex, prey] <= 20) || (temp.ban[prex, prey] >= 30 && temp.ban[prex, prey] <= 40)))
                {
                    if (player1sideHave != 0)
                    {
                        ShougiKeepOrNotPhase = true;
                        MochigomaGazouSashikae();
                    }
                    else
                    {
                        p1ShougiKinshi = shougiHande;
                        KeepShougiKoma();
                    }
                }
                else if (player == -1 && ((temp.ban[prex, prey] <= -10 && temp.ban[prex, prey] >= -20) || (temp.ban[prex, prey] <= -30 && temp.ban[prex, prey] >= -40)))
                {
                    if (player2sideHave != 0)
                    {
                        ShougiKeepOrNotPhase = true;
                        MochigomaGazouSashikae();
                    }
                    else
                    {
                        p2ShougiKinshi = shougiHande;
                        KeepShougiKoma();
                    }
                }
                else { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 1, player); }

                temp.ban[tempx, tempy] = temp.ban[prex, prey];
                temp.ban[prex, prey] = 0;
                tempGameObj[tempx, tempy] = tempGameObj[prex, prey];
                tempGameObj[prex, prey] = null;
                checkPromote();
            }
        }
    }

    public void updateKinshi(int a)
    {
        if (a == 1)
        {
            p1KinshiGazou.GetComponent<TextMeshPro>().text = p1ShougiKinshi.ToString();
            if (p1ShougiKinshi == 0) { p1KinshiGazou.GetComponent<TextMeshPro>().text = ""; }
        }
        else if (a == -1)
        {
            p2KinshiGazou.GetComponent<TextMeshPro>().text = p2ShougiKinshi.ToString();
            if (p2ShougiKinshi == 0) { p2KinshiGazou.GetComponent<TextMeshPro>().text = ""; }
        }
    }
    void checkPromote()
    {
        if (temp.ban[tempx, tempy] == 1 && tempx == 0) { changePawnKoma(); }
        else if (temp.ban[tempx, tempy] == -1 && tempx == 5) { changePawnKoma(); }
        else if (temp.ban[tempx, tempy] == 11 && (tempx < 2 || prex < 2)) { changeHoKoma(); }
        else if (temp.ban[tempx, tempy] == -11 && (tempx > 3 || prex > 3)) { changeHoKoma(); }
        else if (temp.ban[tempx, tempy] == 12 && (tempx < 2 || prex < 2)) { changeKakuKoma(); }
        else if (temp.ban[tempx, tempy] == -12 && (tempx > 3 || prex > 3)) { changeKakuKoma(); }
        else if (temp.ban[tempx, tempy] == 13 && (tempx < 2 || prex < 2)) { changeHishaKoma(); }
        else if (temp.ban[tempx, tempy] == -13 && (tempx > 3 || prex > 3)) { changeHishaKoma(); }
        else if (temp.ban[tempx, tempy] == 14 && (tempx < 2 || prex < 2)) { changeKoushaKoma(); }
        else if (temp.ban[tempx, tempy] == -14 && (tempx > 3 || prex > 3)) { changeKoushaKoma(); }
        else if (temp.ban[tempx, tempy] == 15 && (tempx < 2 || prex < 2)) { changeKeiKoma(); }
        else if (temp.ban[tempx, tempy] == -15 && (tempx > 3 || prex > 3)) { changeKeiKoma(); }
        else if (temp.ban[tempx, tempy] == 16 && (tempx < 2 || prex < 2)) { changeGinKoma(); }
        else if (temp.ban[tempx, tempy] == -16 && (tempx > 3 || prex > 3)) { changeGinKoma(); }

        else
        {
            doEnd();
        }


    }
    void MochigomaGazouSashikae()
    {
        if (player == 1)
        {
            MochigomapreIcon.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(player1sideHave);
            MochigomapostIcon.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(-1 * temp.ban[tempx, tempy]);
        }
        else if (player == -1)
        {
            MochigomapreIcon.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(player2sideHave);
            MochigomapostIcon.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(-1 * temp.ban[tempx, tempy]);
        }

    }



    public void KeepShougiKoma()
    {
        GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 0, player);
        if (player == 1)
        {
            p1ShougiKinshi = shougiHande;
            if (player1sideHave != 0) { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(player1sideHaveObj, 0, player); }
            player1sideHave = -1 * killedObjNum;



            float x = killedObj.transform.position.x;
            float z = killedObj.transform.position.z;
            GameObject obj = GameBasisObj.GetComponent<GameBasisScr>().getObjByNum(player1sideHave); ;

            player1sideHaveObj = Instantiate(obj, new Vector3(x, 1.1f, z), Quaternion.identity);



            var moveHash2 = new Hashtable();
            moveHash2.Add("position", new Vector3(-0.47f, 1.1f, 0.3f));
            moveHash2.Add("time", 1f);
            iTween.RotateAdd(player1sideHaveObj, iTween.Hash("y", 360f, "time", 1f));
            iTween.MoveTo(player1sideHaveObj, moveHash2);
        }
        else
        {
            p2ShougiKinshi = shougiHande;
            if (player2sideHave != 0) { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(player2sideHaveObj, 0, player); }
            player2sideHave = -1 * killedObjNum;



            float x = killedObj.transform.position.x;
            float z = killedObj.transform.position.z;
            GameObject obj = GameBasisObj.GetComponent<GameBasisScr>().getObjByNum(player2sideHave); ;


            player2sideHaveObj = Instantiate(obj, new Vector3(x, 1.1f, z), Quaternion.Euler(0, 180, 0));


            var moveHash2 = new Hashtable();
            moveHash2.Add("position", new Vector3(0.47f, 1.1f, -0.3f));
            moveHash2.Add("time", 1f);
            iTween.RotateAdd(player2sideHaveObj, iTween.Hash("y", 360f, "time", 1f));
            iTween.MoveTo(player2sideHaveObj, moveHash2);
        }
    }

    public void shougiKeepKoma() { KeepShougiKoma(); doEnd(); }
    public void shougiNotKeepKoma() { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 0, player); doEnd(); }





    void changePawnKoma()
    {
        promotePawn.GetComponent<ModalWindowManager>().OpenWindow();
    }

    void changeHoKoma()
    {
        promoteShougiFrom.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(11);
        promoteShougiTo.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(31);
        promoteShougi.GetComponent<ModalWindowManager>().OpenWindow();
        promoteKomaTo = player * 31;
    }
    void changeKoushaKoma()
    {
        promoteShougiFrom.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(14);
        promoteShougiTo.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(34);
        promoteShougi.GetComponent<ModalWindowManager>().OpenWindow();
        promoteKomaTo = player * 34;
    }
    void changeKeiKoma()
    {
        promoteShougiFrom.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(15);
        promoteShougiTo.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(35);
        promoteShougi.GetComponent<ModalWindowManager>().OpenWindow();
        promoteKomaTo = player * 35;
    }
    void changeGinKoma()
    {
        promoteShougiFrom.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(16);
        promoteShougiTo.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(36);
        promoteShougi.GetComponent<ModalWindowManager>().OpenWindow();
        promoteKomaTo = player * 36;
    }

    void changeHishaKoma()
    {
        promoteShougiFrom.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(13);
        promoteShougiTo.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(33);
        promoteShougi.GetComponent<ModalWindowManager>().OpenWindow();
        promoteKomaTo = player * 33;
    }

    void changeKakuKoma()
    {
        promoteShougiFrom.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(12);
        promoteShougiTo.GetComponent<Image>().sprite = KomaClassObj.GetComponent<komaClass>().GetGazouByNum(32);
        promoteShougi.GetComponent<ModalWindowManager>().OpenWindow();
        promoteKomaTo = player * 32;
    }

    public void promoteShougiKoma()
    {
        temp.ban[tempx, tempy] = promoteKomaTo;
        iTween.RotateTo(tempGameObj[tempx, tempy], iTween.Hash("z", 180f, "time", 0.5f));
        doEnd();
    }

    public void PawnToKnight()
    {
        temp.ban[tempx, tempy] = player * 3;
        putKoma(temp.ban[tempx, tempy], tempx, tempy);
        doEnd();
    }
    public void PawnToBishop()
    {
        temp.ban[tempx, tempy] = player * 4;
        putKoma(temp.ban[tempx, tempy], tempx, tempy);
        doEnd();
    }
    public void PawnToRook()
    {
        temp.ban[tempx, tempy] = player * 2;
        putKoma(temp.ban[tempx, tempy], tempx, tempy);
        doEnd();
    }
    public void PawnToQueen()
    {
        temp.ban[tempx, tempy] = player * 5;
        putKoma(temp.ban[tempx, tempy], tempx, tempy);
        doEnd();
    }


    public void doEnd() { if (ShougiKeepOrNotPhase) { checkShougiKeep.GetComponent<ModalWindowManager>().OpenWindow(); ShougiKeepOrNotPhase = false; } else { endturn(); } }



    void doCastling()
    {
        if (tempx == 0 && tempy == 0) { SubCastling(0, 2, 0, 0); SubCastling(0, 0, 0, 1); }
        else if (tempx == 0 && tempy == 4) { SubCastling(0, 2, 0, 4); SubCastling(0, 5, 0, 3); }
        else if (tempx == 5 && tempy == 5) { SubCastling(5, 3, 5, 5); SubCastling(5, 5, 5, 4); }
        else if (tempx == 5 && tempy == 1) { SubCastling(5, 3, 5, 1); SubCastling(5, 0, 5, 2); }
        doEnd();
    }
    void SubCastling(int movexBefore, int moveyBefore, int movexAfter, int moveyAfter)
    {
        int tempKoma = temp.ban[movexBefore, moveyBefore];
        checkCastling(tempKoma);
        temp.ban[movexAfter, moveyAfter] = tempKoma;
        temp.ban[movexBefore, moveyBefore] = 0;
        movingObj = tempGameObj[movexBefore, moveyBefore];
        //itwenen

        var moveHash = new Hashtable();
        float x = (float)((2.5 - moveyAfter) * 0.1);
        float z = (float)((movexAfter - 2.5) * 0.1);
        moveHash.Add("position", new Vector3(x, 1.1f, z));
        moveHash.Add("time", 0.5f);
        iTween.MoveTo(movingObj, moveHash);
        tempGameObj[movexAfter, moveyAfter] = tempGameObj[movexBefore, moveyBefore];
        tempGameObj[movexBefore, moveyBefore] = null;

    }




    public GameObject findBoardFacePosition(int num1, int num2)
    {
        if (num1 == 0)
        {
            if (num2 == 0) { return a00; }
            else if (num2 == 1) { return a01; }
            else if (num2 == 2) { return a02; }
            else if (num2 == 3) { return a03; }
            else if (num2 == 4) { return a04; }
            else if (num2 == 5) { return a05; }
        }
        else if (num1 == 1)
        {
            if (num2 == 0) { return a10; }
            else if (num2 == 1) { return a11; }
            else if (num2 == 2) { return a12; }
            else if (num2 == 3) { return a13; }
            else if (num2 == 4) { return a14; }
            else if (num2 == 5) { return a15; }
        }
        else if (num1 == 2)
        {
            if (num2 == 0) { return a20; }
            else if (num2 == 1) { return a21; }
            else if (num2 == 2) { return a22; }
            else if (num2 == 3) { return a23; }
            else if (num2 == 4) { return a24; }
            else if (num2 == 5) { return a25; }
        }
        else if (num1 == 3)
        {
            if (num2 == 0) { return a30; }
            else if (num2 == 1) { return a31; }
            else if (num2 == 2) { return a32; }
            else if (num2 == 3) { return a33; }
            else if (num2 == 4) { return a34; }
            else if (num2 == 5) { return a35; }
        }
        else if (num1 == 4)
        {
            if (num2 == 0) { return a40; }
            else if (num2 == 1) { return a41; }
            else if (num2 == 2) { return a42; }
            else if (num2 == 3) { return a43; }
            else if (num2 == 4) { return a44; }
            else if (num2 == 5) { return a45; }
        }
        else if (num1 == 5)
        {
            if (num2 == 0) { return a50; }
            else if (num2 == 1) { return a51; }
            else if (num2 == 2) { return a52; }
            else if (num2 == 3) { return a53; }
            else if (num2 == 4) { return a54; }
            else if (num2 == 5) { return a55; }
        }
        
        return null;
    }

    public void cleanBoardFace()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (findBoardFacePosition(i, j).GetComponent<SpriteRenderer>().color != noColor) { findBoardFacePosition(i, j).GetComponent<SpriteRenderer>().color = noColor; findBoardFacePosition(i, j).GetComponent<SpriteRenderer>().sprite = null; face.ban[i, j] = 0; }
            }
        }

        ap1Have.GetComponent<SpriteRenderer>().color = noColor;
        ap2Have.GetComponent<SpriteRenderer>().color = noColor;

    }
    public void cleanBoard()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Destroy(tempGameObj[i, j]);
                temp.ban[i, j] = 0;
            }
        }

        Destroy(player1sideHaveObj);
        player1sideHave = 0;
        Destroy(player2sideHaveObj);
        player2sideHave = 0;

    }

    void ShowCheckOrNot() 
    {
        tempside = player*-1;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (player*temp.ban[i, j] == -6 || player * temp.ban[i, j] == -18 || player * temp.ban[i, j] == -27) 
                {
                    if (!ShortKomaClass.checkCheckmait(i, j)) { GameObject ContPlayCanvasObj = GameObject.Find("ContCanvasObj"); ContPlayCanvasObj.GetComponent<ContPlayCanvas>().openCheckModal(); SoundObj.GetComponent<MakeSE>().shotCheckSound();}
                    break;
                }

            }
        }
    }





    public void check00()
    {
        findKoma(0, 0);
    }
    public void check01()
    {
        findKoma(0, 1);
    }
    public void check02()
    {
        findKoma(0, 2);
    }
    public void check03()
    {
        findKoma(0, 3);
    }
    public void check04()
    {
        findKoma(0, 4);
    }
    public void check05()
    {
        findKoma(0, 5);
    }
    public void check10()
    {
        findKoma(1, 0);
    }
    public void check11()
    {
        findKoma(1, 1);
    }
    public void check12()
    {
        findKoma(1, 2);
    }
    public void check13()
    {
        findKoma(1, 3);
    }
    public void check14()
    {
        findKoma(1, 4);
    }
    public void check15()
    {
        findKoma(1, 5);
    }
    public void check20()
    {
        findKoma(2, 0);
    }
    public void check21()
    {
        findKoma(2, 1);
    }
    public void check22()
    {
        findKoma(2, 2);
    }
    public void check23()
    {
        findKoma(2, 3);
    }
    public void check24()
    {
        findKoma(2, 4);
    }
    public void check25()
    {
        findKoma(2, 5);
    }
    public void check30()
    {
        findKoma(3, 0);
    }
    public void check31()
    {
        findKoma(3, 1);
    }

    public void check32()
    {
        findKoma(3, 2);
    }
    public void check33()
    {
        findKoma(3, 3);
    }
    public void check34()
    {
        findKoma(3, 4);
    }
    public void check35()
    {
        findKoma(3, 5);
    }
    public void check40()
    {
        findKoma(4, 0);
    }
    public void check41()
    {
        findKoma(4, 1);
    }
    public void check42()
    {
        findKoma(4, 2);
    }
    public void check43()
    {
        findKoma(4, 3);
    }
    public void check44()
    {
        findKoma(4, 4);
    }
    public void check45()
    {
        findKoma(4, 5);
    }

    public void check50()
    {
        findKoma(5, 0);
    }
    public void check51()
    {
        findKoma(5, 1);
    }
    public void check52()
    {
        findKoma(5, 2);
    }
    public void check53()
    {
        findKoma(5, 3);
    }
    public void check54()
    {
        findKoma(5, 4);
    }
    public void check55()
    {
        findKoma(5, 5);
    }
    public void checkP1have()
    {
        shougiPutKoma(1000);
    }

    public void checkP2have()
    {
        shougiPutKoma(-1000);
    }


}
