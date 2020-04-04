using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableJumpItem : SaveableShopItem<Jump>
{

    private float jumpHeight_DEFAULT;

    public float jumpHeight;



    public SaveableJumpItem(string path, float jumpHeight_DEFAULT) : base(path)
    {
        this.jumpHeight_DEFAULT = jumpHeight_DEFAULT;
    }

    public override void LoadValuesFromFile()
    {
        SaveableJumpItem thisItem = LoadAssociatedFile() as SaveableJumpItem;

        if(thisItem == null)
        {
            jumpHeight = jumpHeight_DEFAULT;
            
            return;
        }

        jumpHeight = thisItem.jumpHeight;

    }

    public override void PopulateScript(Jump script)
    {
        this.jumpHeight = script.jumpHeight;
    }

    public override void SetValues(Jump script)
    {
        script.jumpHeight = this.jumpHeight;
    }
}
