using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private int blockCount;
    private void Start()
    {
        EventManager.AddIntListener(EventName.GameOver, GameOver);
        EventManager.AddIntListener(EventName.BlockDestroyed, BlockDestroyed);
        blockCount = GameObject.FindGameObjectsWithTag("Block").Length;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ManuManager.GotoMenu();
    }
    private void GameOver(int score)
    {
       
         Object.Instantiate(Resources.Load("GameOver"));
        
     }  
    private void BlockDestroyed(int i)
    {
        blockCount--;
        if (blockCount <= 0)
        { 
         Object.Instantiate(Resources.Load("YOUWin"));

        }
    }

}
