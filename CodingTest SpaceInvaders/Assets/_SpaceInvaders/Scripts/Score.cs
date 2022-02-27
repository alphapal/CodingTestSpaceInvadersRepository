using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    private int totalScore = 0;
    private static int highScore = 0;

    private void OnEnable()
    {
        AlienSpawnPoints.AliensKilled += (numberOfAliensKilled) => AlienKilled(numberOfAliensKilled);
    }
    private void OnDisable()
    {
        AlienSpawnPoints.AliensKilled += (numberOfAliensKilled) => AlienKilled(numberOfAliensKilled);
    }

    private void AlienKilled(int aliensKilled)
    {
        totalScore = aliensKilled * 100;
        scoreText.text = totalScore.ToString();

        if(totalScore > highScore)
        {
            highScore = totalScore;
            highScoreText.text = highScore.ToString();
        }
    }

}
