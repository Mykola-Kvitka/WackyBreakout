using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    private static ConfigurationData configurationData;
    #region Properties

    public static float MinimumSpawnDelay { get { return configurationData.MinimumSpawnDelay; } }
    public static float MaximumSpawnDelay { get { return configurationData.MaximumSpawnDelay; } }
    public static float PaddleMoveUnitsPerSecond { get { return configurationData.PaddleMoveUnitsPerSecond; } }
    public static float BallImpulseForce { get { return configurationData.BallImpulseForce; } }
    public static float BallDeathTimer { get { return configurationData.BallDeathTimer; } }
    public static int StandardBlockPoints { get { return configurationData.StandardBlockPoints; } }
    public static int BonusBlockPoints { get { return configurationData.BonusBlockPoints; } }
    public static int PickupBlockPoints { get { return configurationData.PickupBlockPoints; } }
    public static float StandardBlockSpawnProbability { get { return configurationData.StandardBlockSpawnProbability; } }
    public static float BonusBlockSpawnProbability { get { return configurationData.BonusBlockSpawnProbability; } }
    public static float FreezerBlockSpawnProbability { get { return configurationData.FreezerBlockSpawnProbability; } } 
    public static float FreezerEffectDuratio { get { return configurationData.FreezerEffectDuratio; } }
    public static float SpeedupBlockSpawnProbability { get { return configurationData.SpeedupBlockSpawnProbability; } }
    public static float SpeedUpDuration { get { return configurationData.SpeedUpDuration; } }
    public static float SpeedUpFactor { get { return configurationData.SpeedUpFactor; } }
    public static int BallsPerGame { get { return configurationData.BallsPerGame; } }
    #endregion
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
