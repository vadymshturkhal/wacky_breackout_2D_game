using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    void Start()
    {
        // Points quantity for the block
        weight = ConfigurationUtils.BonusBlockPoint;

        base.Start();
    }
}
