/*
 * 作成者:宮崎洸
 * 説明  :渡された値に対応したひよこを出します
 * 
 */
 /*
  7/14 00:31 修正 配列名がわかり辛いので、aaaからHiyoko_Numに変更しました       By 足立
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiyokoManager : MonoBehaviour
{
    GameObject s_Flg_Manager;
    Flg_Manager flg;

    int[] Hiyoko_Num = new int[2];
    public GameObject Hiyoko1;      //毒×毒
    public GameObject Hiyoko2;      //毒×麻痺
    public GameObject Hiyoko3;      //毒×眠り
    public GameObject Hiyoko4;      //麻痺×麻痺
    public GameObject Hiyoko5;      //麻痺×眠り
    public GameObject Hiyoko6;      //眠り×眠り
    GameObject create_hiyoko;
    GameObject hiyoko;

    public Vector3 Create_Position;

    // Start is called before the first frame update
    void Start()
    {
        s_Flg_Manager = GameObject.Find("Scripts");
        flg = s_Flg_Manager.GetComponent<Flg_Manager>();
        Create_Position = new Vector3(-1.6f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(flg.In_Egg_Huka_Flg_01==true&&flg.Catch_Egg_Player_01==true&&
            flg.In_Egg_Huka_Flg_02 == true && flg.Catch_Egg_Player_02 == true)
        {
            flg.Set_Create_Hiyoko_Flg(true);
        }
        if (flg.Create_Hiyoko_Flg == true)
        {
            Hiyoko_Birth();
        }
    }

    public void Set_Egg_Information(int i,int n)//値を受け取る関数
    {
        //たまごの内部情報を受け取る
        Hiyoko_Num[i] = n ;
    }

    public void Hiyoko_Birth() //ひよこ誕生スクリプト
    {
        //渡された値に対応したひよこを出す
        //毒×毒     = 1
        //毒×麻痺   = 2
        //毒×眠り   = 3
        //麻痺×麻痺 = 4
        //麻痺×眠り = 6
        //眠り×眠り = 9
        
        int Infomation = Hiyoko_Num[0] * Hiyoko_Num[1];

        switch (Infomation)
        {
            case 1:
                create_hiyoko = Hiyoko1;
                break;
            case 2:
                create_hiyoko = Hiyoko2;
                break;
            case 3:
                create_hiyoko = Hiyoko3;
                break;
            case 4:
                create_hiyoko = Hiyoko4;
                break;
            case 6:
                create_hiyoko = Hiyoko5;
                break;
            case 9:
                create_hiyoko = Hiyoko6;
                break;
        }
        hiyoko = Instantiate(create_hiyoko, Create_Position, Quaternion.identity) as GameObject;
        hiyoko.name = "Hiyoko_" + Infomation;


        Hiyoko piyo = this.hiyoko.GetComponent<Hiyoko>();
        //piyo.Set_Hiyoko_Infomation(Infomation);
        //piyo.Set_Hiyoko_Position(Create_Position);

        //Hiyoko_Num[0] = 0;
        //Hiyoko_Num[1] = 0;
        flg.Set_Destroy_Egg(true);

        flg.Set_Create_Hiyoko_Flg(false);
    }

}
