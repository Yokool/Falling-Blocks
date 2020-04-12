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

        SerializedJetpack = new SaveableJetpackItem("/Jetpack.shopitem", 0.0025f, 0.05f, 10f, 5f);
        SerializedJump = new SaveableJumpItem("/Jump.shopitem", 250);
        SerializedLevel = new SaveableLevelItem("/Level.shopitem", 5, 5);
        SerializedScore = new SaveableScoreItem("/Score.shopitem", 1);

    }

    private static void CreateItemManagers()
    {

        ItemUpgradeManager Jetpack_Refuel_Manager = new ItemUpgradeManager("Jetpack Refuel pipes", "Upgrading the pipes.", 50, null, 1.1f, 9, new Jetpack_Refuel_Buy());
        ItemUpgradeManager Jetpack_SpendfuelDecrement_Manager = new ItemUpgradeManager("Jetpack engine efficiency", "Finding yourself with not enough air time? Boost your engine to stay in the air for longer.", 500, null, 1.1f, 50, new Jetpack_SpendfuelDecrement_Buy());
        ItemUpgradeManager Jetpack_Maxfuel_Manager = new ItemUpgradeManager("Jetpack fuel tank", "More tanks, more fuel.", 50, null, 1.1f, 9, new Jetpack_Maxfuel_Buy());
        ItemUpgradeManager Jetpack_Strength_Manager = new ItemUpgradeManager("Jetpack Engine", "Improving the jetpack engine will boost its upper momentum.", 40, null, 1.1f, 20, new Jetpack_Strength_Buy());


        ItemUpgradeManager Jump_Strength_Manager = new ItemUpgradeManager("1-year fitness pass", "Not skipping leg day for a single year straight will allow you to jump sligthtly higher.", 100, null, 1.1f, 10, new Jump_Strength_Buy());

        ItemUpgradeManager Level_Width_Manager = new ItemUpgradeManager("Level Width", "Increase the width of your playing field", 100, null, 1.1f, 100, new LevelOnBuyWidth());
        ItemUpgradeManager Level_Height_Manager = new ItemUpgradeManager("Level Height", "Increase the height of your playing field", 100, null, 1.1f, 100, new LevelOnBuyHeight());

        ItemUpgradeManager Score_Multiplier_Manager = new ItemUpgradeManager("Score Mutliplier", "Buy this to multiply your score.", 200, null, 1.1f, 20, new ScoreOnBuyMultiplier());

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
