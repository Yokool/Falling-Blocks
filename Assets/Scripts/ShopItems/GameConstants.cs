using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour
{
    // Jetpack
    public const float jetpackRefuelIncrement_DEFAULT = 0.0025f;
    public const float jetpackSpendFuelDecrement_DEFAULT = 0.05f;
    public const float maxFuel_DEFAULT = 10f;
    public const float jetpackStrength_DEFAULT = 5f;
    // Jetpack - BUY
    public const float jetpackRefuelIncrement_BUY = 0.0025f;
    public const float jetpackSpendFuelDecrement_BUY = 0.005f;
    public const float maxFuel_BUY = 1f;
    public const float jetpackStrength_BUY = 0.1f;

    // Jump
    public const float jumpHeight_DEFAULT = 250f;
    public const float jumpCooldown_DEFAULT = 10f;
    // Jump - BUY
    public const float jumpHeight_BUY = 25f;
    public const float jumpCooldown_BUY = 1f;

    // Level
    public const int levelWidth_DEFAULT = 10;
    public const int levelHeight_DEFAULT = 10;
    // Level Buy
    public const int levelWidth_BUY = 1;
    public const int levelHeight_BUY = 1;

    // Score
    public const float scoreMultiplier_DEFAULT = 1f;
    // Score Buy
    public const float scoreMultiplier_BUY = 0.1f;
}
