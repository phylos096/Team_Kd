using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    GameObject s_Flg_Manager;
    Flg_Manager flg;

    GameObject s_Create_Egg;
    Create_Egg create_egg;

    GameObject s_Hiyoko_Manager;
    HiyokoManager hiyokomanager;

    [SerializeField] Vector3 Egg_Position;
    
    //なんの卵か情報を持つ
    [SerializeField]int Egg_Infomation;
    [SerializeField] int Egg_Create_Num;

    bool Catch_Player_01;
    bool Catch_Player_02;
    
    // Start is called before the first frame update
    void Start()
    {
        s_Flg_Manager = GameObject.Find("Scripts");
        flg = s_Flg_Manager.GetComponent<Flg_Manager>();
        s_Create_Egg = GameObject.Find("Scripts");
        create_egg = s_Create_Egg.GetComponent<Create_Egg>();
        s_Hiyoko_Manager = GameObject.Find("Scripts");
        hiyokomanager = s_Hiyoko_Manager.GetComponent<HiyokoManager>();

        Catch_Player_01 = false;
        Catch_Player_02 = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (flg.In_Egg_Huka_Flg_01 == true && flg.In_Egg_Huka_Flg_02 == true &&
            flg.Catch_Egg_Player_01 == true && flg.Catch_Egg_Player_02 == true &&
            (Catch_Player_01 == true || Catch_Player_02 == true))
        {
            flg.Set_Create_Hiyoko_Flg(true);
            flg.Set_Destroy_Egg(true);
            Destroy(gameObject, 0f);
            
        }*/

        if (flg.Destory_Egg == true)
        {
            if (Catch_Player_01 == true)
            {
                flg.Set_Destroy_Egg_01(true);
                flg.Set_Catch_Egg_Player_01(false);
                flg.Set_In_Egg_Huka_Flg_01(false);
                Destroy(gameObject, 0f);
            }
            if (Catch_Player_02 == true)
            {
                flg.Set_Destroy_Egg_02(true);
                flg.Set_Catch_Egg_Player_02(false);
                flg.Set_In_Egg_Huka_Flg_02(false);
                Destroy(gameObject, 0f);
            }
        }

        if (Catch_Player_01 == true)
        {
            Egg_Position = GameObject.Find("Player01").transform.position;
            Egg_Position -= new Vector3(0, 0.5f, 0);
        }
        if (Catch_Player_02 == true)
        {
            Egg_Position = GameObject.Find("Player02").transform.position;
            Egg_Position -= new Vector3(0, 0.5f, 0);
        }

        transform.position = Egg_Position;

        /*if (flg.Destory_Egg == true)
        {
            if (Catch_Player_01 == true)
            {
                flg.Set_Catch_Egg_Player_01(false);
                flg.Set_In_Egg_Huka_Flg_01(false);
            }
            if (Catch_Player_02 == true)
            {
                flg.Set_Catch_Egg_Player_02(false);
                flg.Set_In_Egg_Huka_Flg_02(false);
            }
            flg.Set_Destroy_Egg(false);
            Destroy(this.gameObject, 0f);
        }*/
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //壁のコライダーにぶつかった瞬間
        if (coll.tag == "Wall")
        {
            if (Catch_Player_01 == true )
            {
                flg.Set_In_Egg_Huka_Flg_01(true);
                hiyokomanager.Set_Egg_Information(0,Egg_Infomation);

            }
            if (Catch_Player_02 == true)
            {
                flg.Set_In_Egg_Huka_Flg_02(true);
                hiyokomanager.Set_Egg_Information(1, Egg_Infomation);
            }
        }

        /*もし、ぶつかってきたPlayerが、
        たまごを持っている状態ではないとき
        */
        if (coll.name.Equals("Player01") && Catch_Player_02 == false && flg.Catch_Egg_Player_01 == false)
        {
            Catch_Player_01 = true;
            flg.Set_Catch_Egg_Player_01(true);
            create_egg.Set_Create_Flg(Egg_Create_Num);
        }
        else if (coll.name.Equals("Player02") && Catch_Player_01 == false && flg.Catch_Egg_Player_02 == false)
        {
            Catch_Player_02 = true;
            flg.Set_Catch_Egg_Player_02(true);
            create_egg.Set_Create_Flg(Egg_Create_Num);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Wall")
        {
            if (Catch_Player_01 == true)
            {
                flg.Set_In_Egg_Huka_Flg_01(false);
            }
            if (Catch_Player_02 == true)
            {
                flg.Set_In_Egg_Huka_Flg_02(false);
            }
        }
    }
    
    /// <summary>
    /// <para>
    /// Create_Eggクラスでの生成時に
    /// たまごの内部情報を設定する
    /// </para><para>
    /// 作成者:足立拓海
    /// </para>
    /// </summary>
    public void Set_Egg_Infomation(int n, int m)
    {
        Egg_Infomation = n;
        Egg_Create_Num = m;
    }
    
    /// <summary>
    /// <para>
    /// Eggの座標の設定
    /// </para><para>
    /// 作成者:足立拓海
    /// </para>
    /// </summary>
    public void Set_Egg_Position(Vector3 Set_Position)
    {
        Egg_Position = Set_Position;
    }
  
}