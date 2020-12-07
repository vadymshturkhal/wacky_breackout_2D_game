using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields
    static ConfigurationData configData = new ConfigurationData();
    static float ballImpulse;
    static float paddleMove;
    static float ballLifetime;
    static float ballFreezeAfterSpawn;
    static float minSpawnDelay;
    static float maxSpawnDelay;
    static int standartBlockPoint;
    static int bonusBlockPoint;
    static int pickupBlockPoint;
    static float standartBlockProbably;
    static float bonusBlockProbably;
    static float freezerBlockProbably;
    static float speedupBlockProbably;
    static int ballsPerGame;
    static float freezerEffectDuration;
    static float speedUpEffectDuration;
    #endregion

    #region Properties
    public static float BallImpulseForce
    {
        get { return ballImpulse; }
    }
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return paddleMove; }
    }

    public static float BallLifeTime
    {
        get { return ballLifetime; }
    }

    public static float BallFreezeAfterSpawn
    {
        get { return ballFreezeAfterSpawn; }
    }

    public static float MinSpawnDelay
    {
        get { return minSpawnDelay; }
    }

    public static float MaxSpawnDelay
    {
        get { return maxSpawnDelay; }
    }

    public static int StandartBlockPoint
    {
        get { return standartBlockPoint; }
    }

    public static int BonusBlockPoint
    {
        get { return bonusBlockPoint; }
    }

    public static int PickupBlockPoint
    {
        get { return pickupBlockPoint; }
    }

    public static float StandartBlockProbably
    {
        get { return standartBlockProbably; }
    }

    public static float BonusBlockProbably
    {
        get { return bonusBlockProbably; }
    }

    public static float FreezerBlockProbably
    {
        get { return freezerBlockProbably; }
    }

    public static float SpeedupBlockProbably
    {
        get { return speedupBlockProbably; }
    }

    public static int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    public static float FreezerEffectDuration
    {
        get { return freezerEffectDuration; }
    }

    public static float SpeedUpEffectDuration 
    {
        get { return speedUpEffectDuration; }
    }
    #endregion


    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        ballImpulse = configData.BallImpulseForce;
        paddleMove = configData.PaddleMoveUnitsPerSecond;
        ballLifetime = configData.BallLifeTime;
        ballFreezeAfterSpawn = configData.BallFreezeAfterSpawn;
        minSpawnDelay = configData.MinSpawnDelay;
        maxSpawnDelay = configData.MaxSpawnDelay;
        standartBlockPoint = configData.StandartBlockPoint;
        bonusBlockPoint = configData.BonusBlockPoint;
        pickupBlockPoint = configData.PickupBlockPoint;
        standartBlockProbably = configData.StandartBlockProbably;
        bonusBlockProbably = configData.BonusBlockProbably;
        freezerBlockProbably = configData.FreezerBlockProbably;
        speedupBlockProbably = configData.SpeedupBlockProbably;
        ballsPerGame = configData.BallsPerGame;
        freezerEffectDuration = configData.FreezerEffectDuration;
        speedUpEffectDuration = configData.SpeedUpEffectDuration;
    }
}
