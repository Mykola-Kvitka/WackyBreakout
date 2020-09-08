using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private GameObject audioManager;

    private Rigidbody2D PaddelRb;

    private float horizontalInput;
   
    private float halfColliderX;
    
    private const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    Timer freezeTimer;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio");
        freezeTimer = gameObject.AddComponent<Timer>();
        PaddelRb = gameObject.GetComponent<Rigidbody2D>();
         halfColliderX = gameObject.GetComponent<BoxCollider2D>().size.x / 2;
        EventManager.AddFreezeListener((float freezeDuration) => { freezeTimer.Duration = freezeDuration; freezeTimer.Run(); });

    }

    void FixedUpdate()
    {
       
       Move();
    }

    private void Move()
    {
        horizontalInput = 0;
        if (!freezeTimer.Running)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            Vector2 movementVector = new Vector2(horizontalInput, 0);
            Vector2 newPos = PaddelRb.position + movementVector * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
            if (newPos.x + halfColliderX <= ScreenUtils.ScreenRight && newPos.x - halfColliderX >= ScreenUtils.ScreenLeft)
                PaddelRb.MovePosition(newPos);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
       
        if (coll.gameObject.CompareTag("Ball") && 
            TopCollision(coll))
        {
            AudioManager.Play(AudioClipName.PaddleHit);
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderX;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

   
    private bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }
}
