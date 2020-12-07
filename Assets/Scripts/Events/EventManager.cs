using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    // Freezer effect
    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners = new List<UnityAction<float>>();

    // Speedup effect
    static List<PickupBlock> speedUpEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> speedUpEffectListeners = new List<UnityAction<float>>();

    // Speedup boost
    static SpeedUpEffectMonitor monitor;
    static List<UnityAction<bool>> balls = new List<UnityAction<bool>>();

    // Add score to HUD
    static List<Block> addScoreInvokers = new List<Block>();
    static List<UnityAction<int>> addScoreListeners = new List<UnityAction<int>>();

    // Reduce balls quantity from HUD
    static List<Ball> reduceBallsLeftInvokers = new List<Ball>();
    static List<UnityAction> reduceBallsLeftListeners = new List<UnityAction>();

    // Timer events
    static List<Timer> timerEventInvokers = new List<Timer>();
    static List<UnityAction> timerEventListeners = new List<UnityAction>();

    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        freezerEffectInvokers.Add(invoker);

        foreach (UnityAction<float> listener in freezerEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectListeners.Add(listener);

        foreach (PickupBlock invoker in freezerEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void AddSpeedUpEffectInvoker(PickupBlock invoker)
    {
        speedUpEffectInvokers.Add(invoker);
        
        foreach (UnityAction<float> listener in speedUpEffectListeners)
        {
            invoker.AddSpeedUpEffectListener(listener);
        }
    }

    public static void AddSpeedUpEffectListener(UnityAction<float> listener)
    {
        speedUpEffectListeners.Add(listener);

        foreach (PickupBlock invoker in speedUpEffectInvokers)
        {
            invoker.AddSpeedUpEffectListener(listener);
        }
    }

    public static void AddBoostBallEffectInvoker(SpeedUpEffectMonitor invoker)
    {
        monitor = invoker;

        foreach (UnityAction<bool> ball in balls)
        {
            monitor.AddBoostBallEffectListener(ball);
        }
    }

    public static void AddBoostBallEffectListener(UnityAction<bool> listener)
    {
        balls.Add(listener);
        
        if (monitor != null)
        {
            foreach (UnityAction<bool> ball in balls)
            {
                monitor.AddBoostBallEffectListener(ball);
            }
        }
    }

    public static void AddScoreListener(UnityAction<int> listener)
    {
        addScoreListeners.Add(listener);

        foreach (Block invoker in addScoreInvokers)
        {
            invoker.AddScoreListener(listener);
        }
    }

    public static void AddScoreInvoker(Block invoker)
    {
        addScoreInvokers.Add(invoker);

        foreach (UnityAction<int> listener in addScoreListeners)
        {
            invoker.AddScoreListener(listener);
        }
    }

    public static void ReduceBallsLeftListener(UnityAction listener)
    {
        reduceBallsLeftListeners.Add(listener);

        foreach (Ball invoker in reduceBallsLeftInvokers)
        {
            invoker.ReduceBallsLeftListener(listener);
        }
    }

    public static void ReduceBallsLeftInvoker(Ball invoker)
    {
        reduceBallsLeftInvokers.Add(invoker);

        foreach (UnityAction listener in reduceBallsLeftListeners)
        {
            invoker.ReduceBallsLeftListener(listener);
        }
    }

    public static void AddTimerEventListener(UnityAction listener)
    {
        timerEventListeners.Add(listener);

        foreach (Timer invoker in timerEventInvokers)
        {
            invoker.AddTimerEventListener(listener);
        }
    }

    public static void AddTimerEventInvoker(Timer invoker)
    {
        timerEventInvokers.Add(invoker);

        foreach (UnityAction listener in timerEventListeners)
        {
            invoker.AddTimerEventListener(listener);
        }
    }
}
