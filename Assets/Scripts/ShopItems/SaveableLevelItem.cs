using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableLevelItem : SaveableShopItem<TileManager>
{

    public int levelWidth;
    private int levelWidth_DEFAULT;

    public int levelHeight;
    private int levelHeight_DEFAULT;

    public SaveableLevelItem(string path, int levelWidth, int levelHeight) : base(path)
    {
        this.levelWidth_DEFAULT = levelWidth;
        this.levelHeight_DEFAULT = levelHeight;
    }

    public override void LoadValuesFromFile()
    {
        SaveableLevelItem saveableLevelItem = LoadAssociatedFile() as SaveableLevelItem;
        if(saveableLevelItem == null)
        {
            levelWidth = levelWidth_DEFAULT;
            levelHeight = levelHeight_DEFAULT;
            return;
        }
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

}
