using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ZeroInvokerEvent
{

    private Timer timer;
    private Timer speedUpTimer;

    private Rigidbody2D ballRb;
    private const float directionDegre = -90;
    private BallSpawner ballSpawner;

    private bool isMove = false;
    private float freezeTime = 1f;
    private float speedUpFactor;
    Vector2 vector;
    float ballXVelocity, ballYVelocity;
    float BallVelocityVector;
    private bool speedy = false;
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody2D>();

        ballSpawner = Camera.main.GetComponent<BallSpawner>();
        
        speedUpTimer = gameObject.AddComponent<Timer>();
        speedUpFactor = ConfigurationUtils.SpeedUpFactor;
       

        timer = gameObject.GetComponent<Timer>();
        timer.Duration = ConfigurationUtils.BallDeathTimer;
        timer.Run();
        vector = new Vector2(Mathf.Cos(directionDegre * Mathf.Deg2Rad), Mathf.Sin(directionDegre * Mathf.Deg2Rad));

        //events
        unityEventsZ.Add(EventName.ReduceBall, new BallSpawnerEvent());
        EventManager.AddZeroInvoker(EventName.ReduceBall, this);
        unityEventsZ.Add(EventName.SpawnBall, new BallSpawnerEvent());
        EventManager.AddZeroInvoker(EventName.SpawnBall, this);
        

    }
    private void FixedUpdate()
    {

        BallMovement();
        DestroyTheBall();
        
    }
    private void BallMovement()
    {
        freezeTime -= Time.deltaTime;
        if (!isMove && freezeTime <= 0 && EffectUtils.IsRun)
        {
            ballRb.AddForce(vector * speedUpFactor * ConfigurationUtils.BallImpulseForce);
            isMove = true;
            
        }
        else if (!isMove && freezeTime <= 0 && !EffectUtils.IsRun)
        {
            ballRb.AddForce(vector * ConfigurationUtils.BallImpulseForce);
            isMove = true;
        }
        if (!EffectUtils.IsRun && speedy)
        {
            
            ballRb.velocity /= speedUpFactor;
            speedy = false;
        }
        else if (EffectUtils.IsRun && !speedy)
        {
            Debug.Log(ballRb.velocity.magnitude);
            ballRb.velocity *= speedUpFactor;
            Debug.Log(ballRb.velocity.magnitude);
            speedy = true;
        }
    }
    private void speedUp(int speedUpDuration, float speedUpFactor)
    {
        if (!speedUpTimer.Running)
        {
            ballRb.velocity *= speedUpFactor;
           
            
        }
    }
    private void DestroyTheBall()
    {
        if (timer.Finished)
        {
            unityEventsZ[EventName.SpawnBall].Invoke();
            Destroy(gameObject);
        }
        if (transform.position.y < (ScreenUtils.ScreenBottom - 2))
        {
            unityEventsZ[EventName.ReduceBall].Invoke();
            unityEventsZ[EventName.SpawnBall].Invoke();
            Destroy(gameObject);
        }

    }
    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed*0.6f;
    }
}
