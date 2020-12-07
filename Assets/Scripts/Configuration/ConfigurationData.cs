using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float ballLifeTime = 10;
    static float ballFreezeAfterSpawn = 1;
    static float minSpawnDelay = 5;
    static float maxSpawnDelay = 10;
    static int standartBlockPoint = 1;
    static int bonusBlockPoint = 2;
    static int pickupBlockPoint = 5;
    static float standartBlockProbably = 60;
    static float bonusBlockProbably = 20;
    static float freezerBlockProbably = 10;
    static float speedupBlockProbably = 10;
    static int ballsPerGame = 5;
    static float freezerEffectDuration = 2;
    static float speedUpEffectDuration = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    public float BallFreezeAfterSpawn
    {
        get { return ballFreezeAfterSpawn; }
    }

    public float MinSpawnDelay
    {
        get { return minSpawnDelay; }
    }

    public float MaxSpawnDelay
    {
        get { return maxSpawnDelay; }
    }

    public int StandartBlockPoint
    {
        get { return standartBlockPoint; }
    }

    public int BonusBlockPoint
    {
        get { return bonusBlockPoint; }
    }

    public int PickupBlockPoint
    {
        get { return pickupBlockPoint; }
    }

    public float StandartBlockProbably
    {
        get { return standartBlockProbably; }
    }

    public float BonusBlockProbably
    {
        get { return bonusBlockProbably; }
    }

    public float FreezerBlockProbably
    {
        get { return freezerBlockProbably; }
    }

    public float SpeedupBlockProbably
    {
        get { return speedupBlockProbably; }
    }

    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    public float FreezerEffectDuration
    {
        get { return freezerEffectDuration; }
    }

    public float SpeedUpEffectDuration
    {
        get { return speedUpEffectDuration; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;

        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTime = float.Parse(values[2]);
        ballFreezeAfterSpawn = float.Parse(values[3]);
        minSpawnDelay = float.Parse(values[4]);
        maxSpawnDelay = float.Parse(values[5]);
        standartBlockPoint = int.Parse(values[6]);
        bonusBlockPoint = int.Parse(values[7]);
        pickupBlockPoint = int.Parse(values[8]);
        standartBlockProbably = float.Parse(values[9]);
        bonusBlockProbably = float.Parse(values[10]);
        freezerBlockProbably = float.Parse(values[11]);
        speedupBlockProbably = float.Parse(values[12]);
        ballsPerGame = int.Parse(values[13]);
        freezerEffectDuration = float.Parse(values[14]);
        speedUpEffectDuration = float.Parse(values[15]);
    }

    #endregion
}
