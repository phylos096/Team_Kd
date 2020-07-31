using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Slider _slider;

    //Hungryクラス参照変数とFlag
    GameObject s_Adachi_HP;
    Adachi_HP hp;

    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _slider.value = Adachi_HP.HP;
        s_Adachi_HP = GameObject.Find("Adachi");
        hp = s_Adachi_HP.GetComponent<Adachi_HP>();
    }

    void Update()
    {
        _slider.value = hp.Get_HP();
    }
}

