using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    static float speedBoost = 1;
    static float boostFactor = 1.5f;

    public static float SpeedBoost
    {
        get { return speedBoost; }
        set { speedBoost = value; }
    }

    public static float BoostFactor
    {
        get { return boostFactor; }
        set { boostFactor = value; }
    }
}
