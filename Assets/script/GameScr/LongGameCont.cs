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
public class LongGameCont : MonoBehaviour
{
    [SerializeField] GameObject ContPlayTimeObj;
    [SerializeField] GameObject GameBasisObj;
    public LongBoard temp;//now board
    public LongBoardOnJson tempJson;
    LongBoard openingBan;
    public BoardOnJsonRecord recordplaying;
    [SerializeField] GameObject LongObjCollection;

    public GameObject[,] tempGameObj = new GameObject[9, 9];
    GameObject movingObj;
    GameObject killedObj;
    Vector3 startPosition, targetPosition;//移動
    private Vector3 velocity = Vector3.zero;
    public float time = 1F;
    public LongBoard face;//show possible masu
    public int tempx;//put masu
    public int tempy;
    public int prex;//pre masu
    public int prey;

    public int p1ShougiKinshi;
    public int p2ShougiKinshi;
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

    public HowMoveLongKoma LongKomaClass;

    [SerializeField] GameObject promotePawn;
    [SerializeField] GameObject promoteShougi;
    [SerializeField] GameObject KomaClassObj;
    [SerializeField] GameObject MochigomapreIcon;
    [SerializeField] GameObject MochigomapostIcon;
    [SerializeField] GameObject SoundObj;


    //playingboard
    [SerializeField] GameObject a00;
    [SerializeField] GameObject a01;
    [SerializeField] GameObject a02;
    [SerializeField] GameObject a03;
    [SerializeField] GameObject a04;
    [SerializeField] GameObject a05;
    [SerializeField] GameObject a06;
    [SerializeField] GameObject a07;
    [SerializeField] GameObject a08;
    [SerializeField] GameObject a10;
    [SerializeField] GameObject a11;
    [SerializeField] GameObject a12;
    [SerializeField] GameObject a13;
    [SerializeField] GameObject a14;
    [SerializeField] GameObject a15;
    [SerializeField] GameObject a16;
    [SerializeField] GameObject a17;
    [SerializeField] GameObject a18;
    [SerializeField] GameObject a20;
    [SerializeField] GameObject a21;
    [SerializeField] GameObject a22;
    [SerializeField] GameObject a23;
    [SerializeField] GameObject a24;
    [SerializeField] GameObject a25;
    [SerializeField] GameObject a26;
    [SerializeField] GameObject a27;
    [SerializeField] GameObject a28;
    [SerializeField] GameObject a30;
    [SerializeField] GameObject a31;
    [SerializeField] GameObject a32;
    [SerializeField] GameObject a33;
    [SerializeField] GameObject a34;
    [SerializeField] GameObject a35;
    [SerializeField] GameObject a36;
    [SerializeField] GameObject a37;
    [SerializeField] GameObject a38;
    [SerializeField] GameObject a40;
    [SerializeField] GameObject a41;
    [SerializeField] GameObject a42;
    [SerializeField] GameObject a43;
    [SerializeField] GameObject a44;
    [SerializeField] GameObject a45;
    [SerializeField] GameObject a46;
    [SerializeField] GameObject a47;
    [SerializeField] GameObject a48;
    [SerializeField] GameObject a50;
    [SerializeField] GameObject a51;
    [SerializeField] GameObject a52;
    [SerializeField] GameObject a53;
    [SerializeField] GameObject a54;
    [SerializeField] GameObject a55;
    [SerializeField] GameObject a56;
    [SerializeField] GameObject a57;
    [SerializeField] GameObject a58;
    [SerializeField] GameObject a60;
    [SerializeField] GameObject a61;
    [SerializeField] GameObject a62;
    [SerializeField] GameObject a63;
    [SerializeField] GameObject a64;
    [SerializeField] GameObject a65;
    [SerializeField] GameObject a66;
    [SerializeField] GameObject a67;
    [SerializeField] GameObject a68;
    [SerializeField] GameObject a70;
    [SerializeField] GameObject a71;
    [SerializeField] GameObject a72;
    [SerializeField] GameObject a73;
    [SerializeField] GameObject a74;
    [SerializeField] GameObject a75;
    [SerializeField] GameObject a76;
    [SerializeField] GameObject a77;
    [SerializeField] GameObject a78;
    [SerializeField] GameObject a80;
    [SerializeField] GameObject a81;
    [SerializeField] GameObject a82;
    [SerializeField] GameObject a83;
    [SerializeField] GameObject a84;
    [SerializeField] GameObject a85;
    [SerializeField] GameObject a86;
    [SerializeField] GameObject a87;
    [SerializeField] GameObject a88;

