using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Adachi_HP : MonoBehaviour
{
    GameObject s_Flg_Manager;
    Flg_Manager flg;

    public static float HP;//アダチのHP

    // Start is called before the first frame update
    void Start()
    {
        //Flg
        s_Flg_Manager = GameObject.Find("Scripts");
        flg = s_Flg_Manager.GetComponent<Flg_Manager>();

        HP = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            flg.Set_Game_Clear(true);

            SceneManager.LoadScene("Result");
        }

    }

    public float Get_HP()
    {
        return HP;
    }

    public void Poizon_Dameger()
    {
        HP -= 2f;
    }

    public void Poizon_Dameger(float n)
    {
        HP -= n;
    }
}
