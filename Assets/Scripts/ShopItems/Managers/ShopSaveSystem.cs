using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShopSaveSystem
{

    public static SaveableJetpackItem SerializedJetpack;

    public static SaveableJumpItem SerializedJump;

    public static SaveableLevelItem SerializedLevel;

    public static SaveableScoreItem SerializedScore;

    public static List<ItemUpgradeManager> upgradeManagers = new List<ItemUpgradeManager>();

    

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeItemSaveSystem()
    {

        CreateItems();
        CreateItemManagers();

    }

    private static void CreateItems()
    {

        SerializedJetpack = new SaveableJetpackItem("/Jetpack.xml");
        SerializedJump = new SaveableJumpItem("/Jump.xml");
        SerializedLevel = new SaveableLevelItem("/Level.xml");
        SerializedScore = new SaveableScoreItem("/Score.xml");

    }

    private static void CreateItemManagers()
    {
        ItemUpgradeManager Jetpack_Refuel_Manager = new ItemUpgradeManager("Jetpack Refuel Pipes", "By increasing the circumference of the refueling pipes, refuel times will be significantly cut.", 50, SpriteDatabase.RefuelPipes, 0.1f, 9, new Jetpack_Refuel_Buy(), "JetpackRefuelManager");
        ItemUpgradeManager Jetpack_SpendfuelDecrement_Manager = new ItemUpgradeManager("High-grade fuel", "Investing in quality fuel will boost the efficiency of your jetpack. Better fuel lasts longer in the air.", 500, SpriteDatabase.FuelCanister, 0.1f, 50, new Jetpack_SpendfuelDecrement_Buy(), "JetpackSpendFuelManager");
        ItemUpgradeManager Jetpack_Maxfuel_Manager = new ItemUpgradeManager("Jetpack Fuel Tank", "Simple. More tanks, more fuel space, more air-time.", 30, SpriteDatabase.FuelTank, 0.1f, 30, new Jetpack_Maxfuel_Buy(), "JetpackMaxfuelManager");
        ItemUpgradeManager Jetpack_Strength_Manager = new ItemUpgradeManager("Jetpack Jets", "Improving the jetpack engine will boost its upper momentum.", 40, SpriteDatabase.JetEngine, 0.1f, 20, new Jetpack_Strength_Buy(), "JetpackStrengthManager");


        ItemUpgradeManager Jump_Strength_Manager = new ItemUpgradeManager("Mechanic Leg Springs", "Upgrading the inner springs of the mechanical legs will allow you to jump higher.", 100, SpriteDatabase.MechanicalLeg, 0.1f, 10, new Jump_Strength_Buy(), "JumpStrengthManager");
        ItemUpgradeManager Jump_Cooldown_Manager = new ItemUpgradeManager("Mechanical Leg Cogs", "Upgrading the cogs of the mechanical legs will allow you to jump more often.", 200, SpriteDatabase.MechanicalLeg, 0.1f, 9, new Jump_ReduceCooldown_Buy(), "JumpCooldownManager");

        ItemUpgradeManager Level_Width_Manager = new ItemUpgradeManager("Buy More Land - Width", "I hereby declare you the rightful owner of more land... why do you need so much land if it's going to end up shelled by the meteors?", 50, SpriteDatabase.DeedRed, 0.0025f, 90, new LevelOnBuyWidth(), "LevelWidthManager");
        ItemUpgradeManager Level_Height_Manager = new ItemUpgradeManager("Buy More Land - Height", "Are you sure you want MORE of this? This doesn't seem profitable.", 75, SpriteDatabase.DeedBlue, 0.0025f, 90, new LevelOnBuyHeight(), "LevelHeightManager");

        ItemUpgradeManager Score_Multiplier_Manager = new ItemUpgradeManager("Golden Mask", "\"Why would buying expensive gold masks boost my score multiplier?\" - Someone, Somewhere, Sometime", 240, SpriteDatabase.GoldenMask, 0.1f, 20, new ScoreOnBuyMultiplier(), "ScoreMultiplierManager");

        upgradeManagers.Add(Jetpack_Refuel_Manager);
        upgradeManagers.Add(Jetpack_SpendfuelDecrement_Manager);
        upgradeManagers.Add(Jetpack_Maxfuel_Manager);
        upgradeManagers.Add(Jetpack_Strength_Manager);

        upgradeManagers.Add(Jump_Strength_Manager);
        upgradeManagers.Add(Jump_Cooldown_Manager);

        upgradeManagers.Add(Level_Width_Manager);
        upgradeManagers.Add(Level_Height_Manager);

        upgradeManagers.Add(Score_Multiplier_Manager);

    }


}
