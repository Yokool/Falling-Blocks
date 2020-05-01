using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameCodeConstants
{
    /// <summary>
    /// Used in DestroyOnDeath.cs
    /// Determining how smooth the white - black transition should be.
    /// Less values = more choppy transition but better optimized.
    /// </summary>
    public static int TransitionFraction = 25;
    /// <summary>
    /// Used in DestroyOnDeath.cs
    /// Determines how long the transition should last. From white to black.
    /// </summary>
    public static float TransitionTime = 1f;

    public static Color DarkRedColor = new Color(0.63f, 0.02f, 0.2f);

}
