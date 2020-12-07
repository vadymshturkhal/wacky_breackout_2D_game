using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    PickupEffect effect;
    FreezerEffectActivated freezerEffectActivated;
    SpeedUpEffectActivated speedUpEffectActivated;
    float duration;

	/// <summary>
    /// Sets the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public PickupEffect Effect
    {
        set
        {
            effect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = Resources.Load<Sprite>("PickupBlockSprites/BlockIce");
                freezerEffectActivated = new FreezerEffectActivated();
                duration = ConfigurationUtils.FreezerEffectDuration;

                // Add self as event invoker
                EventManager.AddFreezerEffectInvoker(this);
            }
            else if (effect == PickupEffect.Speedup)
            {
                spriteRenderer.sprite = Resources.Load<Sprite>("PickupBlockSprites/BlockSpeed");
                speedUpEffectActivated = new SpeedUpEffectActivated();
                duration = ConfigurationUtils.SpeedUpEffectDuration;

                // Add self as event invoker
                EventManager.AddSpeedUpEffectInvoker(this); 
            }
        }
    }

    void Start()
    {
        weight = ConfigurationUtils.PickupBlockPoint;
        
        base.Start();
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedUpEffectListener(UnityAction<float> listener)
    {
        speedUpEffectActivated.AddListener(listener);
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (effect == PickupEffect.Freezer)
        {
            freezerEffectActivated.Invoke(duration);
        }
        else if (effect == PickupEffect.Speedup)
        {
            speedUpEffectActivated.Invoke(duration);
        }

        base.OnCollisionEnter2D(other);
    }
}
