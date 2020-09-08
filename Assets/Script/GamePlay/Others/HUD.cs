using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : IntInvokerEvent
{
    private static GameObject textScoreGO;
    private static GameObject textRemainingBallGO;

    private static Text scoreText;
    private static Text ballText;

    private static int score = 0;
    private static int remainingBall;
    private static int ballLeftScreen = 0;

    public static int Score
    { get { return score; } }
    // Start is called before the first frame update
    void Start()
    {
        textScoreGO = GameObject.FindGameObjectWithTag("ScoreText");
        scoreText = textScoreGO.GetComponent<Text>();
        scoreText.text = "Score: " + HUD.score;

        textRemainingBallGO = GameObject.FindGameObjectWithTag("TextBallRemaining");
        ballText = textRemainingBallGO.GetComponent<Text>();
        remainingBall = ConfigurationUtils.BallsPerGame;
        ballText.text = "Balls: " + remainingBall;

        //events
        EventManager.AddIntListener(EventName.AddPoint, HandlePointsAddedEvent);
        EventManager.AddZeroListener(EventName.ReduceBall, BallLeftScreen);

        unityEvents.Add(EventName.GameOver, new GameOverEvent());
        EventManager.AddIntInvoker(EventName.GameOver, this);
    }
    private void HandlePointsAddedEvent(int score)
    {
        HUD.score += score;
        scoreText.text = "Score: " + HUD.score;
    }
    private void BallLeftScreen()
    {
        ballLeftScreen++;
        ballText.text = "Balls: " + (remainingBall - ballLeftScreen);
        if(remainingBall - ballLeftScreen <=0 )
            unityEvents[EventName.GameOver].Invoke(score);
    }

}
