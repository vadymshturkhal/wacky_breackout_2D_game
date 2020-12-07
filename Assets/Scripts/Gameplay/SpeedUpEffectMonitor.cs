using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// FIXME Add events for start and end boost

// Change EffectUtils.speedBoost after event happened
// For increase or decrease current speed of "Ball"
public class SpeedUpEffectMonitor : MonoBehaviour
{
    Timer speedUpDuration;
    BoostBallEffectActivated boostBallEvent;
    bool isSpeedUp = false;

    void Start()
    {
        speedUpDuration = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedUpEffectListener(HandleSpeedUpEffectActivatedEvent);

        // Manipulate with speed of "Ball"
        boostBallEvent = new BoostBallEffectActivated();
        EventManager.AddBoostBallEffectInvoker(this);
    }

    void Update()
    {
        if (isSpeedUp)
        {
            HUD.SpeedUpEffectDurationText(speedUpDuration.TotalSecondsLeft);
        }

        if (speedUpDuration.Finished && isSpeedUp)
        {
            isSpeedUp = false;
            boostBallEvent.Invoke(isSpeedUp);
            
            EffectUtils.SpeedBoost /= EffectUtils.BoostFactor;
        }
    }

    public void AddBoostBallEffectListener(UnityAction<bool> listener)
    {
        boostBallEvent.AddListener(listener);
    }

    void HandleSpeedUpEffectActivatedEvent(float duration)
    {
        if (isSpeedUp)
        {
            speedUpDuration.MakeLonger(duration);
        }
        else
        {
            isSpeedUp = true;
            speedUpDuration.Duration = duration;
            speedUpDuration.Run();

            EffectUtils.SpeedBoost *= EffectUtils.BoostFactor;
            boostBallEvent.Invoke(isSpeedUp);
        }
    }
}
