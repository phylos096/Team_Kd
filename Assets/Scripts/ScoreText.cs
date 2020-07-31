using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう
public class ScoreText : MonoBehaviour
{
    int score;
    

    public GameObject score_object = null; // Textオブジェクト
   
    //private int score = 0;
    //private int highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = Score.GetScore();
       
        //print(highscore);
    }

    // Update is called once per frame
    void Update()
    {
       
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "SCORE   :         " + score;
       
    }
    //public void getScore(int i, int n)//値を受け取る関数
    //{
      //  score = i;
    //   highscore = n;
    //}
}
