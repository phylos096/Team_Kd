/*
 * 作成者:宮崎洸
 * 説明  :アダチ君(敵)を左に移動させるスクリプトです
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject s_Flg_Manager;
    Flg_Manager flg;

    GameObject s_Adachi_Hp;
    Adachi_HP Hp;
    
    public float speed;

    public float Sleep_Timer;
    public float Timer;
    bool Sleep_Flg;

    public float Mahi_Timer;
    bool Mahi_Flg;

    public float Doku_Timer;
    bool Doku_Flg;

    public int Adachi_State;
    // Start is called before the first frame update
    void Start()
    {
        s_Flg_Manager = GameObject.Find("Scripts");
        flg = s_Flg_Manager.GetComponent<Flg_Manager>();
        s_Adachi_Hp = GameObject.Find("Adachi");
        Hp = s_Adachi_Hp.GetComponent<Adachi_HP>();
        Adachi_State = 1;
        Sleep_Flg = false;
        Mahi_Flg = false;
        Doku_Flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Sleep_Flg == true)
        {
            Timer = Time.deltaTime;
            Sleep_Timer -= Timer;
            if (Sleep_Timer < 0)
            {
                Sleep_Timer = 0;
                Set_Sleep_Flg(false);
                Timer = 0;
            }
        }
        else if (Mahi_Flg == true)
        {
            Timer = Time.deltaTime;
            Mahi_Timer -= Timer;
            if (Mahi_Timer < 0)
            {
                Mahi_Timer = 0;
                Set_Mahi_Flg(false);
                Timer = 0;
            }
        }
        if(Doku_Flg == true)
        {
            Timer = Time.deltaTime;
            Doku_Timer -= Timer;

            Hp.Poizon_Dameger(0.05f);
            
            if (Doku_Timer < 0)
            {
                Doku_Timer = 0;
                Set_Doku_Flg(false);

                Timer = 0;
            }
        }

        if (Sleep_Flg == false && Mahi_Flg == false && Doku_Flg == false)
        {
            Adachi_State = 0;
            Set_Adachi_Animation(1);
        }

        Move_Adachi();

        
    }

    void Move_Adachi()
    {
        switch (Adachi_State)
        {
            case 0:
                //何もなし
                transform.position -= new Vector3(speed, 0, 0);
                break;
            case 1://毒毒普通に移動するが、ダメージを受けている。
                this.gameObject.transform.Translate(-speed, 0, 0);//speedの値に移動
                break;
            case 2://マヒ毒で移動速度低下、ダメージを受ける
                transform.position -= new Vector3(speed / 2, 0, 0);
                break;
            case 3:
                //眠りだと動かない(起きるまで時間少な目)、ダメージを受ける。
                break;
            case 4:　
                //マヒマヒで移動速度、を4分の一にする。
                transform.position -= new Vector3(speed / 4, 0, 0);
                break;
            case 6:
                //マヒ眠りで起きた後も少し止まった状態にする

                break;
            case 9:
                //深い眠り
                break;

        }
    }

    public void Set_Sleep_Timer(float n)
    {
        Sleep_Timer = n;
        Timer = 0;
        Set_Adachi_Animation(2);
    }

    public void Set_Sleep_Timer()
    {
        Sleep_Timer = 5;
        Timer = 0;
        Set_Adachi_Animation(2);
    }

    public void Set_Sleep_Flg(bool n)
    {
        Sleep_Flg = n;
    }
    
    public void Set_Mahi_Timer()
    {
        Mahi_Timer = 5;
        Timer = 0;
        Set_Adachi_Animation(3);
    }

    public void Set_Mahi_Timer(float n)
    {
        Mahi_Timer = n;
        Timer = 0;
        Set_Adachi_Animation(3);
    }

    public void Set_Mahi_Flg(bool n)
    {
        Mahi_Flg = n;
    }

    public void Set_Doku_Timer()
    {
        Doku_Timer = 5;
        Timer = 0;
        Set_Adachi_Animation(4);
    }

    public void Set_Doku_Timer(float n)
    {
        Doku_Timer = n;
        Timer = 0;
        Set_Adachi_Animation(4);
    }

    public void Set_Doku_Flg(bool n)
    {
        Doku_Flg = n;
    }

    //作成者:足立拓海
    //ヒヨコがあだちに近づき食べられた時の、効果の設定
    public void Set_Adachi_State(int n)
    {
        Adachi_State = n;
    }

    public void Set_Adachi_Animation(int n)
    {
        flg.ReSet_Adachi_Flg();
        switch (n)
        {
            case 1:
                flg.Set_Adachi_Work(true);
                break;
            case 2:
                flg.Set_Adachi_Sleep(true);
                break;
            case 3:
                flg.Set_Adachi_Mahi(true);
                break;
            case 4:
                flg.Set_Adachi_Doku(true);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.Equals("Wall"))
        {
            flg.Set_Game_Over(true);
        }
    }
}
