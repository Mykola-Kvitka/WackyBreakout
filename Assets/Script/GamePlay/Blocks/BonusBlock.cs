using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Blocks
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        score = ConfigurationUtils.BonusBlockPoints;
    }

}
