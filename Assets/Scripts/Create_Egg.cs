using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Egg : MonoBehaviour
{
    //外部から、Prefabの関連付け
    public GameObject Egg_01;   //毒
    public GameObject Egg_02;   //マヒ
    public GameObject Egg_03;   //眠り
    public AudioSource audio;
    //生成するEggを設定する関数
    GameObject create_egg;
    GameObject Egged;

    [SerializeField] Vector3 Create_Position;
    [SerializeField] Vector3[] SetPosition = new Vector3[3];

    //何番目の卵孵化の場所なのか　上～1　下に行くほど数が増える
    [SerializeField] int num;

    bool Create_Flg_01;
    bool Create_Flg_02;
    bool Create_Flg_03;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Create_Flg_01 = true;
        Create_Flg_02 = true;
        Create_Flg_03 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Create_Flg_01)
        {
            Re_Create_Egg(1);
        }
        else if (Create_Flg_02)
        {
            Re_Create_Egg(2);
        }
        else if (Create_Flg_03)
        {
            Re_Create_Egg(3);
        }
    }

    //作成者:足立拓海
    //Eggの生成位置を設定する。
    public void Get_Egg_Position(Vector3 position)
    {
        Create_Position = position;  
    }

    //作成者：足立拓海
    //Create_Flgを設定する。
    public void Set_Create_Flg(int n)
    {
        switch (n)
        {
            case 1:
                Create_Flg_01 = true;
                audio.PlayOneShot(audio.clip);
                break;
            case 2:
                Create_Flg_02 = true;
                audio.PlayOneShot(audio.clip);
                break;
            case 3:
                Create_Flg_03 = true;
                audio.PlayOneShot(audio.clip);
                break;
        }
        
    }

    public void Re_Create_Egg(int i)
    {
        int n = (int)Random.Range(0, 3);
        switch (n)
        {
            case 0:     //毒
                create_egg = Egg_01;
                break;
            case 1:     //マヒ
                create_egg = Egg_02;
                break;
            case 2:     //眠り
                create_egg = Egg_03;
                break;
        }
        Create_Position = SetPosition[i - 1];

        Egged = Instantiate(create_egg, Create_Position, Quaternion.identity) as GameObject;
        this.Egged.name = "Egg" + i;

        //生成したEggを関連付けし、Egg内の関数
        //Set_Egg_Infomationに卵の情報を渡す。
        Egg egg = this.Egged.GetComponent<Egg>();
        egg.Set_Egg_Infomation(n + 1, i);
        egg.Set_Egg_Position(Create_Position);

        switch (i)
        {
            case 1:
                Create_Flg_01 = false;
                break;
            case 2:
                Create_Flg_02 = false;
                break;
            case 3:
                Create_Flg_03 = false;
                break;
        }
    }
}
