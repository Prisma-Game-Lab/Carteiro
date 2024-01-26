using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool level2Passado;
    public bool level3Passado;

    public GameData (LetterDisplay levelTracker)
    {
        level2Passado = levelTracker.level2Unlocked;
        level3Passado = levelTracker.level3Unlocked;
    }

}
