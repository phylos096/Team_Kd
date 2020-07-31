/*
 * 作成者:宮崎洸
 * 説明  :ひよこを右に移動させるスクリプトです
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiyoko : MonoBehaviour
{
    public float Hspeed = 0.01f;

    [SerializeField]private int Hiyoko_Infomation;
    [SerializeField]Vector3 Hiyoko_Position;

    GameObject s_Enemy;
    Enemy adachi;

    // Start is called before the first frame update
    void Start()
    {
        s_Enemy = GameObject.Find("Adachi");
        adachi = s_Enemy.GetComponent<Enemy>();
        Set_Hiyoko_Info();
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.Translate(Hspeed, 0, 0);//speedの値に移動
        this.transform.position += new Vector3(Hspeed, 0, 0);
    }

    public void Set_Hiyoko_Infomation(int n)
    {
        Hiyoko_Infomation = n;
    }

    public void Set_Hiyoko_Position(Vector3 position)
    {
        Hiyoko_Position = position;
    }

    void Set_Hiyoko_Info()
    {
        if (this.name.Equals("Hiyoko_1"))
        {
            Hiyoko_Infomation = 1;
        }
        if (this.name.Equals("Hiyoko_2"))
        {
            Hiyoko_Infomation = 2;
        }
        if (this.name.Equals("Hiyoko_3"))
        {
            Hiyoko_Infomation = 3;
        }
        if (this.name.Equals("Hiyoko_4"))
        {
            Hiyoko_Infomation = 4;
        }
        if (this.name.Equals("Hiyoko_6"))
        {
            Hiyoko_Infomation = 6;
        }
        if (this.name.Equals("Hiyoko_9"))
        {
            Hiyoko_Infomation = 9;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.Equals("Adachi")){
            adachi.Set_Adachi_State(Hiyoko_Infomation);
           
            switch (Hiyoko_Infomation)
            {
                case 1:
                    adachi.Set_Doku_Timer(7);
                    adachi.Set_Doku_Flg(true);
                    break;
                case 2:
                    adachi.Set_Doku_Timer();
                    adachi.Set_Mahi_Timer();
                    adachi.Set_Doku_Flg(true);
                    adachi.Set_Mahi_Flg(true);
                    break;
                case 3:
                    adachi.Set_Doku_Timer();
                    adachi.Set_Sleep_Timer();
                    adachi.Set_Doku_Flg(true);
                    adachi.Set_Sleep_Flg(true);
                    break;
                case 4:
                    adachi.Set_Mahi_Flg(true);
                    adachi.Set_Mahi_Timer(7);
                    break;
                case 6:
                    adachi.Set_Sleep_Timer();
                    adachi.Set_Mahi_Timer();
                    adachi.Set_Mahi_Flg(true);
                    adachi.Set_Sleep_Flg(true);
                    break;
                case 9:
                    adachi.Set_Sleep_Timer(7);
                    adachi.Set_Sleep_Flg(true);
                    break;
            }
            Destroy(gameObject, 0f);
        }
        if (coll.name.Equals("Adachi/Mouth")){
            Destroy(gameObject, 0f);
        }
    }
}
