using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Blocks
{
    [SerializeField]
    private Sprite[] pickupBlockSprites = default;
    private SpriteRenderer spriteRenderer = default;

    private FreezerEffectActivated freezerEffect;
    public static SpeedUpEffectActivated speedUpEffect;

    private float freezerEffectDuratio;
    private int SpeedUpEffectDuratio;
    private float SpeedUpEffectFactore;
    private PickupEffect blockEffect;

    public PickupEffect BlockEffect
    {
        get { return blockEffect; }
        set
        {
            blockEffect = value;
            if (blockEffect == PickupEffect.Freezer)
            {
                freezerEffect = new FreezerEffectActivated();
               
                spriteRenderer.sprite = pickupBlockSprites[0];
                freezerEffectDuratio = ConfigurationUtils.FreezerEffectDuratio;
               
                EventManager.AddFreezeInvoker(this);

            }
             else if(blockEffect == PickupEffect.Speedup)
            { 
                speedUpEffect = new SpeedUpEffectActivated();
                SpeedUpEffectDuratio = (int)ConfigurationUtils.SpeedUpDuration;
                SpeedUpEffectFactore = ConfigurationUtils.SpeedUpFactor;
                spriteRenderer.sprite = pickupBlockSprites[1];
                EventManager.AddSpeedUpInvoker(this);
            }
        }
    }
  protected override void Start()
    {
        base.Start();
        int enumLength = System.Enum.GetNames(typeof(PickupEffect)).Length;
        BlockEffect = (PickupEffect)UnityEngine.Random.Range(0, enumLength);
        score = ConfigurationUtils.PickupBlockPoints;
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

  
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (BlockEffect == PickupEffect.Freezer)
        {
            freezerEffect.Invoke(freezerEffectDuratio);
        }
        if (BlockEffect == PickupEffect.Speedup)
        {
            speedUpEffect.Invoke(SpeedUpEffectDuratio, SpeedUpEffectFactore);
        }
        base.OnCollisionEnter2D(collision);

    }
    public void AddFreezeEventListener(UnityAction<float> freezeEventHandler)
    {
        freezerEffect.AddListener(freezeEventHandler);
    }
    public void AddSpeedUpEventListener(UnityAction<int, float> speedUpEventHandler)
    {
        speedUpEffect.AddListener(speedUpEventHandler);
    }
}
