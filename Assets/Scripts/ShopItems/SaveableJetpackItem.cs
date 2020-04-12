using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableJetpackItem : SaveableShopItem<Jetpack>
{
    public float jetpackRefuelIncrement;
    private float jetpackRefuelIncrement_DEFAULT;

    public float jetpackSpendFuelDecrement;
    private float jetpackSpendFuelDecrement_DEFAULT;

    public float maxFuel;
    private float maxFuel_DEFAULT;

    public float jetpackStrength;
    private float jetpackStrength_DEFAULT;

    public SaveableJetpackItem(string path, float jetpackRefuelIncrement_DEFAULT, float jetpackSpendFuelDecrement_DEFAULT, float maxFuel_DEFAULT, float jetpackStrength_DEFAULT) : base(path)
    {
        this.jetpackRefuelIncrement_DEFAULT = jetpackRefuelIncrement_DEFAULT;
        this.jetpackSpendFuelDecrement_DEFAULT = jetpackSpendFuelDecrement_DEFAULT;
        this.maxFuel_DEFAULT = maxFuel_DEFAULT;
        this.jetpackStrength_DEFAULT = jetpackStrength_DEFAULT;
    }

    public override void LoadValuesFromFile()
    {

        SaveableJetpackItem thisItem = LoadAssociatedFile() as SaveableJetpackItem;

        jetpackRefuelIncrement = thisItem.jetpackRefuelIncrement;
        jetpackSpendFuelDecrement = thisItem.jetpackSpendFuelDecrement;
        maxFuel = thisItem.maxFuel;
        jetpackStrength = thisItem.jetpackStrength;

    }

    public override void PopulateScript(Jetpack script)
    {
        script.jetpackRefuelIncrement = this.jetpackRefuelIncrement;
        script.jetpackSpendFuelDecrement = this.jetpackSpendFuelDecrement;
        script.maxFuel = this.maxFuel;
        script.jetpackStrength = this.jetpackStrength;
    }

    public override void SetValues(Jetpack script)
    {
        this.jetpackRefuelIncrement = script.jetpackRefuelIncrement;
        this.jetpackSpendFuelDecrement = script.jetpackSpendFuelDecrement;
        this.maxFuel = script.maxFuel;
        this.jetpackStrength = script.jetpackStrength;

    }

    public override void LoadDefaultValues()
    {
        jetpackRefuelIncrement = jetpackRefuelIncrement_DEFAULT;
        jetpackSpendFuelDecrement = jetpackSpendFuelDecrement_DEFAULT;
        maxFuel = maxFuel_DEFAULT;
        jetpackStrength = jetpackStrength_DEFAULT;
    }
}
