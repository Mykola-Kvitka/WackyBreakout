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

    private const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    private static float paddleMoveUnitsPerSecond = 10;
    private static float ballImpulseForce = 200;
    private static float ballDeathTimer = 10;
    private static float minimumSpawnDelay = 5;
    private static float maximumSpawnDelay = 10;
    private static int standardBlockPoints = 10;
    private static int bonusBlockPoints = 20;
    private static int pickupBlockPoints = 15;
    private static float standardBlockSpawnProbability = 50f;
    private static float bonusBlockSpawnProbability = 20f;
    private static float freezerBlockSpawnProbability = 15f;
    private static float speedupBlockSpawnProbability = 15f;
    private static float freezerEffectDuratio = 2f;
    private static int ballsPerGame = 5;
    private static int speedUpDuration = 2;
    private static float speedUpFactor = 1.3f;

    #endregion

    #region Properties

    public float MinimumSpawnDelay
    {
        get { return minimumSpawnDelay; }
    }  
    public float MaximumSpawnDelay
    {
        get { return maximumSpawnDelay; }
    }

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

    public float BallDeathTimer
    {
        get { return ballDeathTimer; }
    } public int BallsPerGame
    {
        get { return ballsPerGame; }
    }
    public int StandardBlockPoints { get { return standardBlockPoints; } }
    public int BonusBlockPoints { get { return bonusBlockPoints; } }
    public int PickupBlockPoints { get { return pickupBlockPoints; } }
    public float StandardBlockSpawnProbability { get { return standardBlockSpawnProbability; } }
    public float BonusBlockSpawnProbability { get { return bonusBlockSpawnProbability; } }
    public float FreezerBlockSpawnProbability { get { return freezerBlockSpawnProbability; } }
    public float FreezerEffectDuratio { get { return freezerEffectDuratio; } }
    public float SpeedupBlockSpawnProbability { get { return speedupBlockSpawnProbability; } }
    public float SpeedUpDuration { get { return speedUpDuration; } }
    public float SpeedUpFactor { get { return speedUpFactor; } }
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
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();


            SetConfirationData(values);

        }
        catch (Exception e)
        { 
        
        }
        finally
        {
            if (input != null)
                input.Close();
        }
    }

    private void SetConfirationData(string ccvValues)
    {
        string[] values = ccvValues.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);

        ballImpulseForce = float.Parse(values[1]);

        ballDeathTimer = float.Parse(values[2]);
        minimumSpawnDelay = float.Parse(values[3]);
        maximumSpawnDelay = float.Parse(values[4]);
        standardBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        standardBlockSpawnProbability = float.Parse(values[8]);
        bonusBlockSpawnProbability = float.Parse(values[9]);
        freezerBlockSpawnProbability = float.Parse(values[10]);
        speedupBlockSpawnProbability = float.Parse(values[11]);
        ballsPerGame = int.Parse(values[12]);
    }
    #endregion
}
