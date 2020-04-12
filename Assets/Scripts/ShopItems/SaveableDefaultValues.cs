using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveableDefaultValues : MonoBehaviour
{
    // Jetpack
    public const float jetpackRefuelIncrement_DEFAULT = 0.0025f;
    public const float jetpackSpendFuelDecrement_DEFAULT = 0.05f;
    public const float maxFuel_DEFAULT = 10f;
    public const float jetpackStrength_DEFAULT = 5f;

    // Jump
    public const float jumpHeight_DEFAULT = 250;

    // Level
    public const int levelWidth_DEFAULT = 5;
    public const int levelHeight_DEFAULT = 5;

    // Score
    public const float scoreMultiplier_DEFAULT = 1f;
}
