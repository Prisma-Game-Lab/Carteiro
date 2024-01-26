using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public bool level2Passado;
    public bool level3Passado;

    public Data (LevelProgressionTracker levelTracker)
    {
        level2Passado = levelTracker.level2Unlocked;
        level3Passado = levelTracker.level3Unlocked;
    }

}
