using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public static class GlobalSettings
{
    public static bool singlePlayer = true;

    public static AIDifficulty singlePlayerDifficulty = AIDifficulty.Easy;
}

public enum AIDifficulty
{
    Easy,
    Medium,
    Hard
}