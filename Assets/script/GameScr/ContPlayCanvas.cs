using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContPlayCanvas : MonoBehaviour
{
    [SerializeField] GameObject ContPlayTimeObj;
    bool saveOpen = false;
    bool homeOpen = false;
    [SerializeField] GameObject saveModal;
    [SerializeField] GameObject endModal;
    [SerializeField] GameObject homeModal;
    [SerializeField] GameObject checkModal;
    [SerializeField] GameObject chessPromoteModal;

    [SerializeField] GameObject shougiPromoteModal;
    [SerializeField] GameObject shougiKeepModal;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject homeCanvas;
    [SerializeField] GameObject bottomPanel;
    [SerializeField] GameObject LongGameContObj;
    [SerializeField] GameObject ShortGameContObj;
    [SerializeField] GameObject LongObjCollection;
    [SerializeField] GameObject ShortObjCollection;

    public int gt = 9;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickedBefore()
    {
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().showBeforeRecord();
    }
    public void clickedNext()
    {
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().showNextRecord();
    }
    public void clickedStop()
    {
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().clickStopButton();
    }

    void stopTime()
    {
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().stoptime = true;
    }

    void restartTime()
    {
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().stoptime = false;
    }
    public void openEndModal()
    {

        Invoke("subEndModal", 1.7f);
    }
    void subEndModal() 
    {
        endModal.GetComponent<ModalWindowManager>().OpenWindow();
    }

    public void openCheckModal()
    {

        checkModal.GetComponent<NotificationManager>().OpenNotification();
    }
    public void saveModalClicked() 
    {
        if (homeOpen) { homeModal.GetComponent<ModalWindowManager>().CloseWindow(); homeOpen = false; bottomPanel.SetActive(true); }
        if (saveOpen) { saveModal.GetComponent<ModalWindowManager>().CloseWindow(); saveOpen = false;restartTime();bottomPanel.SetActive(true); }
        else { saveModal.GetComponent<ModalWindowManager>().OpenWindow(); saveOpen = true; stopTime(); bottomPanel.SetActive(false); }

    }
    public void homeModalClicked()
    {
        if (saveOpen) { saveModal.GetComponent<ModalWindowManager>().CloseWindow(); saveOpen = false; bottomPanel.SetActive(true); }
        if (homeOpen) { homeModal.GetComponent<ModalWindowManager>().CloseWindow(); homeOpen = false; restartTime(); bottomPanel.SetActive(true); }
        else { homeModal.GetComponent<ModalWindowManager>().OpenWindow(); homeOpen = true; stopTime(); bottomPanel.SetActive(false);}
    }
    public void subHomeclicked()
    {
        deleteAllmodal();
        homeOpen = false;
        saveOpen = false;
        /* 
        GameContObj.GetComponent<GameCont>().recordplaying = null;
        GameContObj.GetComponent<GameCont>().temp = null;
        GameContObj.GetComponent<GameCont>().tempJson = null;*/
        LongObjCollection.SetActive(false);
        ShortObjCollection.SetActive(false);
        LongGameContObj.SetActive(false);
        ShortGameContObj.SetActive(false);
        bottomPanel.SetActive(true);
        GamePanel.SetActive(false);
        homeCanvas.SetActive(true);
    }
    public void subSaveClicked()
    {
        homeModal.GetComponent<ModalWindowManager>().CloseWindow();
        saveOpen = false;
        saveModalClicked();
    }
    public void subRetryClicked()
    {
        homeModalClicked();
        ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().showBeforeRecord();
        endModal.GetComponent<ModalWindowManager>().CloseWindow();
    }

    void deleteAllmodal() 
    {
        if (ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().gt == 9)
        {
            LongGameContObj.GetComponent<LongGameCont>().cleanBoardFace();
            LongGameContObj.GetComponent<LongGameCont>().cleanBoard();
            LongGameContObj.SetActive(false);
        }
        else if (ContPlayTimeObj.GetComponent<ContPlayTimeTurn>().gt == 6)
        {
            ShortGameContObj.GetComponent<ShortGameCont>().cleanBoardFace();
            ShortGameContObj.GetComponent<ShortGameCont>().cleanBoard();
            LongGameContObj.SetActive(false);
        }
        homeModal.GetComponent<ModalWindowManager>().CloseWindow();
        saveModal.GetComponent<ModalWindowManager>().CloseWindow();
        chessPromoteModal.GetComponent<ModalWindowManager>().CloseWindow();
        shougiKeepModal.GetComponent<ModalWindowManager>().CloseWindow();
        shougiPromoteModal.GetComponent<ModalWindowManager>().CloseWindow();
        endModal.GetComponent<ModalWindowManager>().CloseWindow();
    }


}
