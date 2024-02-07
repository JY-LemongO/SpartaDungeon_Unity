using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Item : UI_Base
{
    enum Images
    {
        Item_Image,
        Equip_Image,
    }

    public override void Init()
    {
        base.Init();

        BindImage(typeof(Images));        
    }

    private Sprite GetItemSprite()
    {
        return null;
    }
}
