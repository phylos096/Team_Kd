using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  //画面遷移してもオブジェクトが壊れない
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
