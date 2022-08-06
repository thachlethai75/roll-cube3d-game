using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int totalGem;
    public bool[] charUnlocked;
    public int language;
    public int qualitySetting;


    public GameData()
    {
        totalGem = 0;
        charUnlocked = new bool[4];
        charUnlocked[0] = true;
        language = 0;
        qualitySetting = 1;
    }
}
