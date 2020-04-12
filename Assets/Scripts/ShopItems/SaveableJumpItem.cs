using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableJumpItem : SaveableShopItem<Jump>
{

    

    public float jumpHeight;



    public SaveableJumpItem(string path) : base(path)
    {

    }

    public override void LoadValuesFromFile()
    {
        SaveableJumpItem thisItem = LoadAssociatedFile() as SaveableJumpItem;


        jumpHeight = thisItem.jumpHeight;

    }

    public override void PopulateScript(Jump script)
    {
        script.jumpHeight = this.jumpHeight;
    }

    public override void SetValues(Jump script)
    {
        this.jumpHeight = script.jumpHeight;
    }

    public override void LoadDefaultValues()
    {
        jumpHeight = SaveableDefaultValues.jumpHeight_DEFAULT;
    }
}
