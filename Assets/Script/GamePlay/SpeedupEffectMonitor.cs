using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SpeedupEffectMonitor : MonoBehaviour
{
    private Timer speedUpTimer;

    private bool finish;
    void Start()
    {
        speedUpTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedUpListener(Runs);
    }

    public bool Finish { get { return finish; } }
    public void Runs(int speedUpDuration, float speedUpFactor)
    {
        speedUpTimer.Duration = speedUpDuration;
        if (!speedUpTimer.Finished)
            speedUpTimer.Run();
        finish =  speedUpTimer.Finished;
    }
}
