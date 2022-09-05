using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    Text scoreTxt;

    int scoreCount;

    float socreCountTimerTreshold = 1;
    float scoreCountTimer;

    bool _canCountScore;
    public bool CanCountScore
    {
        get { return _canCountScore; }
        set { _canCountScore = value; }
    }

    StringBuilder scoreStringBuilder=new StringBuilder();
    // Start is called before the first frame update
    void Start()
    {
        CanCountScore = true;
        scoreCountTimer = Time.time + socreCountTimerTreshold;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanCountScore) { return; }
        if (Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + socreCountTimerTreshold;
            scoreCount++;
            DisplayScore(scoreCount);
        }
    }
    void DisplayScore(int score)
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append(score);
        scoreStringBuilder.Append(" m");
        scoreTxt.text=scoreStringBuilder.ToString();
    }
    public int GetScore()
    {
        return scoreCount;
    }

}
