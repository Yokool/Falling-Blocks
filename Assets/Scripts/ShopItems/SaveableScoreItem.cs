using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveableScoreItem : SaveableShopItem<Score>
{
    public float scoreMultiplier;
    public float scoreMultiplier_DEFAULT;

    public SaveableScoreItem(string path, float scoreMultiplier) : base(path)
    {
        scoreMultiplier_DEFAULT = scoreMultiplier;
    }

    public override void LoadValuesFromFile()
    {
        SaveableScoreItem item = LoadAssociatedFile() as SaveableScoreItem;
        this.scoreMultiplier = item.scoreMultiplier;
    }

    public override void PopulateScript(Score script)
    {
        script.scoreMultiplier = this.scoreMultiplier;
    }

    public override void SetValues(Score script)
    {
        this.scoreMultiplier = script.scoreMultiplier;
    }

    public override void LoadDefaultValues()
    {
        scoreMultiplier = scoreMultiplier_DEFAULT;
    }

}
