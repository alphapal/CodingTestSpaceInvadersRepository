using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private void Start()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
        PlayerPrefs.SetInt("highScore", ScoreManager.instance.score);
    }
}
