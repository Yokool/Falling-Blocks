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

        SerializedJetpack = new SaveableJetpackItem("/Jetpack.shopitem");
        SerializedJump = new SaveableJumpItem("/Jump.shopitem");
        SerializedLevel = new SaveableLevelItem("/Level.shopitem");
        SerializedScore = new SaveableScoreItem("/Score.shopitem");

    }

    private static void CreateItemManagers()
    {
        ItemUpgradeManager Jetpack_Refuel_Manager = new ItemUpgradeManager("Jetpack Refuel Pipes", "By increasing the circumference of the refueling pipes, refuel times will be significantly cut.", 50, SpriteDatabase.RefuelPipes, 1.1f, 9, new Jetpack_Refuel_Buy());
        ItemUpgradeManager Jetpack_SpendfuelDecrement_Manager = new ItemUpgradeManager("High-grade fuel", "Investing in quality fuel will boost the efficiency of your jetpack. Better fuel lasts longer in the air.", 500, SpriteDatabase.FuelCanister, 1.1f, 50, new Jetpack_SpendfuelDecrement_Buy());
        ItemUpgradeManager Jetpack_Maxfuel_Manager = new ItemUpgradeManager("Jetpack Fuel Tank", "Simple. More tanks, more fuel space, more air-time.", 50, SpriteDatabase.FuelTank, 1.1f, 9, new Jetpack_Maxfuel_Buy());
        ItemUpgradeManager Jetpack_Strength_Manager = new ItemUpgradeManager("Jetpack Jets", "Improving the jetpack engine will boost its upper momentum.", 40, SpriteDatabase.JetEngine, 1.1f, 20, new Jetpack_Strength_Buy());


        ItemUpgradeManager Jump_Strength_Manager = new ItemUpgradeManager("Mechanic Legs", "Upgrading the inner mechanism of the legs will allow you to jump higher.", 100, SpriteDatabase.MechanicalLeg, 1.1f, 10, new Jump_Strength_Buy());

        ItemUpgradeManager Level_Width_Manager = new ItemUpgradeManager("Buy More Land - Width", "I hereby declare you the rightful owner of more land... why do you need so much land if it's going to end up shelled by the meteors?", 120, SpriteDatabase.DeedRed, 1.05f, 90, new LevelOnBuyWidth());
        ItemUpgradeManager Level_Height_Manager = new ItemUpgradeManager("Buy More Land - Height", "Are you sure you want MORE of this? This doesn't seem profitable.", 120, SpriteDatabase.DeedBlue, 1.05f, 90, new LevelOnBuyHeight());

        ItemUpgradeManager Score_Multiplier_Manager = new ItemUpgradeManager("Golden Mask", "\"Why would buying expensive gold masks boost my score multiplier?\" - Someone, Somewhere, Sometime", 240, SpriteDatabase.GoldenMask, 1.1f, 20, new ScoreOnBuyMultiplier());

        upgradeManagers.Add(Jetpack_Refuel_Manager);
        upgradeManagers.Add(Jetpack_SpendfuelDecrement_Manager);
        upgradeManagers.Add(Jetpack_Maxfuel_Manager);
        upgradeManagers.Add(Jetpack_Strength_Manager);

        upgradeManagers.Add(Jump_Strength_Manager);

        upgradeManagers.Add(Level_Width_Manager);
        upgradeManagers.Add(Level_Height_Manager);

        upgradeManagers.Add(Score_Multiplier_Manager);

    }


}
