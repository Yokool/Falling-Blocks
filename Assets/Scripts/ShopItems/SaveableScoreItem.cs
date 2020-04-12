using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveableScoreItem : SaveableShopItem<Score>
{

    public SaveableScoreItem(string path, float scoreMultiplier) : base(path)
    {
        scoreMultiplier_DEFAULT = scoreMultiplier;
    }

    public float scoreMultiplier;
    public float scoreMultiplier_DEFAULT;

    public override void LoadValuesFromFile()
    {
        SaveableScoreItem item = LoadAssociatedFile() as SaveableScoreItem;
        if (item == null)
        {
            scoreMultiplier = scoreMultiplier_DEFAULT;
        }
    }

    public override void PopulateScript(Score script)
    {
        script.scoreMultiplier = this.scoreMultiplier;
    }

    public override void SetValues(Score script)
    {
        this.scoreMultiplier = script.scoreMultiplier;
    }

}
