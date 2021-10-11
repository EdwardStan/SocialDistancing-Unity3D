using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SCore2 : MonoBehaviour
{
    
    public float score;
    public static float pointIncreasePerSecond;
    public static bool triggerDetected = false;
    /*public float maxScore;*/
    public Text finalScore;
    /*public Text highscore;*/
    public Text scoreText;

    public Text reward;

    public int highscore = 0;




    void Start()
    {
        score = 0f;
        pointIncreasePerSecond = 10f;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    void Update()
    {
        scoreText.text = (int)score + "$";
        score += pointIncreasePerSecond * Time.deltaTime; ;

        finalScore.text = (int)score + "$";

        if (triggerDetected) {
            if ((int)score > highscore)
            {
                highscore = (int)score;
                PlayerPrefs.SetInt("highscore", highscore);
                PlayerPrefs.Save();
            }
        }

        reward.text = (int)highscore + "$";
    }

}
