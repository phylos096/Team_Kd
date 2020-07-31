using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Adachi : MonoBehaviour
{
    public GameObject obj;
    GameObject Pop_Obj;

    GameObject s_Flg_Manager;
    Flg_Manager flg;

    Vector3 Create_Positon;

    // Start is called before the first frame update
    void Start()
    {
        s_Flg_Manager = GameObject.Find("Scripts");
        flg = s_Flg_Manager.GetComponent<Flg_Manager>();
        Create_Positon = new Vector3(10, -0.6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if(flg.)
    }
}
