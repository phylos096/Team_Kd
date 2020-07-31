using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class HighScore : MonoBehaviour
{
    int highscore;

    public GameObject highscore_object = null; // Textオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        highscore = Score.GetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text highscore_text = highscore_object.GetComponent<Text>();
        highscore_text.text = "HIGHSCORE :  " + highscore;
    }
}
