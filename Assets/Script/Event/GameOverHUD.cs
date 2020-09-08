using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverHUD : IntInvokerEvent
{

    [SerializeField]
    private Text scoreText;
    private HUD hud;

    private int score = 0;

  
     void Start()
    {
        Time.timeScale = 0;

        scoreText.text = "Score: " + HUD.Score;
    }

}
