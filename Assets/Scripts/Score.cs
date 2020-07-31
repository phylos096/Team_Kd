/*
 * 作成者:宮崎洸
 * 説明  :スコア関連
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public  static int score;
    public  static int highscore;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        // スコアのロード
        highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
    }
    // Update is called once per frame
    void OnDestroy()
    {
       
        if (highscore < score)
        {           
            highscore = score;
            // スコアを保存
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
            PlayerPrefs.Save();
        }
       
        //score = 0;
    }
public static int GetHighScore()
    {

        return highscore;
    }

public static int GetScore()
    {

        return score;
    }
    void Update()
    {
        //print(highscore);
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                PlayerPrefs.DeleteKey("HIGHSCORE");
            }
        }
        //ScoreUp();
    }
    public void ScoreUp()//ヒヨコが食べられたら
    {
        score += 10;
    }
    public void ScoreUp2()//敵が死んだら
    {
        score += 50;
    }

}
