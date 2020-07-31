using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnClick()
    {
        //Debug.Log("押された");  //ログの出力
        //メインシーンへ移動

        SceneManager.LoadScene("Game");

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
