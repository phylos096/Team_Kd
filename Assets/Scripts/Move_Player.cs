using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *作成者：足立
* 1Pの動き
* WASD　キーで移動
* W:上　A:左　S:下　D:右
*
* 2Pの動き
* 矢印キーで移動
* ↑：上　←：左　↓：下　→：右　
* 
* 範囲指定？
* private Vector2 player_pos;

   void Clamp()
   {
       player_pos = transform.position; //プレイヤーの位置を取得

       player_pos.x = Mathf.Clamp(player_pos.x, -4.8f, 4.8f); //x位置が常に範囲内か監視
       transform.position = new Vector2(player_pos.x, player_pos.y); //範囲内であれば常にその位置がそのまま入る
   }

    別のソース
    Player.transform.position = (new Vector3(Mathf.Clamp(Player.transform.position.x, wall_Left.transform.position.x, wall_Right.transform.position.x),
Mathf.Clamp(Player.transform.position.y, wall_Bottom.transform.position.y, wall_Top.transform.position.y),Player.transform.position.z));
* 
* Mathf.Clamp(float value, float min, float max)で
* Mathf.Clamp(制限したい値, 制限したい値の下限, 制限したい値の上限)
* としてあげればよい。
* 
**/


public class Move_Player : MonoBehaviour
{
    //int First_Player;   //1P
    //int Second_Player;  //2P

    GameObject s_Flg_Manager;
    Flg_Manager flg;

    //Inspectorから値を操作できるようにする
    //0:1P　1:2P
    [SerializeField] int Player = 0;

    Animator animator01;
    Animator animator02;

    SpriteRenderer sprite;

    public int Vect_Right;
    public bool Work_Flg;

    // Start is called before the first frame update
    void Start()
    {   //定位置

        animator01 = GetComponent<Animator>();
        animator02 = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();
        
        s_Flg_Manager = GameObject.Find("Scripts");
        flg = s_Flg_Manager.GetComponent<Flg_Manager>();

        Vect_Right = 1;
        Work_Flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vect_Right == 1)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
        switch (Player)
        {
            case 0:

                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= new Vector3(0.04f, 0, 0);
                    if (Vect_Right < 0)
                    {
                        Vect_Right *= -1;
                    }
                    Work_Flg = true;
                    //現在地を(x,y,z)分更新する
                }
                //Dキーが押されたら右へ
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += new Vector3(0.04f, 0, 0);
                    if (Vect_Right > 0)
                    {
                        Vect_Right *= -1;
                    }
                    Work_Flg = true;
                }
                //Wキーが押されたら上に
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += new Vector3(0, 0.04f, 0);
                    Work_Flg = true;
                }
                //Sキーが押されたら上に
                if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= new Vector3(0, 0.04f, 0);
                    Work_Flg = true;
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    Work_Flg = false;
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    Work_Flg = false;
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    Work_Flg = false;
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    Work_Flg = false;
                }

                Player01_anime();
                break;


            case 1:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position -= new Vector3(0.04f, 0, 0);
                    if (Vect_Right < 0)
                    {
                        Vect_Right *= -1;
                    }
                    Work_Flg = true;
                    //現在地を(x,y,z)分更新する
                }
                //Dキーが押されたら右へ
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(0.04f, 0, 0);
                    if (Vect_Right > 0)
                    {
                        Vect_Right *= -1;
                    }
                    Work_Flg = true;
                }
                //Wキーが押されたら上に
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position += new Vector3(0, 0.04f, 0);
                    Work_Flg = true;
                }
                //Sキーが押されたら上に
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position -= new Vector3(0, 0.04f, 0);
                    Work_Flg = true;
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    Work_Flg = false;
                }
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    Work_Flg = false;
                }
                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    Work_Flg = false;
                }
                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    Work_Flg = false;
                }
                Player02_anime();
                break;
        }
    }

    void Player01_anime()
    {
        if (flg.Catch_Egg_Player_01 == true)
        {
            animator01.Play("Player01_EggCatch");
        }
        else if(Work_Flg == false)
        {
            animator01.Play("Player01_Stop");
            
        }
        else if (Work_Flg == true)
        {
            animator01.Play("Player01_Work");
        }
    }

    void Player02_anime()
    {
        if (flg.Catch_Egg_Player_02 == true)
        {
            animator02.Play("Player02_EggCatch");
        }
        else if (Work_Flg == false)
        {
            animator02.Play("Player02_Stop");

        }
        else if (Work_Flg == true)
        {
            animator02.Play("Player02_Work");
        }

    }
}




