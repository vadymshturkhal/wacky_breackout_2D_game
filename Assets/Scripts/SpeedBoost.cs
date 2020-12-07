using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeedBoost
{
    static float impulseForce = ConfigurationUtils.BallImpulseForce;

    public static float ImpulseForce
    {
        get { return ImpulseForce; }
        set { impulseForce = value; }
    }
}
