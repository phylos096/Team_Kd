using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Flg_Manager : MonoBehaviour
{

    public bool onece;

    public bool In_Egg_Huka_Flg_01;
    public bool In_Egg_Huka_Flg_02;

    public bool Catch_Egg_Player_01;
    public bool Catch_Egg_Player_02;

    public bool Create_Hiyoko_Flg;

    public bool Destory_Egg;
    public bool Destory_Egg_01;
    public bool Destory_Egg_02;

    public bool Adachi_Work;
    public bool Adachi_Stop;
    public bool Adachi_Mahi;
    public bool Adachi_Sleep;
    public bool Adachi_Doku;

    public bool Game_Over;
    public bool game_Clear;

    // Start is called before the first frame update
    void Start()
    {
        onece = false;

        In_Egg_Huka_Flg_01 = false;
        In_Egg_Huka_Flg_02 = false;
        Catch_Egg_Player_01 = false;
        Catch_Egg_Player_02 = false;
        Create_Hiyoko_Flg = false;
        Destory_Egg = false;
        Destory_Egg_01 = false;
        Destory_Egg_02 = false;

        Adachi_Mahi = false;
        Adachi_Stop = false;
        Adachi_Work = false;
        Adachi_Sleep = false;
        Adachi_Doku = false;

        Game_Over = false;
        game_Clear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(onece == false)
        {
            Reset();
            onece = true;
        }
        if (Create_Hiyoko_Flg == true)
        {
            In_Egg_Huka_Flg_01 = false;
            In_Egg_Huka_Flg_02 = false;
            Catch_Egg_Player_01 = false;
            Catch_Egg_Player_02 = false;
        }
        if (Destory_Egg_01 == true && Destory_Egg_02 == true)
        {
            Destory_Egg = false;
            Destory_Egg_01 = false;
            Destory_Egg_02 = false;
        }
    }

    public void Set_In_Egg_Huka_Flg_01(bool n)
    {
        In_Egg_Huka_Flg_01 = n;
    }

    public void Set_In_Egg_Huka_Flg_02(bool n) {
        In_Egg_Huka_Flg_02 = n;
    }

    public void Set_Catch_Egg_Player_01(bool n)
    {
        Catch_Egg_Player_01 = n;
    }

    public void Set_Catch_Egg_Player_02(bool n)
    {
        Catch_Egg_Player_02 = n;
    }

    public void Set_Create_Hiyoko_Flg(bool n)
    {
        Create_Hiyoko_Flg = n;
    }

    public void Set_Destroy_Egg(bool n)
    {
        Destory_Egg = n;
    }

    public void Set_Destroy_Egg_01(bool n)
    {
        Destory_Egg_01 = n;
    }
    public void Set_Destroy_Egg_02(bool n)
    {
        Destory_Egg_02 = n;
    }

    public void Set_Adachi_Stop(bool n)
    {
        Adachi_Stop = n;
    }

    public void Set_Adachi_Work(bool n)
    {
        Adachi_Work = n;
    }

    public void Set_Adachi_Mahi(bool n)
    {
        Adachi_Mahi = n;
    }

    public void Set_Adachi_Sleep(bool n)
    {
        Adachi_Sleep = n;
    }

    public void Set_Adachi_Doku(bool n)
    {
        Adachi_Doku = n;
    }

    public void ReSet_Adachi_Flg()
    {
        Adachi_Stop = false;
        Adachi_Work = false;
        Adachi_Sleep = false;
        Adachi_Mahi = false;
        Adachi_Doku = false;

    }

    public void Set_Game_Over(bool n)
    {

        Game_Over = n;
        onece = false;
        SceneManager.LoadScene("Result");
    }

    public void Set_Game_Clear(bool n)
    {
        game_Clear = n;
    }


    public void Reset()
    {

        In_Egg_Huka_Flg_01 = false;
        In_Egg_Huka_Flg_02 = false;
        Catch_Egg_Player_01 = false;
        Catch_Egg_Player_02 = false;
        Create_Hiyoko_Flg = false;
        Destory_Egg = false;
        Destory_Egg_01 = false;
        Destory_Egg_02 = false;

        Adachi_Mahi = false;
        Adachi_Stop = false;
        Adachi_Work = false;
        Adachi_Sleep = false;
        Adachi_Doku = false;

        Game_Over = false;
        game_Clear = false;
    }
}
