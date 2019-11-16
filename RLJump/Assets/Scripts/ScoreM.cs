using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreM : MonoBehaviour, IKillListener,IScoreAdder
{
    private int userScore = 0;

    public TextMeshProUGUI scoreUI;
    public PlayerHpControler playerHpControler;
    public CoinGather coinGather;

    public void Kill()
    {
        userScore++;
        scoreUI.text = userScore.ToString();
    }

    private void Start()
    {
        if (playerHpControler != null) playerHpControler.setListener(this);
        if (coinGather != null) coinGather.score = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Restart();
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

    }

    public void addScore(int score)
    {
        userScore+=score;
        scoreUI.text = userScore.ToString();
    }

    public int getScore()
    {
        return userScore;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
