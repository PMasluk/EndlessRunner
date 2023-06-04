using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score;

    public void AddPoint()
    {
        score++;
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        scoreText.text = score.ToString();
    }
}
