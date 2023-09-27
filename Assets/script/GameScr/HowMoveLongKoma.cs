﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class HowMoveLongKoma 
{
     GameObject LongGameContObj;
     Sprite movepossible;
     Sprite killpossible;
     Sprite castlepossible;


    public void CallStart()
    {
        LongGameContObj = GameObject.Find("LongGameContObj");
        Addressables.LoadAssetAsync<Sprite>("movePossible").Completed += op =>
        {
            movepossible = op.Result;
        };
        Addressables.LoadAssetAsync<Sprite>("killPossible").Completed += op =>
        {
            killpossible = op.Result;
        };
        Addressables.LoadAssetAsync<Sprite>("castlePossible").Completed += op =>
        {
            castlepossible = op.Result;
        };
    }
    public void findXiangqiHeiMove(int x, int y)
    {
        if (x + 1 <= 8 && y + 0 <= 8 && x + 1 >= 0 && y - 0 >= 0) { showPossible(x + 1, y - 0); }
        if (x + 0 <= 8 && y - 1 <= 8 && x + 0 >= 0 && y - 1 >= 0) { showPossible(x + 0, y - 1); }
        if (x - 0 <= 8 && y + 1 <= 8 && x - 0 >= 0 && y + 1 >= 0) { showPossible(x - 0, y + 1); }
        if (x - 1 <= 8 && y + 0 <= 8 && x - 1 >= 0 && y + 0 >= 0) { showPossible(x - 1, y - 0); }
    }
    public void findXinagqiHouMove(int x, int y)
    {
        int tempx = x;
        int tempy = y;

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        bool tempMove = true;
        while (tempx != 8)
        {
            tempx++;
            if (temp.ban[tempx, tempy] == 0 && tempMove == true)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] != 0 && tempMove == true) { tempMove = false; }
            else if (temp.ban[tempx, tempy] * tempside < 0) { showPossibleMove(tempx, tempy, 2); tempx = 8; }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 8; }
        }
        tempx = x;
        tempy = y;
        tempMove = true;
        while (tempx != 0)
        {
            tempx--;
            if (temp.ban[tempx, tempy] == 0 && tempMove == true)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] != 0 && tempMove == true) { tempMove = false; }
            else if (temp.ban[tempx, tempy] * tempside < 0) { showPossibleMove(tempx, tempy, 2); tempx = 0; }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 0; }
        }
        tempx = x;
        tempy = y;
        tempMove = true;
        while (tempy != 8)
        {
            tempy++;
            if (temp.ban[tempx, tempy] == 0 && tempMove == true)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] != 0 && tempMove == true) { tempMove = false; }
            else if (temp.ban[tempx, tempy] * tempside < 0) { showPossibleMove(tempx, tempy, 2); tempy = 8; }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempy = 8; }
        }
        tempx = x;
        tempy = y;
        tempMove = true;
        while (tempy != 0)
        {
            tempy--;
            if (temp.ban[tempx, tempy] == 0 && tempMove == true)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] != 0 && tempMove == true) { tempMove = false; }
            else if (temp.ban[tempx, tempy] * tempside < 0) { showPossibleMove(tempx, tempy, 2); tempy = 0; }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempy = 0; }
        }
    }
    public void findXinagqiKurumakuMove(int x, int y) { findRookMove(x, y); }
    public void findXinagqiUmaMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        if (x + 2 <= 8 && y + 1 <= 8 && x + 2 >= 0 && y + 1 >= 0) { if (temp.ban[x + 1, y] == 0) showPossible(x + 2, y + 1); }
        if (x + 2 <= 8 && y - 1 <= 8 && x + 2 >= 0 && y - 1 >= 0) { if (temp.ban[x + 1, y] == 0) showPossible(x + 2, y - 1); }
        if (x + 1 <= 8 && y + 2 <= 8 && x + 1 >= 0 && y + 2 >= 0) { if (temp.ban[x, y + 1] == 0) showPossible(x + 1, y + 2); }
        if (x + 1 <= 8 && y - 2 <= 8 && x + 1 >= 0 && y - 2 >= 0) { if (temp.ban[x, y - 1] == 0) showPossible(x + 1, y - 2); }
        if (x - 2 <= 8 && y + 1 <= 8 && x - 2 >= 0 && y + 1 >= 0) { if (temp.ban[x - 1, y] == 0) showPossible(x - 2, y + 1); }
        if (x - 2 <= 8 && y - 1 <= 8 && x - 2 >= 0 && y - 1 >= 0) { if (temp.ban[x - 1, y] == 0) showPossible(x - 2, y - 1); }
        if (x - 1 <= 8 && y + 2 <= 8 && x - 1 >= 0 && y + 2 >= 0) { if (temp.ban[x, y + 1] == 0) showPossible(x - 1, y + 2); }
        if (x - 1 <= 8 && y - 2 <= 8 && x - 1 >= 0 && y - 2 >= 0) { if (temp.ban[x, y - 1] == 0) showPossible(x - 1, y - 2); }
    }
    public void findXinagqiSouMove(int x, int y)
    {
        if (x + 2 <= 8 && y + 2 <= 8 && x + 2 >= 0 && y + 2 >= 0) { showPossible(x + 2, y + 2); }
        if (x + 2 <= 8 && y - 2 <= 8 && x + 2 >= 0 && y - 2 >= 0) { showPossible(x + 2, y - 2); }
        if (x - 2 <= 8 && y + 2 <= 8 && x - 2 >= 0 && y + 2 >= 0) { showPossible(x - 2, y + 2); }
        if (x - 2 <= 8 && y - 2 <= 8 && x - 2 >= 0 && y - 2 >= 0) { showPossible(x - 2, y - 2); }
        if (x + 1 <= 8 && y + 1 <= 8 && x + 1 >= 0 && y + 1 >= 0) { showPossible(x + 1, y + 1); }
        if (x + 1 <= 8 && y - 1 <= 8 && x + 1 >= 0 && y - 1 >= 0) { showPossible(x + 1, y - 1); }
        if (x - 1 <= 8 && y + 1 <= 8 && x - 1 >= 0 && y + 1 >= 0) { showPossible(x - 1, y + 1); }
        if (x - 1 <= 8 && y - 1 <= 8 && x - 1 >= 0 && y - 1 >= 0) { showPossible(x - 1, y - 1); }
    }
    public void findXinagqiSiMove(int x, int y)
    {
        if (x + 1 <= 8 && y + 1 <= 8 && x + 1 >= 0 && y + 1 >= 0) { showPossible(x + 1, y + 1); }
        if (x + 1 <= 8 && y - 1 <= 8 && x + 1 >= 0 && y - 1 >= 0) { showPossible(x + 1, y - 1); }
        if (x - 1 <= 8 && y + 1 <= 8 && x - 1 >= 0 && y + 1 >= 0) { showPossible(x - 1, y + 1); }
        if (x - 1 <= 8 && y - 1 <= 8 && x - 1 >= 0 && y - 1 >= 0) { showPossible(x - 1, y - 1); }
    }
    public void findXinagqiShouMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        if (tempside > 0)
        {
            if (x + 1 >= 6 && y + 1 <= 5 && x + 1 <= 8 && y + 1 >= 3) { showPossible(x + 1, y + 1); }
            if (x + 1 >= 6 && y + 0 <= 5 && x + 1 <= 8 && y - 0 >= 3) { showPossible(x + 1, y - 0); }
            if (x + 1 >= 6 && y - 1 <= 5 && x + 1 <= 8 && y - 1 >= 3) { showPossible(x + 1, y - 1); }
            if (x + 0 >= 6 && y - 1 <= 5 && x + 0 <= 8 && y - 1 >= 3) { showPossible(x + 0, y - 1); }
            if (x - 0 >= 6 && y + 1 <= 5 && x - 0 <= 8 && y + 1 >= 3) { showPossible(x - 0, y + 1); }
            if (x - 1 >= 6 && y + 1 <= 5 && x - 1 <= 8 && y + 1 >= 3) { showPossible(x - 1, y + 1); }
            if (x - 1 >= 6 && y - 1 <= 5 && x - 1 <= 8 && y - 1 >= 3) { showPossible(x - 1, y - 1); }
            if (x - 1 >= 6 && y + 0 <= 5 && x - 1 <= 8 && y + 0 >= 3) { showPossible(x - 1, y - 0); }
        }
        else
        {
            if (x + 1 <= 2 && y + 1 <= 5 && x + 1 >= 0 && y + 1 >= 3) { showPossible(x + 1, y + 1); }
            if (x + 1 <= 2 && y + 0 <= 5 && x + 1 >= 0 && y - 0 >= 3) { showPossible(x + 1, y - 0); }
            if (x + 1 <= 2 && y - 1 <= 5 && x + 1 >= 0 && y - 1 >= 3) { showPossible(x + 1, y - 1); }
            if (x + 0 <= 2 && y - 1 <= 5 && x + 0 >= 0 && y - 1 >= 3) { showPossible(x + 0, y - 1); }
            if (x - 0 <= 2 && y + 1 <= 5 && x - 0 >= 0 && y + 1 >= 3) { showPossible(x - 0, y + 1); }
            if (x - 1 <= 2 && y + 1 <= 5 && x - 1 >= 0 && y + 1 >= 3) { showPossible(x - 1, y + 1); }
            if (x - 1 <= 2 && y - 1 <= 5 && x - 1 >= 0 && y - 1 >= 3) { showPossible(x - 1, y - 1); }
            if (x - 1 <= 2 && y + 0 <= 5 && x - 1 >= 0 && y + 0 >= 3) { showPossible(x - 1, y - 0); }
        }
    }

    public void findShougiHoMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        if (tempside > 0)
        {
            if (x > 0) { showPossible(x - 1, y); }
        }
        else
        {
            if (x < 8) { showPossible(x + 1, y); }
        }
    }
    public void findShougiHishaMove(int x, int y)
    {
        findRookMove(x, y);
    }
    public void findShougiTatuMove(int x, int y)
    {
        findBishopMove(x, y);
        findShougiOuMove(x, y);
    }
    public void findShougiKakuMove(int x, int y)
    {
        findBishopMove(x, y);
    }
    public void findShougiRyuMove(int x, int y)
    {
        findBishopMove(x, y);
        findShougiOuMove(x, y);
    }
    public void findShougikurumaMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        int tempx = x;
        int tempy = y;
        while (tempx != 8)
        {
            tempx++;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 8; }
            else { showPossibleMove(tempx, tempy, 2); tempx = 8; }
        }
        tempx = x;
        tempy = y;
        while (tempx != 0)
        {
            tempx--;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 0; }
            else { showPossibleMove(tempx, tempy, 2); tempx = 0; }
        }
    }
    public void findShougiumaMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        if (tempside > 0)
        {
            if (x - 2 <= 8 && y + 1 <= 8 && x - 2 >= 0 && y + 1 >= 0) { showPossible(x - 2, y + 1); }
            if (x - 2 <= 8 && y - 1 <= 8 && x - 2 >= 0 && y - 1 >= 0) { showPossible(x - 2, y - 1); }
        }
        else if (tempside < 0)
        {
            if (x + 2 <= 8 && y + 1 <= 8 && x + 2 >= 0 && y + 1 >= 0) { showPossible(x + 2, y + 1); }
            if (x + 2 <= 8 && y - 1 <= 8 && x + 2 >= 0 && y - 1 >= 0) { showPossible(x + 2, y - 1); }
        }
    }
    public void findShougiGinMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        if (x + 1 <= 8 && y + 1 <= 8 && x + 1 >= 0 && y + 1 >= 0) { showPossible(x + 1, y + 1); }
        if (x + 1 <= 8 && y + 0 <= 8 && x + 1 >= 0 && y - 0 >= 0 && tempside < 0) { showPossible(x + 1, y - 0); }
        if (x + 1 <= 8 && y - 1 <= 8 && x + 1 >= 0 && y - 1 >= 0) { showPossible(x + 1, y - 1); }
        if (x - 1 <= 8 && y + 1 <= 8 && x - 1 >= 0 && y + 1 >= 0) { showPossible(x - 1, y + 1); }
        if (x - 1 <= 8 && y - 1 <= 8 && x - 1 >= 0 && y - 1 >= 0) { showPossible(x - 1, y - 1); }
        if (x - 1 <= 8 && y + 0 <= 8 && x - 1 >= 0 && y + 0 >= 0 && tempside > 0) { showPossible(x - 1, y - 0); }
    }
    public void findShougiKinMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        if (x + 1 <= 8 && y + 1 <= 8 && x + 1 >= 0 && y + 1 >= 0 && tempside < 0) { showPossible(x + 1, y + 1); }
        if (x + 1 <= 8 && y + 0 <= 8 && x + 1 >= 0 && y - 0 >= 0) { showPossible(x + 1, y - 0); }
        if (x + 1 <= 8 && y - 1 <= 8 && x + 1 >= 0 && y - 1 >= 0 && tempside < 0) { showPossible(x + 1, y - 1); }
        if (x + 0 <= 8 && y - 1 <= 8 && x + 0 >= 0 && y - 1 >= 0) { showPossible(x + 0, y - 1); }
        if (x - 0 <= 8 && y + 1 <= 8 && x - 0 >= 0 && y + 1 >= 0) { showPossible(x - 0, y + 1); }
        if (x - 1 <= 8 && y + 1 <= 8 && x - 1 >= 0 && y + 1 >= 0 && tempside > 0) { showPossible(x - 1, y + 1); }
        if (x - 1 <= 8 && y - 1 <= 8 && x - 1 >= 0 && y - 1 >= 0 && tempside > 0) { showPossible(x - 1, y - 1); }
        if (x - 1 <= 8 && y + 0 <= 8 && x - 1 >= 0 && y + 0 >= 0) { showPossible(x - 1, y - 0); }
    }
    public void findShougiOuMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        if (x + 1 <= 8 && y + 1 <= 8 && x + 1 >= 0 && y + 1 >= 0) { showPossible(x + 1, y + 1); }
        if (x + 1 <= 8 && y + 0 <= 8 && x + 1 >= 0 && y - 0 >= 0) { showPossible(x + 1, y - 0); }
        if (x + 1 <= 8 && y - 1 <= 8 && x + 1 >= 0 && y - 1 >= 0) { showPossible(x + 1, y - 1); }
        if (x + 0 <= 8 && y - 1 <= 8 && x + 0 >= 0 && y - 1 >= 0) { showPossible(x + 0, y - 1); }
        if (x - 0 <= 8 && y + 1 <= 8 && x - 0 >= 0 && y + 1 >= 0) { showPossible(x - 0, y + 1); }
        if (x - 1 <= 8 && y + 1 <= 8 && x - 1 >= 0 && y + 1 >= 0) { showPossible(x - 1, y + 1); }
        if (x - 1 <= 8 && y - 1 <= 8 && x - 1 >= 0 && y - 1 >= 0) { showPossible(x - 1, y - 1); }
        if (x - 1 <= 8 && y + 0 <= 8 && x - 1 >= 0 && y + 0 >= 0) { showPossible(x - 1, y - 0); }
    }

    public void findPawnMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        if (tempside > 0) { if (x == 7 && temp.ban[x - 1, y] == 0) { if (temp.ban[x - 2, y] == 0) { showPossibleMove(x - 2, y, 1); } } }
        else { if (x == 1 && temp.ban[x + 1, y] == 0) { if (temp.ban[x + 2, y] == 0) { showPossibleMove(x + 2, y, 1); } } }
        if (tempside > 0)
        {
            if (x > 0) { if (temp.ban[x - 1, y] == 0) { showPossibleMove(x - 1, y, 1); } }
            if (y > 0) { if (temp.ban[x - 1, y - 1] < 0) { showPossibleMove(x - 1, y - 1, 2); } }
            if (y < 8) { if (temp.ban[x - 1, y + 1] < 0) { showPossibleMove(x - 1, y + 1, 2); } }
            if (x == 0) { }
        }
        else
        {
            if (x < 8) { if (temp.ban[x + 1, y] == 0) { showPossibleMove(x + 1, y, 1); } }
            if (y > 0) { if (temp.ban[x + 1, y - 1] > 0) { showPossibleMove(x + 1, y - 1, 2); } }
            if (y < 8) { if (temp.ban[x + 1, y + 1] > 0) { showPossibleMove(x + 1, y + 1, 2); } }
            if (x == 8) { }
        }

        //1 移動可能
        //2 kill可能
    }



    public void findBishopMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        int tempx = x;
        int tempy = y;
        while (tempx != 8 && tempy != 8)
        {
            tempx++;
            tempy++;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 8; }
            else { showPossibleMove(tempx, tempy, 2); tempx = 8; }

        }

        tempx = x;
        tempy = y;
        while (tempx != 0 && tempy != 8)
        {
            tempx--;
            tempy++;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 0; }
            else { showPossibleMove(tempx, tempy, 2); tempx = 0; }
        }

        tempx = x;
        tempy = y;

        while (tempy != 0 && tempx != 8)
        {
            tempx++;
            tempy--;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 8; }
            else { showPossibleMove(tempx, tempy, 2); tempx = 8; }
        }
        tempx = x;
        tempy = y;

        while (tempy != 0 && tempx != 0)
        {
            tempx--;
            tempy--;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 0; }
            else { showPossibleMove(tempx, tempy, 2); tempx = 0; }

        }
        //1 移動可能
        //2 kill可能
    }
    public void findKingMove(int x, int y)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;

        bool sh83 = false;
        bool sh87 = false;
        bool sh01 = false;
        bool sh05 = false;
        if (x == 8)
        {
            if (!LongGameContObj.GetComponent<LongGameCont>().player1KingMove && !LongGameContObj.GetComponent<LongGameCont>().player1RookLeftMove && temp.ban[8, 0] == 2 && temp.ban[8, 1] == 0 && temp.ban[8, 2] == 0 && temp.ban[8, 3] == 0 && temp.ban[8, 4] == 0 && checkCheckmait(8, 3) && checkCheckmait(8, 4) && checkCheckmait(8, 5)) { sh83 = true; }
            if (!LongGameContObj.GetComponent<LongGameCont>().player1KingMove && !LongGameContObj.GetComponent<LongGameCont>().player1RookRightMove && temp.ban[8, 8] == 2 && temp.ban[8, 7] == 0 && temp.ban[8, 6] == 0 && checkCheckmait(8, 7) && checkCheckmait(8, 6) && checkCheckmait(8, 5)) { sh87 = true; }
        }
        if (x == 0)
        {
            if (!LongGameContObj.GetComponent<LongGameCont>().player2KingMove && !LongGameContObj.GetComponent<LongGameCont>().player2RookRightMove && temp.ban[0, 0] == -2 && temp.ban[0, 1] == 0 && temp.ban[0, 2] == 0 && checkCheckmait(0, 1) && checkCheckmait(0, 2) && checkCheckmait(0, 3)) { sh01 = true; }
            if (!LongGameContObj.GetComponent<LongGameCont>().player2KingMove && !LongGameContObj.GetComponent<LongGameCont>().player2RookLeftMove && temp.ban[0, 8] == -2 &&temp.ban[0, 4] == 0 && temp.ban[0, 5] == 0 && temp.ban[0, 6] == 0 && temp.ban[0, 7] == 0 && checkCheckmait(0, 3) && checkCheckmait(0, 4) && checkCheckmait(0, 5)) { sh05 = true; }
        }


        if (sh83) { showCastlePossible(8, 3); }
        if (sh87) { showCastlePossible(8, 7); }
        if (sh01) { showCastlePossible(0, 1); }
        if (sh05) { showCastlePossible(0, 5); }


        if (x + 1 <= 8 && y + 1 <= 8 && x + 1 >= 0 && y + 1 >= 0) { showPossible(x + 1, y + 1); }
        if (x + 1 <= 8 && y + 0 <= 8 && x + 1 >= 0 && y - 0 >= 0) { showPossible(x + 1, y - 0); }
        if (x + 1 <= 8 && y - 1 <= 8 && x + 1 >= 0 && y - 1 >= 0) { showPossible(x + 1, y - 1); }
        if (x + 0 <= 8 && y - 1 <= 8 && x + 0 >= 0 && y - 1 >= 0) { showPossible(x + 0, y - 1); }
        if (x - 0 <= 8 && y + 1 <= 8 && x - 0 >= 0 && y + 1 >= 0) { showPossible(x - 0, y + 1); }
        if (x - 1 <= 8 && y + 1 <= 8 && x - 1 >= 0 && y + 1 >= 0) { showPossible(x - 1, y + 1); }
        if (x - 1 <= 8 && y - 1 <= 8 && x - 1 >= 0 && y - 1 >= 0) { showPossible(x - 1, y - 1); }
        if (x - 1 <= 8 && y + 0 <= 8 && x - 1 >= 0 && y + 0 >= 0) { showPossible(x - 1, y - 0); }
    }
    public bool checkCheckmait(int a, int b)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;

        bool result = true;
        int c = 0;

        int saveKoma = temp.ban[a, b];

        if (tempside > 0)
        {
            LongGameContObj.GetComponent<LongGameCont>().temp.ban[a, b] = 100;
            c = 1;
        }
        else if (tempside < 0)
        {
            LongGameContObj.GetComponent<LongGameCont>().temp.ban[a, b] = -100;
            c = -1;
        }

        LongGameContObj.GetComponent<LongGameCont>().tempside *= -1;
        LongGameContObj.GetComponent<LongGameCont>().cleanBoardFace();


        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {

                int tempfindAttack = temp.ban[i, j];
                if (tempfindAttack * c < 0)
                {
                    if (tempfindAttack == 0) { }
                    else if (tempfindAttack == 1 || tempfindAttack == -1) { findPawnMove(i, j); }
                    else if (tempfindAttack == 2 || tempfindAttack == -2) { findRookMove(i, j); }
                    else if (tempfindAttack == 3 || tempfindAttack == -3) { findKnightMove(i, j); }
                    else if (tempfindAttack == 4 || tempfindAttack == -4) { findBishopMove(i, j); }
                    else if (tempfindAttack == 5 || tempfindAttack == -5) { findQueenMove(i, j); }
                    else if (tempfindAttack == 6 || tempfindAttack == -6) { findKingMove(i, j); }
                    else if (tempfindAttack == 11 || tempfindAttack == -11) { findShougiHoMove(i, j); }
                    else if (tempfindAttack == 12 || tempfindAttack == -12) { findShougiKakuMove(i, j); }
                    else if (tempfindAttack == 13 || tempfindAttack == -13) { findShougiHishaMove(i, j); }
                    else if (tempfindAttack == 14 || tempfindAttack == -14) { findShougikurumaMove(i, j); }
                    else if (tempfindAttack == 15 || tempfindAttack == -15) { findShougiumaMove(i, j); }
                    else if (tempfindAttack == 16 || tempfindAttack == -16) { findShougiGinMove(i, j); }
                    else if (tempfindAttack == 17 || tempfindAttack == -17) { findShougiKinMove(i, j); }
                    else if (tempfindAttack == 18 || tempfindAttack == -18) { findShougiOuMove(i, j); }
                    else if (tempfindAttack == 21 || tempfindAttack == -21) { findXiangqiHeiMove(i, j); }
                    else if (tempfindAttack == 22 || tempfindAttack == -22) { findXinagqiHouMove(i, j); }
                    else if (tempfindAttack == 23 || tempfindAttack == -23) { findXinagqiKurumakuMove(i, j); }
                    else if (tempfindAttack == 24 || tempfindAttack == -24) { findXinagqiUmaMove(i, j); }
                    else if (tempfindAttack == 25 || tempfindAttack == -25) { findXinagqiSouMove(i, j); }
                    else if (tempfindAttack == 26 || tempfindAttack == -26) { findXinagqiSiMove(i, j); }
                    else if (tempfindAttack == 27 || tempfindAttack == -27) { findXinagqiShouMove(i, j); }
                    else if (tempfindAttack == 31 || tempfindAttack == -31) { findShougiKinMove(i, j); }
                    else if (tempfindAttack == 32 || tempfindAttack == -32) { findShougiTatuMove(i, j); }
                    else if (tempfindAttack == 33 || tempfindAttack == -33) { findShougiRyuMove(i, j); }
                    else if (tempfindAttack == 34 || tempfindAttack == -34) { findShougiKinMove(i, j); }
                    else if (tempfindAttack == 35 || tempfindAttack == -35) { findShougiKinMove(i, j); }
                    else if (tempfindAttack == 36 || tempfindAttack == -36) { findShougiKinMove(i, j); }
                }

                if (LongGameContObj.GetComponent<LongGameCont>().face.ban[a, b] == -2 * c) { result = false; }
                LongGameContObj.GetComponent<LongGameCont>().cleanBoardFace();
            }
        }

        LongGameContObj.GetComponent<LongGameCont>().tempside *= -1;

        LongGameContObj.GetComponent<LongGameCont>().temp.ban[a, b] = saveKoma;
        return result;
    }
    void showCastlePossible(int a, int b)
    {

        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        Color tempcolor = new Color(0.9f, 0.9f, 0.9f, 1.0f);
        if (tempside < 0) { tempcolor = Color.black; }

        LongGameContObj.GetComponent<LongGameCont>().findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().color = tempcolor;
        LongGameContObj.GetComponent<LongGameCont>().findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().sprite = castlepossible;
        if (tempside > 0) { LongGameContObj.GetComponent<LongGameCont>().face.ban[a, b] = 3; }
        else { LongGameContObj.GetComponent<LongGameCont>().face.ban[a, b] = -1 * 3; }
    }


    public void findRookMove(int x, int y)
    {
        LongBoard temp = LongGameContObj.GetComponent<LongGameCont>().temp;
        int tempside = LongGameContObj.GetComponent<LongGameCont>().tempside;
        int tempx = x;
        int tempy = y;
        while (tempx != 8)
        {
            tempx++;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 8; }
            else { showPossibleMove(tempx, tempy, 2); tempx = 8; }
        }
        tempx = x;
        tempy = y;
        while (tempx != 0)
        {
            tempx--;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempx = 0; }
            else { showPossibleMove(tempx, tempy, 2); tempx = 0; }
        }
        tempx = x;
        tempy = y;
        while (tempy != 8)
        {
            tempy++;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempy = 8; }
            else { showPossibleMove(tempx, tempy, 2); tempy = 8; }
        }
        tempx = x;
        tempy = y;
        while (tempy != 0)
        {
            tempy--;
            if (temp.ban[tempx, tempy] == 0)
            {
                showPossibleMove(tempx, tempy, 1);
            }
            else if (temp.ban[tempx, tempy] * tempside > 0) { tempy = 0; }
            else { showPossibleMove(tempx, tempy, 2); tempy = 0; }
        }


    }
    public void findQueenMove(int x, int y)
    {
        findBishopMove(x, y);
        findRookMove(x, y);
    }
    public void findKnightMove(int x, int y)
    {
        if (x + 2 <= 8 && y + 1 <= 8 && x + 2 >= 0 && y + 1 >= 0) { showPossible(x + 2, y + 1); }
        if (x + 2 <= 8 && y - 1 <= 8 && x + 2 >= 0 && y - 1 >= 0) { showPossible(x + 2, y - 1); }
        if (x + 1 <= 8 && y + 2 <= 8 && x + 1 >= 0 && y + 2 >= 0) { showPossible(x + 1, y + 2); }
        if (x + 1 <= 8 && y - 2 <= 8 && x + 1 >= 0 && y - 2 >= 0) { showPossible(x + 1, y - 2); }
        if (x - 2 <= 8 && y + 1 <= 8 && x - 2 >= 0 && y + 1 >= 0) { showPossible(x - 2, y + 1); }
        if (x - 2 <= 8 && y - 1 <= 8 && x - 2 >= 0 && y - 1 >= 0) { showPossible(x - 2, y - 1); }
        if (x - 1 <= 8 && y + 2 <= 8 && x - 1 >= 0 && y + 2 >= 0) { showPossible(x - 1, y + 2); }
        if (x - 1 <= 8 && y - 2 <= 8 && x - 1 >= 0 && y - 2 >= 0) { showPossible(x - 1, y - 2); }
    }
    public void showPossible(int a, int b)
    {

        if (LongGameContObj.GetComponent<LongGameCont>().temp.ban[a, b] == 0) { showPossibleMove(a, b, 1); }
        else if (LongGameContObj.GetComponent<LongGameCont>().temp.ban[a, b] * LongGameContObj.GetComponent<LongGameCont>().tempside < 0) { showPossibleMove(a, b, 2); }

    }

    public void showPossibleMove(int a, int b, int c)
    {
        Color tempcolor = new Color(0.9f, 0.9f, 0.9f, 1.0f);
        if (LongGameContObj.GetComponent<LongGameCont>().tempside < 0) { tempcolor = Color.black; }

        LongGameContObj.GetComponent<LongGameCont>().findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().color = tempcolor;
        if (c == 1) { LongGameContObj.GetComponent<LongGameCont>().findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().sprite = movepossible; }
        else { LongGameContObj.GetComponent<LongGameCont>().findBoardFacePosition(a, b).GetComponent<SpriteRenderer>().sprite = killpossible; }
        if (LongGameContObj.GetComponent<LongGameCont>().tempside > 0) { LongGameContObj.GetComponent<LongGameCont>().face.ban[a, b] = c; }
        else { LongGameContObj.GetComponent<LongGameCont>().face.ban[a, b] = -1 * c; }
    }
}
