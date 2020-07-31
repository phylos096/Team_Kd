using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adachi_Animation : MonoBehaviour
{
    GameObject s_Flg_Manager;
    Flg_Manager flg;

    public Animator animation;
    
    
    // Start is called before the first frame update
    void Start()
    {
        s_Flg_Manager = GameObject.Find("Scripts");
        flg = s_Flg_Manager.GetComponent<Flg_Manager>();

        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flg.Adachi_Stop == true)
        {
            animation.Play("Adachi_Idel");
        }
        else if (flg.Adachi_Work == true)
        {
            animation.Play("Adachi_Work");
        }
        else if (flg.Adachi_Mahi == true)
        {
            animation.Play("Adachi_Mahi");
        }
        else if (flg.Adachi_Sleep == true)
        {
            animation.Play("Adachi_Sleep");
        }
    }
}
