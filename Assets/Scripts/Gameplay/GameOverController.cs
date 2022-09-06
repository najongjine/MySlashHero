using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    Canvas gameOverCanvas;

    [SerializeField]
    Text currentScore, bestScore;

    ScoreCounter scoreCounter;

    private void Awake()
    {
        scoreCounter = GetComponent<ScoreCounter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOverShowPanel()
    {
        SoundManager.instance.Play_GameOver_Sound();
        Time.timeScale = 0;
        scoreCounter.CanCountScore = false;
        gameOverCanvas.enabled = true;
        DisplayScore();
        CheckToUnlockNewCharacters(scoreCounter.GetScore());
    }

    private void DisplayScore()
    {
        int highscore = DataManager.GetData(TagManager.HIGHSCORE_DATA);
        if (scoreCounter.GetScore()>highscore)
        {
            DataManager.SaveData(TagManager.HIGHSCORE_DATA,scoreCounter.GetScore());
        }
        currentScore.text = $"Score : {scoreCounter.GetScore()} m";
        bestScore.text = $"Best: {DataManager.GetData(TagManager.HIGHSCORE_DATA)} m";
    }
    void CheckToUnlockNewCharacters(int score)
    {
        GameplayController.instance.CheckToUnlockCharacter(scoreCounter.GetScore());
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

}
