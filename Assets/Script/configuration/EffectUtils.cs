using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    private static SpeedupEffectMonitor effectMonitor;

    private static int duratio = 0;
    public static int Duratio { set { duratio = value; } }
    public static bool IsRun { get { return effectMonitor.Finish; } }

    public static void Initialize()
    {
        effectMonitor = new SpeedupEffectMonitor();
    }
}