    [SerializeField] GameObject ap1Have;
    [SerializeField] GameObject ap2Have;

    //Color
    Color noColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    Color whiteGray = new Color(0.9f, 0.9f, 0.9f, 1.0f);
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        

    }
    public void startSetUp()
    {
        temp = new LongBoard();
        tempJson = new LongBoardOnJson();
        recordplaying = new BoardOnJsonRecord();
        LongKomaClass = new HowMoveLongKoma();
        face = new LongBoard();
        recordplaying = new BoardOnJsonRecord();
        LongKomaClass.CallStart();
        GameBasisObj.GetComponent<GameBasisScr>().setDE();
        LongObjCollection.SetActive(true);
    }

    public void startMainGame(int p1Deck, int p2Deck, int Fplayer, int Gt) {

        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().starttimer();
        player = Fplayer;
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().turn = -1;
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().changePlayerBg();
        startSetUp();

        LongKomaClass.CallStart();
        cleanBoard();
        cleanBoardFace();
        updateKinshi(1);
        updateKinshi(-1);


        Player1Type = p1Deck;
        Player2Type = p2Deck;

        //0 chess
        //1 shougi
        //2 xiangxi

        string DeckName = "LongDeck" + p1Deck.ToString();
            Addressables.LoadAssetAsync<TextAsset>(DeckName).Completed += handle =>
            {
                string inputP1Deck = handle.Result.ToString();
                tempJson = JsonUtility.FromJson<LongBoardOnJson>(inputP1Deck);
                for (int i = 5; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        temp.ban[i, j] = tempJson.ban[i * 9 + j];
                    }
                }
            };

            DeckName = "LongDeck" + p2Deck.ToString();
            Addressables.LoadAssetAsync<TextAsset>(DeckName).Completed += handle =>
            {
                string inputP2Deck = handle.Result.ToString();
                tempJson = JsonUtility.FromJson<LongBoardOnJson>(inputP2Deck);
                for (int i = 5; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        temp.ban[8 - i, 8 - j] = -1 * tempJson.ban[i * 9 + j];
                    }
                }

            };

        Invoke(nameof(loadOpening), 1f);
    }



    public void loadOpening()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
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
        recordplaying.gameType = 9;
        recordplaying.player1Type = Player1Type;
        recordplaying.player2Type = Player2Type;

        recordplaying.P1sideTime.Add((int)ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().totalTimeP1);
        recordplaying.P2sideTime.Add((int)ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().totalTimeP2);
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().turn++;
    }





    


    public void shougiPutKoma(int a) {
        if (a > 0 && p1ShougiKinshi == 0 || a<0 && p2ShougiKinshi == 0)
        {
            tempside = a;
            cleanBoardFace();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (temp.ban[i, j] == 0)
                    {
                        LongKomaClass.showPossibleMove(i, j, 1);
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
                float x = (float)((4 - j) * 0.1);
                float z = (float)((i - 4) * 0.11);
                GameObject obj = GameBasisObj.GetComponent<GameBasisScr>().getObjByNum(n);
                if (n > 0) { tempGameObj[i, j] = Instantiate(obj, new Vector3(x, 1.147f, z), Quaternion.identity); }
                else if (n < 0) { tempGameObj[i, j] = Instantiate(obj, new Vector3(x, 1.147f, z), Quaternion.Euler(0, 180, 0)); }
            }
        
    }

    public void findKoma(int num1, int num2)
    {
        tempx = num1;
        tempy = num2;

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
                tempside = temp.ban[tempx, tempy];
                if (KomaSelected == 0) { return; }
                else if (KomaSelected == 1 || KomaSelected == -1) { setBgSelected(tempx,tempy); LongKomaClass.findPawnMove(tempx,tempy); }
                else if (KomaSelected == 2 || KomaSelected == -2) { setBgSelected(tempx, tempy); LongKomaClass.findRookMove(tempx, tempy); }
                else if (KomaSelected == 3 || KomaSelected == -3) { setBgSelected(tempx, tempy); LongKomaClass.findKnightMove(tempx, tempy); }
                else if (KomaSelected == 4 || KomaSelected == -4) { setBgSelected(tempx, tempy); LongKomaClass.findBishopMove(tempx, tempy); }
                else if (KomaSelected == 5 || KomaSelected == -5) { setBgSelected(tempx, tempy); LongKomaClass.findQueenMove(tempx, tempy); }
                else if (KomaSelected == 6 || KomaSelected == -6) { setBgSelected(tempx, tempy); LongKomaClass.findKingMove(tempx, tempy); }
                else if (KomaSelected == 11 || KomaSelected == -11) { setBgSelected(tempx, tempy); LongKomaClass.findShougiHoMove(tempx, tempy); }
                else if (KomaSelected == 12 || KomaSelected == -12) { setBgSelected(tempx, tempy); LongKomaClass.findShougiKakuMove(tempx, tempy); }
                else if (KomaSelected == 13 || KomaSelected == -13) { setBgSelected(tempx, tempy); LongKomaClass.findShougiHishaMove(tempx, tempy); }
                else if (KomaSelected == 14 || KomaSelected == -14) { setBgSelected(tempx, tempy); LongKomaClass.findShougikurumaMove(tempx, tempy); }
                else if (KomaSelected == 15 || KomaSelected == -15) { setBgSelected(tempx, tempy); LongKomaClass.findShougiumaMove(tempx, tempy); }
                else if (KomaSelected == 16 || KomaSelected == -16) { setBgSelected(tempx, tempy); LongKomaClass.findShougiGinMove(tempx, tempy); }
                else if (KomaSelected == 17 || KomaSelected == -17) { setBgSelected(tempx, tempy); LongKomaClass.findShougiKinMove(tempx, tempy); }
                else if (KomaSelected == 18 || KomaSelected == -18) { setBgSelected(tempx, tempy); LongKomaClass.findShougiOuMove(tempx, tempy); }
                else if (KomaSelected == 21 || KomaSelected == -21) { setBgSelected(tempx, tempy); LongKomaClass.findXiangqiHeiMove(tempx, tempy); }
                else if (KomaSelected == 22 || KomaSelected == -22) { setBgSelected(tempx, tempy); LongKomaClass.findXinagqiHouMove(tempx, tempy); }
                else if (KomaSelected == 23 || KomaSelected == -23) { setBgSelected(tempx, tempy); LongKomaClass.findXinagqiKurumakuMove(tempx, tempy); }
                else if (KomaSelected == 24 || KomaSelected == -24) { setBgSelected(tempx, tempy); LongKomaClass.findXinagqiUmaMove(tempx, tempy); }
                else if (KomaSelected == 25 || KomaSelected == -25) { setBgSelected(tempx, tempy); LongKomaClass.findXinagqiSouMove(tempx, tempy); }
                else if (KomaSelected == 26 || KomaSelected == -26) { setBgSelected(tempx, tempy); LongKomaClass.findXinagqiSiMove(tempx, tempy); }
                else if (KomaSelected == 27 || KomaSelected == -27) { setBgSelected(tempx, tempy); LongKomaClass.findXinagqiShouMove(tempx, tempy); }
                else if (KomaSelected == 31 || KomaSelected == -31) { setBgSelected(tempx, tempy); LongKomaClass.findShougiKinMove(tempx, tempy); }
                else if (KomaSelected == 32 || KomaSelected == -32) { setBgSelected(tempx, tempy); LongKomaClass.findShougiTatuMove(tempx, tempy); }
                else if (KomaSelected == 33 || KomaSelected == -33) { setBgSelected(tempx, tempy); LongKomaClass.findShougiRyuMove(tempx, tempy); }
                else if (KomaSelected == 34 || KomaSelected == -34) { setBgSelected(tempx, tempy); LongKomaClass.findShougiKinMove(tempx, tempy); }
                else if (KomaSelected == 35 || KomaSelected == -35) { setBgSelected(tempx, tempy); LongKomaClass.findShougiKinMove(tempx, tempy); }
                else if (KomaSelected == 36 || KomaSelected == -36) { setBgSelected(tempx, tempy); LongKomaClass.findShougiKinMove(tempx, tempy); }

                //changehere
            }
        }

        shougiplayer1clicked = false;
        shougiplayer2clicked = false;
    }
    void setBgSelected(int a ,int b) 
    {
        Color tempcolor = whiteGray;
        if (tempside < 0) { tempcolor = Color.black; }
        findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().color = tempcolor;
        findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().sprite = komaSelectedBg;
    }
    void checkLast()
    {
        if (ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().turn + 1 == recordplaying.recordKomaBoard.Count) { }
        else {

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
        if (player == 1) { player = -1; ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().changePlayerBg(); if (p1ShougiKinshi != 0) { if (p1ShougiKinshi != 0) { p1ShougiKinshi--; }updateKinshi(1); } }
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
        float x = (float)((4 - tempy) * 0.1);
        float z = (float)((tempx - 4) * 0.11);
        moveHash.Add("position", new Vector3(x, 1.147f, z));
        moveHash.Add("time", 0.5f);
        iTween.MoveTo(movingObj, moveHash);
        tempGameObj[tempx, tempy] = tempGameObj[prex, prey];
        tempGameObj[prex, prey] = null;
        //check pawn 
        checkPromote();

    }
    void checkCastling(int a ) 
    {
        if (a == -2 && prex == 0 && prey == 0) { player2RookRightMove = true; }
        else if (a == -2 && prex == 0 && prey == 8) { player2RookLeftMove = true; }
        else if (a == -6 && prex == 0 && prey == 3) { player2KingMove = true; }
        else if (a == 2 && prex == 8 && prey == 8) { player1RookRightMove = true; }
        else if (a == 2 && prex == 8 && prey == 0) { player1RookLeftMove = true; }
        else if (a == 6 && prex == 8 && prey == 5) { player1KingMove = true; }
    }

    void moveShougiKoma() {
        SoundObj.GetComponent<MakeSE>().shotMoveSound();
        if (player == 1)
        {
            temp.ban[tempx, tempy] =  player1sideHave;
            player1sideHave = 0;
            var moveHash = new Hashtable();
            float x = (float)((4 - tempy) * 0.1);
            float z = (float)((tempx - 4) * 0.11);
            moveHash.Add("position", new Vector3(x, 1.147f, z));
            moveHash.Add("time", 1f);
            iTween.MoveTo(player1sideHaveObj, moveHash);
            tempGameObj[tempx, tempy] = player1sideHaveObj;
            player1sideHaveObj = null;
        }
        else if (player == -1)
        {
            temp.ban[tempx, tempy] =  player2sideHave;
            player2sideHave = 0;
            var moveHash = new Hashtable();
            float x = (float)((4 - tempy) * 0.1);
            float z = (float)((tempx - 4) * 0.11);
            moveHash.Add("position", new Vector3(x, 1.147f, z));
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
        killedObjNum = temp.ban[tempx,tempy];
        killedObj.GetComponent<Rigidbody>().isKinematic = false;
        movingObj = tempGameObj[prex, prey];
        int movingObjNum = temp.ban[prex, prey];
        //itwenen
        //add angle to here
        killedObj.GetComponent<Rigidbody>().mass = 0.4f * killedObj.GetComponent<Rigidbody>().mass;

        var moveHash = new Hashtable();
        float x = (float)((4 - tempy) * 0.1);
        float z = (float)((tempx - 4) * 0.11);
        moveHash.Add("position", new Vector3(x, 1.147f, z));
        moveHash.Add("time", 1f);
        iTween.MoveTo(movingObj, moveHash);
        

        if (killedObjNum == 6 || killedObjNum == 18 || killedObjNum == 27) { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 1, player); GameObject ContPlayCanvasObj = GameObject.Find("ContCanvasObj"); ContPlayCanvasObj.GetComponent<ContPlayCanvas>().openEndModal();winResult.text = "Player 2 Win"; }
        else if (killedObjNum == -6 || killedObjNum == -18 || killedObjNum == -27) { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 1, player); GameObject ContPlayCanvasObj = GameObject.Find("ContCanvasObj"); ContPlayCanvasObj.GetComponent<ContPlayCanvas>().openEndModal(); winResult.text = "Player 1 Win"; }
        else
        {


            if (!((Math.Abs(movingObjNum) / 10 == 1 || Math.Abs(movingObjNum) / 10  == 3)) && ((Player1Type == 1 && player == 1) || (Player2Type == 1 && player == -1)))
            {
                GameBasisObj.GetComponent<GameBasisScr>().ShowDE(movingObj, 1,player);
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
                        p1ShougiKinshi = 3;
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
                        p2ShougiKinshi = 3;
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
        else if (temp.ban[tempx, tempy] == -1 && tempx == 8) { changePawnKoma(); }
        else if (temp.ban[tempx, tempy] == 11 && (tempx < 3 || prex < 3)) { changeHoKoma(); }
        else if (temp.ban[tempx, tempy] == -11 && (tempx > 5 || prex > 5)) { changeHoKoma(); }
        else if (temp.ban[tempx, tempy] == 12 && (tempx < 3 || prex < 3)) { changeKakuKoma(); }
        else if (temp.ban[tempx, tempy] == -12 && (tempx > 5 || prex > 5)) { changeKakuKoma(); }
        else if (temp.ban[tempx, tempy] == 13 && (tempx < 3 || prex < 3)) { changeHishaKoma(); }
        else if (temp.ban[tempx, tempy] == -13 && (tempx > 5 || prex > 5)) { changeHishaKoma(); }
        else if (temp.ban[tempx, tempy] == 14 && (tempx < 3 || prex < 3)) { changeKoushaKoma(); }
        else if (temp.ban[tempx, tempy] == -14 && (tempx > 5 || prex > 5)) { changeKoushaKoma(); }
        else if (temp.ban[tempx, tempy] == 15 && (tempx < 3 || prex < 3)) { changeKeiKoma(); }
        else if (temp.ban[tempx, tempy] == -15 && (tempx > 5 || prex > 5)) { changeKeiKoma(); }
        else if (temp.ban[tempx, tempy] == 16 && (tempx < 3 || prex < 3)) { changeGinKoma(); }
        else if (temp.ban[tempx, tempy] == -16 && (tempx > 5 || prex > 5)) { changeGinKoma(); }

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
        GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 1, player);
        if (player == 1)
        {
            p1ShougiKinshi = 3; 
            if (player1sideHave != 0) { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(player1sideHaveObj, 0, player); }
            player1sideHave = -1 * killedObjNum;



            float x = killedObj.transform.position.x;
            float z = killedObj.transform.position.z;
            GameObject obj = GameBasisObj.GetComponent<GameBasisScr>().getObjByNum(player1sideHave);

            player1sideHaveObj = Instantiate(obj, new Vector3(x, 1.147f, z), Quaternion.identity);



            var moveHash2 = new Hashtable();
            moveHash2.Add("position", new Vector3(-0.64f, 1.1f, 0.414f));
            moveHash2.Add("time", 1f);
            iTween.RotateAdd(player1sideHaveObj, iTween.Hash("y", 360f, "time", 1f));
            iTween.MoveTo(player1sideHaveObj, moveHash2);
        }
        else
        {
            p2ShougiKinshi = 3; 
            if (player2sideHave != 0) { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(player2sideHaveObj, 0, player); }
            player2sideHave = -1 * killedObjNum;



            float x = killedObj.transform.position.x;
            float z = killedObj.transform.position.z;
            GameObject obj = GameBasisObj.GetComponent<GameBasisScr>().getObjByNum(player2sideHave); ;


            player2sideHaveObj = Instantiate(obj, new Vector3(x, 1.147f, z), Quaternion.Euler(0, 180, 0));


            var moveHash2 = new Hashtable();
            moveHash2.Add("position", new Vector3(0.64f, 1.1f, -0.414f));
            moveHash2.Add("time", 1f);
            iTween.RotateAdd(player2sideHaveObj, iTween.Hash("y", 360f, "time", 1f));
            iTween.MoveTo(player2sideHaveObj, moveHash2);
        }
    }

    public void shougiKeepKoma() { KeepShougiKoma(); doEnd(); }
    public void shougiNotKeepKoma() { GameBasisObj.GetComponent<GameBasisScr>().ShowDE(killedObj, 1, player); doEnd(); }





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


    //残す
    void doCastling() 
    {
        if (tempx == 0 && tempy == 1) { SubCastling(0,3,0,1); SubCastling(0, 0, 0, 2); }
        else if (tempx == 0 && tempy == 5) { SubCastling(0, 3,0,5); SubCastling(0, 8, 0, 4); }
        else if (tempx == 8 && tempy == 7) { SubCastling(8, 5,8,7); SubCastling(8, 8, 8, 6); }
        else if (tempx == 8 && tempy == 3) { SubCastling(8, 5,8,3); SubCastling(8, 0, 8, 4); }
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
        float x = (float)((4 - moveyAfter) * 0.1);
        float z = (float)((movexAfter - 4) * 0.11);
        moveHash.Add("position", new Vector3(x, 1.147f, z));
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
            else if (num2 == 6) { return a06; }
            else if (num2 == 7) { return a07; }
            else if (num2 == 8) { return a08; }
        }
        else if (num1 == 1)
        {
            if (num2 == 0) { return a10; }
            else if (num2 == 1) { return a11; }
            else if (num2 == 2) { return a12; }
            else if (num2 == 3) { return a13; }
            else if (num2 == 4) { return a14; }
            else if (num2 == 5) { return a15; }
            else if (num2 == 6) { return a16; }
            else if (num2 == 7) { return a17; }
            else if (num2 == 8) { return a18; }
        }
        else if (num1 == 2)
        {
            if (num2 == 0) { return a20; }
            else if (num2 == 1) { return a21; }
            else if (num2 == 2) { return a22; }
            else if (num2 == 3) { return a23; }
            else if (num2 == 4) { return a24; }
            else if (num2 == 5) { return a25; }
            else if (num2 == 6) { return a26; }
            else if (num2 == 7) { return a27; }
            else if (num2 == 8) { return a28; }
        }
        else if (num1 == 3)
        {
            if (num2 == 0) { return a30; }
            else if (num2 == 1) { return a31; }
            else if (num2 == 2) { return a32; }
            else if (num2 == 3) { return a33; }
            else if (num2 == 4) { return a34; }
            else if (num2 == 5) { return a35; }
            else if (num2 == 6) { return a36; }
            else if (num2 == 7) { return a37; }
            else if (num2 == 8) { return a38; }
        }
        else if (num1 == 4)
        {
            if (num2 == 0) { return a40; }
            else if (num2 == 1) { return a41; }
            else if (num2 == 2) { return a42; }
            else if (num2 == 3) { return a43; }
            else if (num2 == 4) { return a44; }
            else if (num2 == 5) { return a45; }
            else if (num2 == 6) { return a46; }
            else if (num2 == 7) { return a47; }
            else if (num2 == 8) { return a48; }
        }
        else if (num1 == 5)
        {
            if (num2 == 0) { return a50; }
            else if (num2 == 1) { return a51; }
            else if (num2 == 2) { return a52; }
            else if (num2 == 3) { return a53; }
            else if (num2 == 4) { return a54; }
            else if (num2 == 5) { return a55; }
            else if (num2 == 6) { return a56; }
            else if (num2 == 7) { return a57; }
            else if (num2 == 8) { return a58; }
        }
        else if (num1 == 6)
        {
            if (num2 == 0) { return a60; }
            else if (num2 == 1) { return a61; }
            else if (num2 == 2) { return a62; }
            else if (num2 == 3) { return a63; }
            else if (num2 == 4) { return a64; }
            else if (num2 == 5) { return a65; }
            else if (num2 == 6) { return a66; }
            else if (num2 == 7) { return a67; }
            else if (num2 == 8) { return a68; }
        }
        else if (num1 == 7)
        {
            if (num2 == 0) { return a70; }
            else if (num2 == 1) { return a71; }
            else if (num2 == 2) { return a72; }
            else if (num2 == 3) { return a73; }
            else if (num2 == 4) { return a74; }
            else if (num2 == 5) { return a75; }
            else if (num2 == 6) { return a76; }
            else if (num2 == 7) { return a77; }
            else if (num2 == 8) { return a78; }
        }
        else if (num1 == 8)
        {
            if (num2 == 0) { return a80; }
            else if (num2 == 1) { return a81; }
            else if (num2 == 2) { return a82; }
            else if (num2 == 3) { return a83; }
            else if (num2 == 4) { return a84; }
            else if (num2 == 5) { return a85; }
            else if (num2 == 6) { return a86; }
            else if (num2 == 7) { return a87; }
            else if (num2 == 8) { return a88; }
        }
        return null;
    }

    public void cleanBoardFace()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (findBoardFacePosition(i, j).GetComponent<SpriteRenderer>().color != noColor) { findBoardFacePosition(i, j).GetComponent<SpriteRenderer>().color = noColor; findBoardFacePosition(i, j).GetComponent<SpriteRenderer>().sprite = null; face.ban[i, j] = 0; }
            }
        }

        ap1Have.GetComponent<SpriteRenderer>().color = noColor;
        ap2Have.GetComponent<SpriteRenderer>().color = noColor;

    }
    public void cleanBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
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
        tempside = player * -1;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (player * temp.ban[i, j] == -6 || player * temp.ban[i, j] == -18 || player * temp.ban[i, j] == -27)
                {
                    if (!LongKomaClass.checkCheckmait(i, j)) {  GameObject ContPlayCanvasObj = GameObject.Find("ContCanvasObj"); ContPlayCanvasObj.GetComponent<ContPlayCanvas>().openCheckModal(); SoundObj.GetComponent<MakeSE>().shotCheckSound();}
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
    public void check06()
    {
        findKoma(0, 6);
    }
    public void check07()
    {
        findKoma(0, 7);
    }
    public void check08()
    {
        findKoma(0, 8);
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
    public void check16()
    {
        findKoma(1, 6);
    }
    public void check17()
    {
        findKoma(1, 7);
    }
    public void check18()
    {
        findKoma(1, 8);
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
    public void check26()
    {
        findKoma(2, 6);
    }
    public void check27()
    {
        findKoma(2, 7);
    }
    public void check28()
    {
        findKoma(2, 8);
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
    public void check36()
    {
        findKoma(3, 6);
    }
    public void check37()
    {
        findKoma(3, 7);
    }
    public void check38()
    {
        findKoma(3, 8);
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
    public void check46()
    {
        findKoma(4, 6);
    }
    public void check47()
    {
        findKoma(4, 7);
    }
    public void check48()
    {
        findKoma(4, 8);
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
    public void check56()
    {
        findKoma(5, 6);
    }
    public void check57()
    {
        findKoma(5, 7);
    }
    public void check58()
    {
        findKoma(5, 8);
    }
    public void check60()
    {
        findKoma(6, 0);
    }
    public void check61()
    {
        findKoma(6, 1);
    }
    public void check62()
    {
        findKoma(6, 2);
    }
    public void check63()
    {
        findKoma(6, 3);
    }
    public void check64()
    {
        findKoma(6, 4);
    }
    public void check65()
    {
        findKoma(6, 5);
    }
    public void check66()
    {
        findKoma(6, 6);
    }
    public void check67()
    {
        findKoma(6, 7);
    }
    public void check68()
    {
        findKoma(6, 8);
    }
    public void check70()
    {
        findKoma(7, 0);
    }
    public void check71()
    {
        findKoma(7, 1);
    }
    public void check72()
    {
        findKoma(7, 2);
    }
    public void check73()
    {
        findKoma(7, 3);
    }
    public void check74()
    {
        findKoma(7, 4);
    }
    public void check75()
    {
        findKoma(7, 5);
    }
    public void check76()
    {
        findKoma(7, 6);
    }
    public void check77()
    {
        findKoma(7, 7);
    }
    public void check78()
    {
        findKoma(7, 8);
    }
    public void check80()
    {
        findKoma(8, 0);
    }
    public void check81()
    {
        findKoma(8, 1);
    }
    public void check82()
    {
        findKoma(8, 2);
    }
    public void check83()
    {
        findKoma(8, 3);
    }
    public void check84()
    {
        findKoma(8, 4);
    }
    public void check85()
    {
        findKoma(8, 5);
    }
    public void check86()
    {
        findKoma(8, 6);
    }
    public void check87()
    {
        findKoma(8, 7);
    }
    public void check88()
    {
        findKoma(8, 8);
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
