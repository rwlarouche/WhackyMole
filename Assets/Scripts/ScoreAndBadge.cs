using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndBadge : MonoBehaviour {

    public GameObject scoreText;
    public GameObject bestScoreText;

    public GameObject badge;
    public Sprite bronze;
    public Sprite silver;
    public Sprite gold;
    public Sprite platinum;

    void Start () {
        //Fetch score and best score from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score");
        int bestScore = PlayerPrefs.GetInt("Best Score");
        UpdateScore(score,bestScore);

        UpdateBadge(score);
}

    private void UpdateScore(int score, int bestScore)
    {
        //Update score texts
        scoreText.GetComponent<Text>().text = score.ToString();
        bestScoreText.GetComponent<Text>().text = bestScore.ToString();
    }

    private void UpdateBadge(int score)
    {
        if(score >= 20) //Bronze badge
        {
            badge.GetComponent<Image>().sprite = bronze;
        }
        if (score >= 40) //Silver badge
        {
            badge.GetComponent<Image>().sprite = silver;
        }
        if (score >= 60) //Gold badge
        {
            badge.GetComponent<Image>().sprite = gold;
        }
        if (score >= 100) //Platinum badge
        {
            badge.GetComponent<Image>().sprite = platinum;
        }
    }
}
