using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    void Start()
    {
        score = 0;
    }
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int number)
    {
        score += number;
    }

}
