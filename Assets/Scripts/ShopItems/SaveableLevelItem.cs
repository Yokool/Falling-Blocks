using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableLevelItem : SaveableShopItem<TileManager>
{

    public int levelWidth;
    

    public int levelHeight;
    

    public SaveableLevelItem(string path) : base(path)
    {

    }

    public override void LoadValuesFromFile()
    {
        SaveableLevelItem saveableLevelItem = LoadAssociatedFile() as SaveableLevelItem;
        
        levelWidth = saveableLevelItem.levelWidth;
        levelHeight = saveableLevelItem.levelHeight;
    }

    public override void PopulateScript(TileManager script)
    {
        script.mapSize = new Vector2(levelWidth, levelHeight);
    }

    public override void SetValues(TileManager script)
    {
        this.levelWidth = (int)script.mapSize.x;
        this.levelHeight = (int)script.mapSize.y;
    }

    public override void LoadDefaultValues()
    {
        levelWidth = SaveableDefaultValues.levelWidth_DEFAULT;
        levelHeight = SaveableDefaultValues.levelHeight_DEFAULT;
    }

}
