using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class contPlayOffScr : MonoBehaviour
{

    [SerializeField] GameObject shortGame;
    [SerializeField] GameObject longGame;
    [SerializeField] GameObject shortGameRing;
    [SerializeField] GameObject longGameRing;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject LongObjCollection;
    [SerializeField] GameObject ShortObjCollection;
    [SerializeField] GameObject CameraObj;


    int Player1Deck = 0;
    int Player2Deck = 0;
    int Time = 1000;
    int FPlayer = 1;

    int gt = 6;


    [SerializeField] GameObject ContPlayTimeObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void clickShort()
    {
        gt = 6;
        shortGameRing.SetActive(true);
        longGameRing.SetActive(false);
    }

    public void clickLong()
    {
        gt = 9;
        shortGameRing.SetActive(false);
        longGameRing.SetActive(true);
        
    }
    public void clickPlay()
    {
        mainCanvas.SetActive(false);
        gamePanel.SetActive(true);
        CameraObj.GetComponent<CameraCont>().resetCamera();
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().startGame(Player1Deck, Player2Deck, Time * 60, FPlayer, gt);
    }

        public void clickPlayer1Deck0()
    {
        Player1Deck = 0;
    }
    public void clickPlayer1Deck1()
    {
        Player1Deck = 1;
    }
    public void clickPlayer1Deck2()
    {
        Player1Deck = 2;
    }
    public void clickPlayer1Deck3()
    {
        Player1Deck = 3;
    }
    public void clickPlayer1Deck4()
    {
        Player1Deck = 4;
    }
    public void clickPlayer1Deck5()
    {
        Player1Deck = 5;
    }
    public void clickPlayer1Deck6()
    {
        Player1Deck = 6;
    }
    public void clickPlayer2Deck0()
    {
        Player2Deck = 0;
    }
    public void clickPlayer2Deck1()
    {
        Player2Deck = 1;
    }
    public void clickPlayer2Deck2()
    {
        Player2Deck = 2;
    }
    public void clickPlayer2Deck3()
    {
        Player2Deck = 3;
    }
    public void clickPlayer2Deck4()
    {
        Player2Deck = 4;
    }
    public void clickPlayer2Deck5()
    {
        Player2Deck = 5;
    }
    public void clickPlayer2Deck6()
    {
        Player2Deck = 6;
    }

    public void clickFplayer1()
    {
        FPlayer = 1;
    }
    public void clickFplayerMinus1()
    {
        FPlayer = -1;
    }
    public void clickTime5()
    {
        Time = 1;
    }
    public void clickTime10()
    {
        Time = 10;
    }
    public void clickTime15()
    {
        Time = 15;
    }
    public void clickTime20()
    {
        Time = 20;
    }
    public void clickTime25()
    {
        Time = 25;
    }
    public void clickTime30()
    {
        Time = 30;
    }
    public void clickTime45()
    {
        Time = 45;
    }
    public void clickTime60()
    {
        Time = 60;
    }

    public void clickTime0()
    {
        Time = 1000;
    }

    public void loadSlot(int i)
    {
        CameraObj.GetComponent<CameraCont>().resetCamera();
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().loadRecord(i);
        gamePanel.SetActive(true);
        mainCanvas.SetActive(false);
    }


}
