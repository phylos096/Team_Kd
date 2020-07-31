using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject s_Adachi_Hp;
    Adachi_HP hp;

    GameObject s_Flg_Manager;
    Flg_Manager flg;

    static float HP;

    // Start is called before the first frame update
    void Start()
    {
        s_Adachi_Hp = GameObject.Find("Scripts");
        s_Flg_Manager = GameObject.Find("Scripts");
        hp = s_Adachi_Hp.GetComponent<Adachi_HP>();
        flg = s_Flg_Manager.GetComponent<Flg_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*//HP = hp.Get_HP();
        if (HP <= 0)
        {
            flg.Set_Game_Over(true);
        }
        if (flg.Game_Over == true)
        {
            SceneManager.LoadScene("Result");
        }*/
    }
}
