using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreDisplay;
    public Text hightScore;
    public LevelUpMessage message;
    public TimeDeltaTime GM;
    //public int GameHightScore;
    private void Awake()
    {
        GM = FindObjectOfType<TimeDeltaTime>();
    }
    private void Start()
    {
        hightScore.text = PlayerPrefs.GetInt("HightScore", 0).ToString();
    }

    void OnTriggerEnter2D(Collider2D point)
    {
        if (point.tag == "point")
        {
            //score++;
            scoreUp();
        }
    }
    public void UpdateScore()
    {
        scoreDisplay.text = score.ToString();
        //GameHightScore = score;
        /*if (score > PlayerPrefs.GetInt("HightScore", 0))
        {
            hightScore.text = score.ToString();
            PlayerPrefs.SetInt("HightScore", score);
        }*/
    }
    public void HightScoreReset()
    {
        PlayerPrefs.DeleteKey("HightScore");
        hightScore.text = "0";
       //UpdateScore();
       // EndGameHightScore();
    }

    public void scoreUp()
    {
        score++;
        UpdateScore();
        //message.DisplayRightMessage();
        if (score >= 10 && GM.level < 1)
        {
            GM.level = 1;
            message.DisplayRightMessage();
            //Debug.Log("1");
        }
        else if (score >= 20 && GM.level < 2)
        {
            GM.level = 2;
            message.DisplayRightMessage();
            //Debug.Log("2");
        }
        else if (score >= 30 && GM.level < 3)
        {
            GM.level = 3;
            message.DisplayRightMessage();
            //Debug.Log("3");
        }
        else if (score >= 40 && GM.level < 4)
        {
            GM.level = 4;
            message.DisplayRightMessage();
            //Debug.Log("4");
        }
        else if (score >= 50 && GM.level < 5)
        {
            GM.level = 5;
            message.DisplayRightMessage();
            //Debug.Log("5");
        }
        else { }
        GM.levelUp();

    }
    public void scoreDown()
    {
        score--;
        UpdateScore();
    }
    public void EndGameHightScore()
    {
        scoreDisplay.text = score.ToString();
        //GameHightScore = score;
        if (score > PlayerPrefs.GetInt("HightScore", 0))
        {
            hightScore.text = score.ToString();
            PlayerPrefs.SetInt("HightScore", score);
        }
    }
}
