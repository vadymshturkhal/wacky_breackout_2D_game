using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Shows player score
// Show quantity of fallen "Balls"
public class HUD : MonoBehaviour
{
    Text scoreText;
    Text ballsLeftText;
    Text speedUpEffectDurationText;

    static int score = 0;
    static int ballsLeft;
    static float speedUpDuration;
    static string message = "";

    void Start()
    {
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();

        ballsLeft = ConfigurationUtils.BallsPerGame;
        ballsLeftText = GameObject.FindWithTag("BallsLeftText").GetComponent<Text>();
        ballsLeftText.text = "Balls left: " + ballsLeft.ToString();

        speedUpEffectDurationText = GameObject.FindWithTag("SpeedUpEffectDurationText").GetComponent<Text>();
        speedUpEffectDurationText.text = "";

        // Events
        EventManager.AddScoreListener(AddScore);
        EventManager.ReduceBallsLeftListener(ReduceBallsLeft);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        ballsLeftText.text = "Balls left: " + ballsLeft.ToString();
        speedUpEffectDurationText.text = message;
    }

    void AddScore(int value)
    {
        score += value;
    }

    void ReduceBallsLeft()
    {
        ballsLeft -= 1;
    }

    public static void SpeedUpEffectDurationText(float duration)
    {
        
        if (duration <= 0.5)
        {
            message = "";
        }
        else
        {
            message = "Speed up: " + string.Format("{0:0.00}", duration);
        }
    }
}
