using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : IntInvokerEvent
{
    
    protected GameObject audioManager;
    protected int score;
   virtual protected  void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio");
        unityEvents.Add(EventName.AddPoint, new AddPointEvent());
        EventManager.AddIntInvoker(EventName.AddPoint, this);
        unityEvents.Add(EventName.BlockDestroyed, new BlockDestroyedEvent());
        EventManager.AddIntInvoker(EventName.BlockDestroyed, this);

        
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            AudioManager.Play(AudioClipName.BlockDestroy);
            unityEvents[EventName.AddPoint].Invoke(score);
            unityEvents[EventName.BlockDestroyed].Invoke(score);
            Destroy(gameObject);
        }
    }
}
